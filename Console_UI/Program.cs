﻿using Business.Concrete;
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
             CarService();
         //   CategoryTest();

        }

        private static void CategoryTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);

            }
        }

        private static void CarService()
        {
            CarManager carManager = new CarManager(new EfCarDal());



            Console.WriteLine("\nAraç\tMarka\t Renk\tÜcret\t");
            Console.WriteLine("------------------------------------------------");

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Description + "\t" + car.BrandName + "\t" + car.ColorName + "\t " + car.DailyPrice + "\t" );
            }
        }
    }
}
