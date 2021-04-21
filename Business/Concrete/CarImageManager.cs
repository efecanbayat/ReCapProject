using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var getListByCarId = _carImageDal.GetAll(car => car.CarId == carId);
            if (getListByCarId.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(getListByCarId);
            }

            return CheckIfCarImageNull(carId);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, formFile);
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            
                string path = @"\Images\default.jpg";

                var result = _carImageDal.GetAll(c => c.CarId == id).Any();

                var defaultImage = new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };

                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

    }
}
