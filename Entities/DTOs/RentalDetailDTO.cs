using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
   public class RentalDetailDTO: IDto
    {

        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public string FirstName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int DailyPrice { get; set; }
    }
}
