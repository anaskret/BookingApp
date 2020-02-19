using System;
using BookingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingApp.Data
{
    public partial class BookingAppContext : DbContext
    {
        public BookingAppContext()
        {
        }

        public BookingAppContext(DbContextOptions<BookingAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<RefSeatStatus> RefSeatStatus { get; set; }
        public virtual DbSet<Row> Rows { get; set; }
        public virtual DbSet<SeatPrice> SeatPrices { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = BookingApp; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("event_types_type")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.PlaceId).HasColumnName("place_PlaceId");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_event_types_fk");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.PlaceId)
                    .HasConstraintName("event_place_fk");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasKey(e => e.Type)
                    .HasName("event_types_pk");

                entity.ToTable("event_types");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("place");

                entity.Property(e => e.PlaceId)
                    .HasColumnName("PlaceId")
                    .ValueGeneratedNever();

                entity.Property(e => e.MaximumCapacity).HasColumnName("maximum_capacity");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RefSeatStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("ref_seat_status_pk");

                entity.ToTable("ref_seat_status");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusId")
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusDescription)
                    .HasColumnName("StatusDescription")
                    .HasMaxLength(500)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Row>(entity =>
            {
                entity.HasKey(e => new { e.RowNumber, e.SectorNumber, e.PlaceId })
                    .HasName("rows_pk");

                entity.Property(e => e.RowNumber).HasColumnName("RowNumber");

                entity.Property(e => e.SectorNumber)
                    .HasColumnName("sectors_sectornumber")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PlaceId).HasColumnName("sectors_place_PlaceId");

                entity.Property(e => e.SeatCount).HasColumnName("seatcount");

                entity.HasOne(d => d.Sectors)
                    .WithMany(p => p.Rows)
                    .HasForeignKey(d => new { d.SectorNumber, d.PlaceId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rows_sectors_fk");
            });

            modelBuilder.Entity<SeatPrice>(entity =>
            {
                entity.HasKey(e => e.SeatType)
                    .HasName("seat_prices_pk");

                entity.ToTable("seat_prices");

                entity.Property(e => e.SeatType)
                    .HasColumnName("seattype")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EventId).HasColumnName("event_EventId");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(2, 0)");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.SeatPrices)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("seat_prices_event_fk");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(e => new { e.SeatNumber, e.RowNumber, e.SectorNumber, e.PlaceId })
                    .HasName("seats_pk");

                entity.ToTable("seats");

                entity.Property(e => e.SeatNumber).HasColumnName("seatnumber");

                entity.Property(e => e.EventDate)
                    .HasColumnName("eventdate")
                    .HasColumnType("date");

                entity.Property(e => e.RowNumber).HasColumnName("rows_RowNumber");

                entity.Property(e => e.SectorNumber)
                    .HasColumnName("rows_sectors_sectornumber")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PlaceId).HasColumnName("rows_sectors_place_PlaceId");

                entity.Property(e => e.RefSeatStatusId).HasColumnName("ref_seat_status_StatusId");

                entity.Property(e => e.SeatType)
                    .IsRequired()
                    .HasColumnName("seat_prices_seattype")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.RefSeatStatus)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.RefSeatStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("seats_ref_seat_status_fk");

                entity.HasOne(d => d.SeatPricesSeatTypeNavigation)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.SeatType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("seats_seat_prices_fk");

                entity.HasOne(d => d.Rows)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => new { d.RowNumber, d.SectorNumber, d.PlaceId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("seats_rows_fk");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.HasKey(e => new { e.SectorNumber, e.PlaceId })
                    .HasName("sectors_pk");

                entity.ToTable("sectors");

                entity.Property(e => e.SectorNumber)
                    .HasColumnName("sectornumber")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PlaceId).HasColumnName("place_PlaceId");

                entity.Property(e => e.RowsCount).HasColumnName("rowscount");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Sectors)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sectors_place_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
