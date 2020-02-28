using System;
using Booking.Models.Models;
using BookingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingApp.Data
{
    public partial class BookingAppContext : DbContext
    {

        public BookingAppContext(DbContextOptions<BookingAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<SeatStatus> SeatStatus { get; set; }
        //public virtual DbSet<Row> Rows { get; set; }
        public virtual DbSet<SeatType> SeatTypes { get; set; }
        public virtual DbSet<SeatPrice> SeatPrices { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        //public virtual DbSet<Sector> Sectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = BookingApp; Trusted_Connection=True;");
            }
        }

    }
}
