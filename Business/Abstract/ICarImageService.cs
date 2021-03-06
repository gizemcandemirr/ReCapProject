using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImageService
    {

        IResult Add(CarImages carImage);
        IResult Update(CarImages carImage);
        IResult Delete(CarImages carImage);

        IDataResult<List<CarImages>> GetAll();

    }
}
