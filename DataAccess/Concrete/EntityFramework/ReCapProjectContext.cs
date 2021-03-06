using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class ReCapProjectContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapProjectDB;Trusted_Connection=true");

        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand{ get; set; }
        public DbSet<Color> Color{ get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<CarImages> CarImages { get; set; }






    }
}
