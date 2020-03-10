using Booking.Models.Models;
using BookingApp.Data;
using BookingApp.Models;
using Microsoft.Data.SqlClient;
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
        private readonly BookingAppContext _context;

        public SeedData(BookingAppContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            InitializeTypes();
            InitializePlaces();
            InitializeSeatTypes();
            InitializeSeats();
            InitializeEvents();
            InitializeSeatPrice();
            InitializeSeatStatus();
        }
        public void InitializeTypes()
        {
            if (_context.EventTypes.Any())
            {
                return;
            }

            _context.EventTypes.AddRange(
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
            _context.SaveChanges();
        }

        public void InitializePlaces()
        {
            if (_context.Places.Any())
            {
                return;
            }
            _context.Places.AddRange(
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
            _context.SaveChanges();
        }

        public void InitializeEvents()
        {
            if (_context.Events.Any())
            {
                return;
            }
            _context.Events.AddRange(
                new Event
                {
                    Name = "Arsenal - Tottenham",
                    Date = new DateTime(2020, 04, 25),
                    NumberOfSeats = 60000,
                    Description = "Tottenham will travel to Emirates Stadium to try and defeat the better club",
                    PlaceId = 1,
                    TypeId = 1
                });
            _context.SaveChanges();
        }

        public void InitializeSeatTypes()
        {
            
            if (_context.SeatTypes.Any())
            {
                return;
            }
            _context.SeatTypes.AddRange(
                new SeatType
                {
                    Type = "Economic"
                },
                new SeatType
                {
                    Type = "VIP"
                });
            _context.SaveChanges();
        }

        public void InitializeSeats()
        {
            if (_context.Seats.Any())
            {
                return;
            }

            _context.Seats.AddRange(
                new Seat
                {
                    PlaceId = 1,
                    SectorNumber = 1,
                    RowNumber = 1,
                    SeatNumber = 1,
                    TypeId = 1
                }, new Seat
                {
                    PlaceId = 1,
                    SectorNumber = 1,
                    RowNumber = 1,
                    SeatNumber = 2,
                    TypeId = 1
                }, new Seat
                {
                    PlaceId = 1,
                    SectorNumber = 1,
                    RowNumber = 1,
                    SeatNumber = 3,
                    TypeId = 1
                }, new Seat
                {
                    PlaceId = 1,
                    SectorNumber = 1,
                    RowNumber = 1,
                    SeatNumber = 4,
                    TypeId = 1
                }, new Seat
                {
                    PlaceId = 1,
                    SectorNumber = 1,
                    RowNumber = 1,
                    SeatNumber = 5,
                    TypeId = 1
                }, new Seat
                {
                    PlaceId = 1,
                    SectorNumber = 1,
                    RowNumber = 1,
                    SeatNumber = 6,
                    TypeId = 2
                }, new Seat
                {
                    PlaceId = 1,
                    SectorNumber = 1,
                    RowNumber = 1,
                    SeatNumber = 7,
                    TypeId = 2
                }, new Seat
                {
                    PlaceId = 1,
                    SectorNumber = 1,
                    RowNumber = 1,
                    SeatNumber = 8,
                    TypeId = 2
                }, new Seat
                {
                    PlaceId = 1,
                    SectorNumber = 1,
                    RowNumber = 1,
                    SeatNumber = 9,
                    TypeId = 2
                }, new Seat
                {
                    PlaceId = 1,
                    SectorNumber = 1,
                    RowNumber = 1,
                    SeatNumber = 10,
                    TypeId = 2
                }
                );
            _context.SaveChanges();
        }

        public void InitializeSeatPrice()
        {
            if (_context.SectorPrices.Any())
            {
                return;
            }
            _context.SectorPrices.AddRange(
                new SectorPrice
                {
                    Price = 50,
                    EventId = 1,
                    SectorNumber = 1
                }
                );
            _context.SaveChanges();
        }

        public void InitializeSeatStatus()
        {
            if (_context.SeatStatuses.Any())
            {
                return;
            }

            _context.SeatStatuses.AddRange(
                new SeatStatus
                {
                    Available = false,
                    SeatId = 1,
                    EventId = 1,
                    PriceId = 1
                },

                new SeatStatus
                {
                    SeatId = 1,
                    EventId = 1,
                    PriceId = 1
                },

                new SeatStatus
                {
                    SeatId = 1,
                    EventId = 1,
                    PriceId = 1
                },

                new SeatStatus
                {
                    SeatId = 1,
                    EventId = 1,
                    PriceId = 1
                }
                );
            var saved = _context.SaveChanges();
        }

        /* public static void InitializeSectors(IServiceProvider serviceProvider)
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
*/
    }
}
