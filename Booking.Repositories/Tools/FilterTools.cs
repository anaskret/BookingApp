using BookingApp.Data;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booking.Repositories.Tools
{
    public class FilterTools
    {
        public static bool AreIntsCorrect(int? smallerVariable = null, int? biggerVariable = null)
        {
            if (smallerVariable != null && (biggerVariable != null && biggerVariable > smallerVariable))
                return true;
            return false;
        }

        public static int AvailableSeatCount(int eventId, BookingAppContext _dataContext)
        {
            return _dataContext.SeatStatuses.Select(x => x.Available == true && x.EventId == eventId).Count();
        }
    }
}
