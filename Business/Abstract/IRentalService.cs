using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
 public interface IRentalService
    {

        IDataResult<List<Rentals>> GetAll();

        IDataResult<Rentals> GetById(int id);

        IDataResult<List<RentalDetailDTO>> GetRentalDetails();

        IResult Add(Rentals rental);
        IResult Delete(Rentals rental);

    }
}
