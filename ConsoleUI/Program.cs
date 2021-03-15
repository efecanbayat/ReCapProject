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
            CarTest();

            //BrandTest();

            //ColorTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //colorManager.Add(new Color { Id = 4, Name = "Kırmızı" });
            //colorManager.Update(new Color { Id = 4, Name = "Mavi" });
            //colorManager.Delete(new Color { Id = 4, Name = "Mavi" });
            //Console.WriteLine(colorManager.GetById(1).Name);

            Console.WriteLine("--------Colors--------");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }

            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //brandManager.Add(new Brand { Id = 4, Name = "Volkswagen" });
            //brandManager.Update(new Brand { Id = 4, Name = "Audi" });
            //brandManager.Delete(new Brand { Id = 4, Name = "Audi" });
            //Console.WriteLine(brandManager.GetById(1).Name);

            Console.WriteLine("--------Brands--------");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car { Id = 6, BrandId = 3, ColorId = 2, ModelYear = 2020, DailyPrice = 900, Description = "Velar" });          
            //carManager.Update(new Car { Id = 6, BrandId = 3, ColorId = 2, ModelYear = 2020, DailyPrice = 1000, Description = "Velar" });
            //carManager.Delete(new Car { Id = 6, BrandId = 3, ColorId = 2, ModelYear = 2020, DailyPrice = 900, Description = "Velar" });
            //Console.WriteLine(carManager.GetById(1).Description); 

            //Console.WriteLine("--------GetCarsByBrandId ile gelen liste--------");
            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(car.ModelYear + " " + car.Description + " : " + car.DailyPrice + " TL");
            //}

            //Console.WriteLine("--------GetCarsByColorId ile gelen liste--------");
            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(car.ModelYear + " " + car.Description + " : " + car.DailyPrice + " TL");
            //}
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                Console.WriteLine("--------Cars--------");
                foreach (var car in result.Data)
                {                
                    Console.WriteLine("{0} {1} {2} {3} TL", car.BrandName, car.CarName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            
        }
    }
}
