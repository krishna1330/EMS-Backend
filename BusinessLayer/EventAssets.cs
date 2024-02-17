using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class EventAssets
    {
        public int? EventAssetId { get; set; }
        public int? EventBookingId { get; set; }
        public int? AssetId { get; set; }
        public int? Quantity { get; set; }
    }
}
