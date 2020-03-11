using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetSectorPricesRequest
    {
        public int SectorNumber { get; set; }
        public decimal Price { get; set; }
    }
}
