﻿using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
using Booking.Models.Converters.Interfaces;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters
{
    public class SeatConverter : ISeatConverter
    {
        public Seat CreateSeatRequestToSeat(CreateSeatRequest createSeatRequest)
        {
            return new Seat
            {
                SeatNumber = createSeatRequest.SeatNumber,
                RowNumber = createSeatRequest.RowNumber,
                SectorNumber = createSeatRequest.SectorNumber,
                PlaceId = createSeatRequest.PlaceId,
                SeatType = createSeatRequest.SeatType
            };
        }

        public GetSeatRequest SeatToGetSeatRequest(Seat seat)
        {
            return new GetSeatRequest
            {
                SeatId = seat.SeatId,
                EventDate = seat.EventDate,
                SeatNumber = seat.SeatNumber,
                RowNumber = seat.RowNumber,
                SectorNumber = seat.SectorNumber,
                PlaceId = seat.PlaceId,
                SeatType = seat.SeatType
            };
        }

        public Seat UpdateSeatRequestToSeat(UpdateSeatRequest updateSeatRequest, int seatId)
        {
            return new Seat
            {
                SeatId = seatId,
                EventDate = updateSeatRequest.EventDate,
                SeatNumber = updateSeatRequest.SeatNumber,
                RowNumber = updateSeatRequest.RowNumber,
                SectorNumber = updateSeatRequest.SectorNumber,
                PlaceId = updateSeatRequest.PlaceId,
                SeatType = updateSeatRequest.SeatType
            };
        }
    }
}