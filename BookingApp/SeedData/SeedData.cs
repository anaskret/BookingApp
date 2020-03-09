using Booking.Models.Models;
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
        public static void Initialize(IServiceProvider serviceProvider)
        {
            InitializeTypes(serviceProvider);
            InitializePlaces(serviceProvider);
            InitializeSeatTypes(serviceProvider);
            InitializeSeats(serviceProvider);
            InitializeEvents(serviceProvider);
            InitializeSeatPrice(serviceProvider);
            InitializeSeatStatus(serviceProvider);
        }
        public static void InitializeTypes(IServiceProvider serviceProvider)
        {
            using (var context = Context(serviceProvider))
            {
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
        }

        public static void InitializePlaces(IServiceProvider serviceProvider)
        {
            using (var context = Context(serviceProvider))
            {
                if (context.Places.Any())
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
        }

        public static void InitializeEvents(IServiceProvider serviceProvider)
        {
            using (var context = Context(serviceProvider))
            {
                if (context.Events.Any())
                {
                    return;
                }
                context.Events.AddRange(
                    new Event
                    {
                        Name = "Arsenal - Tottenham",
                        Date = new DateTime(2020, 04, 25),
                        NumberOfSeats = 60000,
                        Description = "Tottenham will travel to Emirates Stadium to try and defeat the better club",
                        PlaceId = 1,
                        TypeId = 1
                    });
                context.SaveChanges();
            }
        }

        public static void InitializeSeatTypes(IServiceProvider serviceProvider)
        {
            using (var context = Context(serviceProvider))
            {
                if (context.SeatTypes.Any())
                {
                    return;
                }
                context.SeatTypes.AddRange(
                    new SeatType
                    {
                        Type = "VIP"
                    },
                    new SeatType
                    {
                        Type = "Economic"
                    });
                context.SaveChanges();
            }
        }

        public static void InitializeSeats(IServiceProvider serviceProvider)
        {
            using (var context = Context(serviceProvider))
            {
                if (context.Seats.Any())
                {
                    return;
                }
                context.Seats.AddRange(
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
                        TypeId = 1
                    }, new Seat
                    {
                        PlaceId = 1,
                        SectorNumber = 1,
                        RowNumber = 1,
                        SeatNumber = 7,
                        TypeId = 1
                    }, new Seat
                    {
                        PlaceId = 1,
                        SectorNumber = 1,
                        RowNumber = 1,
                        SeatNumber = 8,
                        TypeId = 1
                    }, new Seat
                    {
                        PlaceId = 1,
                        SectorNumber = 1,
                        RowNumber = 1,
                        SeatNumber = 9,
                        TypeId = 1
                    }, new Seat
                    {
                        PlaceId = 1,
                        SectorNumber = 1,
                        RowNumber = 1,
                        SeatNumber = 10,
                        TypeId = 1
                    }
                    );
                context.SaveChanges();
            }
        }

        public static void InitializeSeatPrice(IServiceProvider serviceProvider)
        {
            using (var context = Context(serviceProvider))
            {
                if (context.SectorPrices.Any())
                {
                    return;
                }
                context.SectorPrices.AddRange(
                    new SectorPrice
                    {
                        Price = 50,
                        EventId = 1,
                        SectorNumber = 1
                    }
                    );
                context.SaveChanges();
            }
        }

        public static void InitializeSeatStatus(IServiceProvider serviceProvider)
        {
            using (var context = Context(serviceProvider))
            {
                if (context.SeatStatuses.Any())
                {
                    return;
                }
                context.SeatStatuses.AddRange(
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
                var saved = context.SaveChanges();
            }
        }

        static BookingAppContext Context(IServiceProvider serviceProvider)
        {
            var context = new BookingAppContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<BookingAppContext>>());
            return context;
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
