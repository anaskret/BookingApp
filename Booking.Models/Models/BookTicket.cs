﻿using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Booking.Models.Models
{
    public class BookTicket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Ticket Id")]
        public Guid TicketId { get; set; }

        [EmailAddress]
        public string Email { get;set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Status Id")]
        public int StatusId { get; set; }

        public string SeatCoordinates()
        {
            return $"Sector: {SeatStatus.Seat.SectorNumber}, Row: {SeatStatus.Seat.RowNumber}, Seat: {SeatStatus.Seat.SeatNumber}";
        }

        public DateTime EventDate()
        {
            return SeatStatus.Event.Date;
        }

        public virtual SeatStatus SeatStatus { get; set; } 
    }
}
