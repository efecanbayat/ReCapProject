using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);
    }
}
