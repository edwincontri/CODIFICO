using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.Interfaces;

namespace Sales_Date_Prediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PredictionController : ControllerBase
    {
        public readonly IPredictionService _predictionService;

        public PredictionController(IPredictionService predictionService)
        {
           _predictionService = predictionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrediction()
        {
            var predictedOrder = await _predictionService.GetPredictedOrdersAsync();
            return Ok(predictedOrder);
        }
    }
}
