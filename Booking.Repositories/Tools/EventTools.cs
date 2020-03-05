using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Repositories.Tools
{
    public class EventTools
    {
        public static bool IsIntNotNull(int smallerVariable, int biggerVariable)
        {
            if (smallerVariable > 0 && (biggerVariable > 0 && biggerVariable > smallerVariable))
                return true;
            return false;
        }
    }
}
