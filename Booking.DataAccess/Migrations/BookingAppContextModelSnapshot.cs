﻿// <auto-generated />
using System;
using BookingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Booking.DataAccess.Migrations
{
    [DbContext(typeof(BookingAppContext))]
    partial class BookingAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Booking.Models.Models.SeatType", b =>
                {
                    b.Property<int>("SeatTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeatTypeId");

                    b.ToTable("SeatTypes");
                });

            modelBuilder.Entity("BookingApp.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("TypeId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("BookingApp.Models.EventType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("BookingApp.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaximumCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("BookingApp.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EventDate")
                        .HasColumnType("date");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int?>("SeatPricesSeatTypeNavigationSeatPriceId")
                        .HasColumnType("int");

                    b.Property<int?>("SeatStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("SeatType")
                        .HasColumnType("int");

                    b.Property<string>("SectorNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeatId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("SeatPricesSeatTypeNavigationSeatPriceId");

                    b.HasIndex("SeatStatusId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("BookingApp.Models.SeatPrice", b =>
                {
                    b.Property<int>("SeatPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("SeatType")
                        .HasColumnType("int");

                    b.Property<int?>("SeatTypesSeatTypeId")
                        .HasColumnType("int");

                    b.HasKey("SeatPriceId");

                    b.HasIndex("EventId");

                    b.HasIndex("SeatTypesSeatTypeId");

                    b.ToTable("SeatPrices");
                });

            modelBuilder.Entity("BookingApp.Models.SeatStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("SeatStatuses");
                });

            modelBuilder.Entity("BookingApp.Models.Event", b =>
                {
                    b.HasOne("BookingApp.Models.Place", "Place")
                        .WithMany("Event")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Models.EventType", "Type")
                        .WithMany("Event")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingApp.Models.Seat", b =>
                {
                    b.HasOne("BookingApp.Models.Place", "Places")
                        .WithMany("Seats")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Models.SeatPrice", "SeatPricesSeatTypeNavigation")
                        .WithMany("Seats")
                        .HasForeignKey("SeatPricesSeatTypeNavigationSeatPriceId");

                    b.HasOne("BookingApp.Models.SeatStatus", "SeatStatus")
                        .WithMany("Seats")
                        .HasForeignKey("SeatStatusId");
                });

            modelBuilder.Entity("BookingApp.Models.SeatPrice", b =>
                {
                    b.HasOne("BookingApp.Models.Event", "Event")
                        .WithMany("SeatPrices")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Models.Models.SeatType", "SeatTypes")
                        .WithMany()
                        .HasForeignKey("SeatTypesSeatTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
