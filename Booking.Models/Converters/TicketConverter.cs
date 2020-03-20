using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Converters.Interfaces;
using Booking.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters
{
    public class BookingConverter : IBookingConverter
    {
        public Booking CreateBookingRequestToBooking(CreateBookingRequest Booking)
        {
            return new Booking
            {
                Email = Booking.Email,
                StatusId = Booking.StatusId
            };
        }

        public GetBookingRequest BookingToGetBookingRequest(Booking Booking)
        {
            return new GetBookingRequest
            {
                BookingId = Booking.BookingId,
                Email = Booking.Email,
                BookingDate = Booking.BookingDate,
                StatusId = Booking.StatusId,
                SeatCoordinates = Booking.SeatCoordinates(),
                EventDate = Booking.EventDate(),
                Price = Booking.Price()
            };
        }
    }
}
