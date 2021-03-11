using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2020, DailyPrice=150000, Description="Renault Clio"},
                new Car{Id=4, BrandId=1, ColorId=4, ModelYear=2021, DailyPrice=250000, Description="Renault Megane"},
                new Car{Id=2, BrandId=2, ColorId=2, ModelYear=2020, DailyPrice=500000, Description="BMW 3.20"},
                new Car{Id=5, BrandId=2, ColorId=5, ModelYear=2021, DailyPrice=750000, Description="BMW 5.20"},
                new Car{Id=3, BrandId=3, ColorId=3, ModelYear=2019, DailyPrice=350000, Description="Range Rover Evoque"}                
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
