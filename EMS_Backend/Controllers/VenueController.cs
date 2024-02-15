using BusinessLayer;
using BusinessObjects;
using ImplementationObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly string _connectionString;
        public VenueController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SQLConnection") ?? throw new InvalidOperationException("Connection string cannot be null or whitespace");
        }

        [HttpGet("GetAllVenueDetails")]
        public IActionResult GetVenueDetails()
        {
            try
            {
                VenueImplementation venueImplementation = new VenueImplementation(_connectionString);
                List<Venue> venueList = venueImplementation.GetVenueDetails();

                return Ok(venueList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost("AddVenue")]
        public IActionResult AddVenue(Venue venue)
        {
            try
            {
                VenueImplementation venueImplementation = new VenueImplementation(_connectionString);
                string response = venueImplementation.AddVenue(venue);
                return Ok(new { Message = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost("EditVenue")]
        public IActionResult EditVenue(Venue venue)
        {
            try
            {
                VenueImplementation venueImplementation = new VenueImplementation(_connectionString);
                string response = venueImplementation.EditVenueById(venue);
                return Ok(new { Message = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpDelete("DeleteVenue")]
        public IActionResult DeleteVenue(int venueId)
        {
            try
            {
                VenueImplementation venueImplementation = new VenueImplementation(_connectionString);
                string response = venueImplementation.DeleteVenue(venueId);
                return Ok(new { Message = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
