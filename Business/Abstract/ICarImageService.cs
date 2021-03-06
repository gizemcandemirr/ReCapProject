using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImageService
    {

        IDataResult<List<CarImages>> GetAll();

        IDataResult<CarImages> Get(int id);

        IResult Add(CarImagesOperationDto carImagesOperationDto);

        IResult Update(CarImagesOperationDto carImagesOperationDto);

        IResult Delete(CarImages entity);

        IDataResult<List<CarImages>> GetAllByCarId(int carId);

    }
}
