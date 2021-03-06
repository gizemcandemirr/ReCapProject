using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Entities.DTOs;

namespace Business.Concrete
{

    public class CarImageManager : ICarImageService
    {
        private readonly ICarImagesDal _carImageDal;
        private readonly ICarService _carService;

        public CarImageManager(ICarImagesDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(CarImagesOperationDtoValidator))]
        public IResult Add(CarImagesOperationDto carImagesOperationDto)
        {
            var result = BusinessRules.Run(
                CheckCarImageCount(carImagesOperationDto.CarId),
                CheckIfCarId(carImagesOperationDto.CarId));
            if (result != null)
            {
                return result;
            }

            foreach (var file in carImagesOperationDto.Images)
            {
                _carImageDal.Add(new CarImages
                {
                    CarId = carImagesOperationDto.CarId,
                    ImagePath = FileProcessHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImages entity)
        {
            var imageData = _carImageDal.Get(p => p.Id == entity.Id);
            FileProcessHelper.Delete(imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.DeleteCarImageMessage);
        }

        public IDataResult<CarImages> Get(int id)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }

        [ValidationAspect(typeof(CarImagesOperationDtoValidator))]
        public IResult Update(CarImagesOperationDto carImagesOperationDto)
        {
            foreach (var file in carImagesOperationDto.Images)
            {
                var result = BusinessRules.Run(
                    CheckIfCarImagesId(carImagesOperationDto.Id),
                    CheckCarImageCount(carImagesOperationDto.CarId),
                    CheckIfCarId(carImagesOperationDto.CarId)
                );
                if (result != null)
                {
                    return result;
                }

                FileProcessHelper.Delete(_carImageDal.Get(p => p.Id == carImagesOperationDto.Id).ImagePath);
                _carImageDal.Update(new CarImages
                {
                    Id = carImagesOperationDto.Id,
                    CarId = carImagesOperationDto.CarId,
                    ImagePath = FileProcessHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult(Messages.EditCarImageMessage);
        }

        public IDataResult<List<CarImages>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarId(carId));
            if (result != null)
            {
                return (IDataResult<List<CarImages>>)result;
            }

            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarId == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImages>>(new List<CarImages>
                {
                    new CarImages
                    {
                        Id = -1,
                        CarId = carId,
                        Date = DateTime.MinValue,
                        ImagePath = DefaultNameOrPath.NoImagePath
                    }
                });
            }

            return new SuccessDataResult<List<CarImages>>(getAllbyCarIdResult);
        }

        #region Car Image Business Rules

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(p => p.CarId == carId).Count > 4)
            {
                return new ErrorResult(Messages.AboveImageAddingLimit);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImagesId(int Id)
        {
            if (_carImageDal.Get(p => p.Id == Id) == null)
            {
                return new ErrorResult(Messages.CarImagesNotAdd);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarId(int carId)
        {
            if (!_carService.Get(carId).Success)
            {
                return new ErrorDataResult<List<CarImages>>(Messages.GetErrorCarMessage);
            }

            return new SuccessDataResult<List<CarImages>>();
        }

        #endregion Car Image Business Rules
    }

}
