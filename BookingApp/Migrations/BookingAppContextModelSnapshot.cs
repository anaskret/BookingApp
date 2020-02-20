﻿// <auto-generated />
using System;
using BookingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Booking.App.Migrations
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

            modelBuilder.Entity("BookingApp.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeNavigationTypeId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("TypeNavigationTypeId");

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

            modelBuilder.Entity("BookingApp.Models.RefSeatStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("RefSeatStatus");
                });

            modelBuilder.Entity("BookingApp.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("RefSeatStatusId")
                        .HasColumnType("int");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int?>("SeatPricesSeatTypeNavigationSeatId")
                        .HasColumnType("int");

                    b.Property<int?>("SeatType")
                        .HasColumnType("int");

                    b.Property<string>("SectorNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeatId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("RefSeatStatusId");

                    b.HasIndex("SeatPricesSeatTypeNavigationSeatId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("BookingApp.Models.SeatPrice", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SeatType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeatId");

                    b.HasIndex("EventId");

                    b.ToTable("SeatPrices");
                });

            modelBuilder.Entity("BookingApp.Models.Event", b =>
                {
                    b.HasOne("BookingApp.Models.Place", "Place")
                        .WithMany("Event")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Models.EventType", "TypeNavigation")
                        .WithMany("Event")
                        .HasForeignKey("TypeNavigationTypeId");
                });

            modelBuilder.Entity("BookingApp.Models.Seat", b =>
                {
                    b.HasOne("BookingApp.Models.Place", "Places")
                        .WithMany("Seats")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Models.RefSeatStatus", "RefSeatStatus")
                        .WithMany("Seats")
                        .HasForeignKey("RefSeatStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Models.SeatPrice", "SeatPricesSeatTypeNavigation")
                        .WithMany("Seats")
                        .HasForeignKey("SeatPricesSeatTypeNavigationSeatId");
                });

            modelBuilder.Entity("BookingApp.Models.SeatPrice", b =>
                {
                    b.HasOne("BookingApp.Models.Event", "Event")
                        .WithMany("SeatPrices")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
