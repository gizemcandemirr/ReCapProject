using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
   public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
      
        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour== 11)
            {
            return new SuccessDataResult<List<Car>>(Messages.MaintenanceTime);     

            }
            return new ErrorDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>> GetByUnitPrice(int filter)

        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice == filter));


        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            throw new NotImplementedException();
        }
        [ValidationAspect(typeof(CarValidator))]
         public  IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
    }
}
