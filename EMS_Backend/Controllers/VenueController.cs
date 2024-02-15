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

    }
}
