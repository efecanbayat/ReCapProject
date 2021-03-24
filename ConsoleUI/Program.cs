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
            //CarTest();

            //BrandTest();

            //ColorTest();

            //UserTest();

            //CustomerTest();

            //RentalTest();

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
        
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //customerManager.Add(new Customer { Id = 2, UserId = 2, CompanyName = "Kodlama.io" });
            //customerManager.Update(new Customer { Id = 2, UserId = 2, CompanyName = "Kodlama" });
            //customerManager.Delete(new Customer { Id = 2, UserId = 2, CompanyName = "Kodlama" });
            Console.WriteLine("--------Customers--------");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.UserId + " " + customer.CompanyName);
            }
        }
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //rentalManager.Add(new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Today});
            //rentalManager.Add(new Rental { Id = 2, CarId = 2, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = null });

            Console.WriteLine("--------Rentals--------");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.Id + " " + rental.CustomerId + " " + rental.CarId + " " + rental.RentDate + " " + rental.ReturnDate);
            }
        }

    }
}
