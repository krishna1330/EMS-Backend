using BusinessLayer;
using ImplementationObjects;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly string _connectionString;

        public AssetsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SQLConnection") ?? throw new InvalidOperationException("Connection string cannot be null or whitespace");

        }

        [HttpGet("GetAssets")]
        public IActionResult GetAssetsDetails()
        {
            try
            {
                AssetsImplementation assetsImplementation = new AssetsImplementation(_connectionString);
                List<Assets> assetsList = assetsImplementation.GetAssetsDetails();

                return Ok(assetsList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost("EditAsset")]
        public IActionResult EditAsset(Assets assets)
        {
            try
            {
                AssetsImplementation assetsImplementation = new AssetsImplementation(_connectionString);
                string response = assetsImplementation.EditAssetById(assets);
                return Ok(new { Message = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost("AddAsset")]
        public IActionResult AddAsset(Assets assets)
        {
            try
            {
                AssetsImplementation assetsImplementation = new AssetsImplementation(_connectionString);
                string response = assetsImplementation.AddAsset(assets);
                return Ok(new { Message = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpDelete("DeleteAsset")]
        public IActionResult DeleteAsset(int assetId)
        {
            try
            {
                AssetsImplementation assetsImplementation = new AssetsImplementation(_connectionString);
                string response = assetsImplementation.DeleteAsset(assetId);
                return Ok(new { Message = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
