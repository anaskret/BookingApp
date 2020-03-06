using System;
using System.Collections.Generic;
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
    }
}
