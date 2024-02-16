using BusinessObjects;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationObjects
{
    public class BookingsImplementation
    {
        private readonly string _connectionString;
        public BookingsImplementation(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Bookings> GetBookingsDetails()
        {
            BookingsDAO bookingsDAO = new BookingsDAO();
            List<Bookings> bookingsList = bookingsDAO.GetBookingsDetails(_connectionString);

            return bookingsList;
        }
    }
}
