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

        public string AddVenue(Venue venue, string _connectionString)
        {
            string spName = "AddVenue";

            Dictionary<string, string?> param = new Dictionary<string, string?>();
            param.Add("@venueName", venue.VenueName);
            param.Add("@venueDescription", venue.VenueDescription);
            param.Add("@venueCostPerHour", venue.VenueCostPerHour.ToString());

            string response = Db.AddDataToDb(_connectionString, spName, param);

            if (response == "Data Added Successfully")
            {
                response = "Venue Added Successfully";
            }
            return response;
        }

        public string EditVenueById(Venue venue, string _connectionString)
        {
            string spName = "EditVenue";

            Dictionary<string, string?> param = new Dictionary<string, string?>();
            param.Add("@venueId", venue.VenueId.ToString());
            param.Add("@venueName", venue.VenueName);
            param.Add("@venueDescription", venue.VenueDescription);
            param.Add("@venueCostPerHour", venue.VenueCostPerHour.ToString());

            string response = Db.EditDataById(_connectionString, spName, param);

            if (response == "Data Updated Successfully")
            {
                response = "Venue Updated Successfully";
            }
            return response;
        }

        public string DeleteVenue(int venueId, string _connectionString)
        {
            string spName = "DeleteVenue";
            string paramName = "@venueId";
            int Id = venueId;
            string response = Db.DeleteDataFromDb(_connectionString, spName, paramName, Id);

            if (response == "Data Deleted Successfully")
            {
                response = "Venue Deleted Successfully";
            }
            return response;
        }
    }
}
