using Booking.Models.Contracts.Requests.GetRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters.Interfaces
{
    public interface ISectorPriceConverter
    {
        GetSectorPricesRequest SectorPriceToGetSectorPricesResponse(SectorPrice sectorPrice);
    }
}
