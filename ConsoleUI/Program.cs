using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("--------GetAll ile gelen liste--------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " " + car.Description + " : " + car.DailyPrice + " TL");
            }

            Console.WriteLine("--------GetAllByBrand ile gelen liste--------");
            foreach (var car in carManager.GetAllByBrand(1))
            {
                Console.WriteLine(car.ModelYear + " " + car.Description + " : " + car.DailyPrice + " TL");
            }
        }
    }
}
