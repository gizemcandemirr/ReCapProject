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

                new Car { BrandId=1, ColorId=3, DailyPrice=50, ModelYear=1997, Description="Şahin" },
                new Car { BrandId=2, ColorId=5, DailyPrice=10, ModelYear=2000, Description="Uno" },
                new Car { BrandId=3, ColorId=1, DailyPrice=5, ModelYear=2001, Description="Mercedes" },
                new Car { BrandId=1, ColorId=7, DailyPrice=500, ModelYear=1985, Description="Tofaş" },
                new Car { BrandId=2, ColorId=2, DailyPrice=70, ModelYear=1999, Description="Clio" }

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car cartoDelete = null;
            cartoDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(cartoDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car updatetoCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            updatetoCar.BrandId = car.BrandId;
            updatetoCar.ColorId = car.ColorId;
            updatetoCar.DailyPrice = car.DailyPrice;
            updatetoCar.Description = car.Description;

        }
    }
}
