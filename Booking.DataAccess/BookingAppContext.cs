using System;
using System.Linq;
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
        public virtual DbSet<SeatStatus> SeatStatuses { get; set; }
        //public virtual DbSet<Row> Rows { get; set; }
        public virtual DbSet<SeatType> SeatTypes { get; set; }
        public virtual DbSet<SectorPrice> SectorPrices { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        //public virtual DbSet<Sector> Sectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = BookingApp; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Type)
                .WithMany(t => t.Events)
                .HasForeignKey(t => t.TypeId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Place)
                .WithMany(p => p.Events)
                .HasForeignKey(p => p.PlaceId);

            modelBuilder.Entity<Seat>()
                .HasOne(p => p.Place)
                .WithMany(s => s.Seats)
                .HasForeignKey(p => p.PlaceId);

            modelBuilder.Entity<Seat>()
                .HasOne(t => t.SeatType)
                .WithMany(s => s.Seats)
                .HasForeignKey(t => t.TypeId);

            modelBuilder.Entity<SectorPrice>()
                .HasOne(e => e.Event)
                .WithMany(sp => sp.SeatPrices)
                .HasForeignKey(e => e.EventId);

            modelBuilder.Entity<SeatStatus>()
                .HasOne(s => s.Seat)
                .WithMany(ss => ss.SeatStatuses)
                .HasForeignKey(s => s.SeatId);

            modelBuilder.Entity<SeatStatus>()
                .HasOne(e => e.Event)
                .WithMany(ss => ss.SeatStatuses)
                .HasForeignKey(e => e.EventId);

            modelBuilder.Entity<SeatStatus>()
                .HasOne(sp => sp.SectorPrice)
                .WithMany(ss => ss.SeatStatuses)
                .HasForeignKey(sp => sp.PriceId);
        }
    }
}
