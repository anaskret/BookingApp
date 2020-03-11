using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
using Booking.Models.Converters.Interfaces;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters
{
    public class SectorPriceConverter : ISectorPriceConverter
    {
        public GetSectorPricesRequest SectorPriceToGetSectorPricesResponse(SectorPrice sectorPrice)
        {
            return new GetSectorPricesRequest
            {
                SectorNumber = sectorPrice.SectorNumber,
                Price = sectorPrice.Price
            };
        }
    }
}
