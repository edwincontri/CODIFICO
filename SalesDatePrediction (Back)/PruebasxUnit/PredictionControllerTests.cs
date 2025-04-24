using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales_Date_Prediction.Controllers;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;

namespace PruebasxUnit
{
    public class PredictionControllerTests
    {
        [Fact]
        public async Task GetPrediction_ok()
        {
            var mockService = new Mock<IPredictionService>();

            var fakePrediction = new List<Prediction>
            {
                new Prediction
                {
                    CustomerName = "Test",
                    LastOrderDate = DateTime.Today.AddDays(-20),
                    NextPredictedOrder = DateTime.Today.AddDays(10)
                }
            };

            mockService.Setup(s => s.GetPredictedOrdersAsync()).ReturnsAsync(fakePrediction);

            var controller = new PredictionController(mockService.Object);

            var result = await controller.GetPrediction();

            var okRsult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<Prediction>>(okRsult.Value);
            Assert.Single(data);
        }
    }
}