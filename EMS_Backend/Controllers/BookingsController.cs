using BusinessObjects;
using ImplementationObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly string _connectionString;
        public BookingsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SQLConnection") ?? throw new InvalidOperationException("Connection string cannot be null or whitespace");
        }
        [HttpGet("GetBookingsDetails")]
        public IActionResult GetVenueDetails()
        {
            try
            {
                BookingsImplementation bookingsImplementation = new BookingsImplementation(_connectionString);
                List<Bookings> bookingsList = bookingsImplementation.GetBookingsDetails();

                return Ok(bookingsList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost("AddBooking")]
        public IActionResult AddBooking(Bookings bookings)
        {
            try
            {
                BookingsImplementation bookingsImplementation = new BookingsImplementation(_connectionString);
                string response = bookingsImplementation.AddBooking(bookings);
                return Ok(new { Message = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost("AddEventAsset")]
        public IActionResult AddEventAsset(EventAssets eventAssets)
        {
            try
            {
                BookingsImplementation bookingsImplementation = new BookingsImplementation(_connectionString);
                string response = bookingsImplementation.AddEventAsset(eventAssets);
                return Ok(new { Message = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
