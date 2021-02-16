using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rentals, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDTO> GetRentalDetails(Expression<Func<Rentals, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Car
                             on r.CarId equals c.CarId
                             join cu in context.Customer
                             on r.CustomerId equals cu.CustomerId
                             join u in context.User
                             on cu.UserId equals u.UserId

                             select new RentalDetailDTO
                             {
                                 RentalId = r.RentalId,
                                 FirstName = u.FirstName, 
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
                



            }
        }
    }
}
