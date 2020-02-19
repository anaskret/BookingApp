using System;
using System.Collections.Generic;

namespace BookingApp.Models
{
    public partial class Sector
    {
        public Sector()
        {
            Rows = new HashSet<Row>();
        }

        public int PlaceId { get; set; }
        public string SectorNumber { get; set; }
        public int RowsCount { get; set; }

        public virtual Place Place { get; set; }
        public virtual ICollection<Row> Rows { get; set; }
    }
}
