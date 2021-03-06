using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImagesDal _carImageDal;

        public CarImageManager(ICarImagesDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImages carImage)
        {
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImages carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();

        }

        public IDataResult<List<CarImages>> GetAll()
        {

            
                return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(),Messages.CarImagesListed);

        }

        public IResult Update(CarImages carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
    }
}
