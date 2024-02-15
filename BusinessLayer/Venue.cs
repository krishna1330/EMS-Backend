using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Venue
    {
        public int? VenueId { get; set; }
        public string? VenueName { get; set; }
        public string? VenueDescription { get; set; }
        public int? VenueCostPerHour { get; set; }
    }
}
