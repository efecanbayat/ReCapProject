using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("--------GetAll ile gelen liste--------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " " + car.Description + " : " + car.DailyPrice + " TL");
            }

            Console.WriteLine("--------GetCarsByBrandId ile gelen liste--------");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.ModelYear + " " + car.Description + " : " + car.DailyPrice + " TL");
            }

            Console.WriteLine("--------GetCarsByColorId ile gelen liste--------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.ModelYear + " " + car.Description + " : " + car.DailyPrice + " TL");
            }

            carManager.Add(new Car { Id = 6, BrandId = 3, ColorId = 2, ModelYear = 2020, DailyPrice = 900000, Description = "Velar" });
            Console.WriteLine("--------Eklemeden sonra GetAll ile gelen liste--------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " " + car.Description + " : " + car.DailyPrice + " TL");
            }


        }
    }
}
