using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.Interfaces;

namespace Sales_Date_Prediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperService _shipperService;
        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shippers = await _shipperService.GetAllAsync();
            return Ok(shippers);
        }
    }
}
