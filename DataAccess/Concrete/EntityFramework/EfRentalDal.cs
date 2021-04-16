using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,KampDatabaseContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (KampDatabaseContext context = new KampDatabaseContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id

                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
