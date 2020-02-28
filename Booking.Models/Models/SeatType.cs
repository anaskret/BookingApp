using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Booking.Models.Models
{
    [Table("SeatTypes")]
    public class SeatType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatTypeId { get; set; }
        public string Type { get; set; }
    }
}
