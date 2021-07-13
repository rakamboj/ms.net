using SmartHotel.Registration.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHotel.Registration.Web.Data
{
    public class BookingsDbContext : DbContext
    {
        public BookingsDbContext() : base(Environment.GetEnvironmentVariable("DefaultConnection") ?? "DefaultConnection")
        {
            Database.SetInitializer(new BookingsDbContextInitializer());
        }

        public DbSet<Booking> Bookings { get; set; }

    }
}