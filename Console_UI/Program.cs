using Business.Concrete;
using DataAccess.Abstract;
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
           carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 200, ModelYear = 2010, Description = "b" });

               
            foreach (var car in carManager.GetAll())
            {
               
                Console.WriteLine(car.Description + " " + car.DailyPrice + " " + car.ModelYear);

            }

         

           


        }
    }
}
