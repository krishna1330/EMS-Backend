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

        public string AddVenue(Venue venue)
        {
            VenueDAO venueDAO = new VenueDAO();
            string response = venueDAO.AddVenue(venue, _connectionString);

            return response;
        }

        public string EditVenueById(Venue venue)
        {
            VenueDAO venueDAO = new VenueDAO();
            string response = venueDAO.EditVenueById(venue, _connectionString);

            return response;
        }

        public string DeleteVenue(int venueId)
        {
            VenueDAO venueDAO = new VenueDAO();
            string response = venueDAO.DeleteVenue(venueId, _connectionString);

            return response;
        }
    }
}
