using BusinessLayer;
using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class VenueDAO
    {
        public List<Venue> GetVenueDetails(string _connectionString)
        {
            DataSet ds = new DataSet();

            try
            {
                string spName = "GetVenues";
                ds = Db.Get(_connectionString, spName);
                List<Venue> venueList = new List<Venue>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Venue venue = new Venue();
                    venue.VenueId = Convert.ToInt32(dr["VenueId"]);
                    venue.VenueName = dr["VenueName"].ToString();
                    venue.VenueDescription = dr["VenueDescription"].ToString();
                    venue.VenueCostPerHour = Convert.ToInt32(dr["VenueCostPerHour"]);

                    venueList.Add(venue);
                }

                return venueList;
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
