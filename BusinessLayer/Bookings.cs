using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Bookings
    {
        public int? EventBookingId { get; set; }
        public string? CustomerName { get; set; }
        public string? MobileNumber { get; set; }
        public int? VenueId { get; set; }
        public string? VenueName { get; set; }
        public DateTime? EventDateTime { get; set; }
        public int? BookedHours { get; set; }

    }
}
