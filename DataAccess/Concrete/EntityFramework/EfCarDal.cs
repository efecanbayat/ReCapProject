using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, KampDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (KampDatabaseContext context = new KampDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id

                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId=c.BrandId,
                                 ColorId=c.ColorId,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,                                 
                                 ModelYear= c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 CarImage = (from i in context.CarImages
                                             where (c.Id == i.CarId)
                                             select new CarImage { Id = i.Id, CarId = c.Id, Date = i.Date, ImagePath = i.ImagePath }).ToList()
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
