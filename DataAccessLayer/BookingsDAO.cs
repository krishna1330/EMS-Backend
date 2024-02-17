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
    public class BookingsDAO
    {
        public List<Bookings> GetBookingsDetails(string _connectionString)
        {
            DataSet ds = new DataSet();

            try
            {
                string spName = "GetBookings";
                ds = Db.Get(_connectionString, spName);
                List<Bookings> bookingsList = new List<Bookings>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Bookings bookings = new Bookings();
                    bookings.EventBookingId = Convert.ToInt32(dr["EventBookingId"]);
                    bookings.CustomerName = dr["CustomerName"].ToString();
                    bookings.MobileNumber = dr["MobileNumber"].ToString();
                    bookings.VenueId = Convert.ToInt32(dr["VenueId"]);
                    bookings.VenueName = dr["VenueName"].ToString();
                    bookings.EventDateTime = dr["EventDateTime"].ToString();
                    bookings.BookedHours = Convert.ToInt32(dr["BookedHours"]);

                    bookingsList.Add(bookings);
                }

                return bookingsList;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public string AddBooking(Bookings bookings, string _connectionString)
        {
            string spName = "AddBooking";

            Dictionary<string, string?> param = new Dictionary<string, string?>();
            param.Add("@customerName", bookings.CustomerName);
            param.Add("@mobileNumber", bookings.MobileNumber);
            param.Add("@venueId", bookings.VenueId.ToString());
            param.Add("@eventDateTime", bookings.EventDateTime.ToString() + ":00");
            param.Add("@bookedHours", bookings.BookedHours.ToString());

            string response = Db.AddDataToDb(_connectionString, spName, param);

            if (response == "Data Added Successfully")
            {
                response = "Booking Added Successfully";
            }
            return response;
        }
    }
}
