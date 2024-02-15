using BusinessLayer;
using BusinessObjects;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationObjects
{
    public class VenueImplementation
    {
        private readonly string _connectionString;
        public VenueImplementation(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Venue> GetVenueDetails()
        {
            VenueDAO venueDAO = new VenueDAO();
            List<Venue> venueList = venueDAO.GetVenueDetails(_connectionString);

            return venueList;
        }
    }
}
