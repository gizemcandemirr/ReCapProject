using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        IResult Add(Car car);
        IDataResult<List<Car>> GetAll();


        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);

        IDataResult<List<Car>> GetByUnitPrice(int deger);


        IDataResult<List<CarDetailDTO>> GetCarDetails();
        
    }
}
