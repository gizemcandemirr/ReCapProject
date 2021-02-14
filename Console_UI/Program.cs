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
            //    CarService();
            //   CategoryTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            if (result.Success == true)
            {
                foreach (var rent in result.Data)
                {

                    Console.WriteLine(rent.FirstName);
                    Console.WriteLine(rent.RentDate);
                    Console.WriteLine(rent.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

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
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + "/" + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            //Console.WriteLine("\nAraç\tMarka\t Renk\tÜcret\t");
            //Console.WriteLine("------------------------------------------------");

            //foreach (var car in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine(car.Description + "\t" + car.BrandName + "\t" + car.ColorName + "\t " + car.DailyPrice + "\t" );
            //}
        }
    }
}
