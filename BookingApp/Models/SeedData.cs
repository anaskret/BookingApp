using BookingApp.Data;
using BookingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.App.Models
{
    public class SeedData
    {
        public static void InitializeTypes(IServiceProvider serviceProvider)
        {
            using var context = Context(serviceProvider);
            if (context.EventTypes.Any())
            {
                return;
            }

            context.EventTypes.AddRange(
                new EventType
                {
                    Type = "Football Match"
                },

                new EventType
                {
                    Type = "Basketball Match"
                },

                new EventType
                {
                    Type = "Concert"
                },

                new EventType
                {
                    Type = "Party"
                },

                new EventType
                {
                    Type = "Art"
                },

                new EventType
                {
                    Type = "Convention"
                }
                );
            context.SaveChanges();
        }

        public static void InitializePlaces(IServiceProvider serviceProvider)
        {
            using var context = Context(serviceProvider);
            if (context.EventTypes.Any())
            {
                return;
            }
            context.Places.AddRange(
                new Place
                {
                    Name = "Emirates Stadium",
                    MaximumCapacity = 65000
                },

                new Place
                {
                    Name = "Stamford Bridge",
                    MaximumCapacity = 55000
                },

                new Place
                {
                    Name = "Anfield",
                    MaximumCapacity = 50000
                },

                new Place
                {
                    Name = "Międzynarodowe Targi Poznańskie",
                    MaximumCapacity = 20000
                },

                new Place
                {
                    Name = "Santiago Bernabeu",
                    MaximumCapacity = 70000
                },

                new Place
                {
                    Name = "Camp Nou",
                    MaximumCapacity = 40000
                }
                );
            context.SaveChanges();
        }

        public static void InitializeEvents(IServiceProvider serviceProvider)
        {
            using var context = Context(serviceProvider);
            if (context.EventTypes.Any())
            {
                return;
            }
            context.Events.AddRange(
                new Event
                {
                    Name = "Arsenal - Tottenham",
                    Date = new DateTime(2020, 04, 25),
                    Description = "Tottenham will travel to Emirates Stadium to try and defeat the better club",
                    PlaceId = 1,
                    Type = "Football Match"
                }
                );
        }

        public static void InitializeSeatPrice(IServiceProvider serviceProvider)
        {
            using var context = Context(serviceProvider);
            if (context.EventTypes.Any())
            {
                return;
            }
            context.SeatPrices.AddRange(
                new SeatPrice
                {
                    SeatType = "VIP",
                    Price = 50,
                    EventId = 1
                }
                );
        }

        public static void InitializeSectors(IServiceProvider serviceProvider)
        {
            using var context = Context(serviceProvider);
            if (context.EventTypes.Any())
            {
                return;
            }
            context.Sectors.AddRange(
                new Sector
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowsCount = 10
                },

                new Sector
                {
                    PlaceId = 1,
                    SectorNumber = "A2",
                    RowsCount = 10
                },

                new Sector
                {
                    PlaceId = 1,
                    SectorNumber = "A3",
                    RowsCount = 10
                },

                new Sector
                {
                    PlaceId = 1,
                    SectorNumber = "A4",
                    RowsCount = 10
                },

                new Sector
                {
                    PlaceId = 1,
                    SectorNumber = "A5",
                    RowsCount = 10
                },

                new Sector
                {
                    PlaceId = 1,
                    SectorNumber = "B1",
                    RowsCount = 10
                },

                new Sector
                {
                    PlaceId = 1,
                    SectorNumber = "B2",
                    RowsCount = 10
                },

                new Sector
                {
                    PlaceId = 1,
                    SectorNumber = "B3",
                    RowsCount = 10
                },

                new Sector
                {
                    PlaceId = 1,
                    SectorNumber = "B4",
                    RowsCount = 10
                },

                new Sector
                {
                    PlaceId = 1,
                    SectorNumber = "B5",
                    RowsCount = 10
                }
                );  
            context.SaveChanges();
        }

        public static void InitializeRows(IServiceProvider serviceProvider)
        {
            using var context = Context(serviceProvider);
            if (context.EventTypes.Any())
            {
                return;
            }
            context.Rows.AddRange(
                new Row
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatCount = 20,
                },

                new Row
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 2,
                    SeatCount = 20,
                },

                new Row
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 3,
                    SeatCount = 20,
                },

                new Row
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 4,
                    SeatCount = 20,
                },

                new Row
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 5,
                    SeatCount = 20,
                },

                new Row
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 6,
                    SeatCount = 20,
                }
                );
            context.SaveChanges();
        }

        public static void InitializeSeats(IServiceProvider serviceProvider)
        {
            using var context = Context(serviceProvider);
            if (context.EventTypes.Any())
            {
                return;
            }
            context.Seats.AddRange(
                new Seat
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatNumber = 1,
                    SeatType = "VIP",
                    RefSeatStatusId = 1
                },new Seat
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatNumber = 2,
                    SeatType = "VIP",
                    RefSeatStatusId = 1
                },new Seat
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatNumber = 3,
                    SeatType = "VIP",
                    RefSeatStatusId = 1
                },new Seat
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatNumber = 4,
                    SeatType = "VIP",
                    RefSeatStatusId = 1
                },new Seat
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatNumber = 5,
                    SeatType = "VIP",
                    RefSeatStatusId = 1
                },new Seat
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatNumber = 6,
                    SeatType = "VIP",
                    RefSeatStatusId = 1
                },new Seat
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatNumber = 7,
                    SeatType = "VIP",
                    RefSeatStatusId = 1
                },new Seat
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatNumber = 8,
                    SeatType = "VIP",
                    RefSeatStatusId = 1
                },new Seat
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatNumber = 9,
                    SeatType = "VIP",
                    RefSeatStatusId = 1
                },new Seat
                {
                    PlaceId = 1,
                    SectorNumber = "A1",
                    RowNumber = 1,
                    SeatNumber = 10,
                    SeatType = "VIP",
                    RefSeatStatusId = 1
                }
                );
            context.SaveChanges();
        }

        public static void InitializeSeatStatus(IServiceProvider serviceProvider)
        {
            using var context = Context(serviceProvider);
            if (context.EventTypes.Any())
            {
                return;
            }
            context.RefSeatStatus.AddRange(
                new RefSeatStatus
                {
                    StatusId = 1,
                    StatusDescription = "Available"
                },

                new RefSeatStatus
                {
                    StatusId = 2,
                    StatusDescription = "Booked"
                }
                );
        }

        static BookingAppContext Context(IServiceProvider serviceProvider)
        {
            var context = new BookingAppContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<BookingAppContext>>());
            return context;
        }
    }
}
