using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales_Date_Prediction.Controllers;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;

namespace PruebasxUnit
{
    public class ShippersControllerTests
    {
        [Fact]
        public async Task GetShipperListOk()
        {            
            var mockService = new Mock<IShipperService>();
            var fakeShippers = new List<Shipper>
            {
                new Shipper { ShipperId = 1, CompanyName = "Shipper GVSUA"},
                new Shipper { ShipperId = 2, CompanyName = "Shipper ETYNR"}
            };

            mockService.Setup(s => s.GetAllAsync())
                       .ReturnsAsync(fakeShippers);

            var controller = new ShippersController(mockService.Object);
                        
            var result = await controller.GetAll();
                        
            var okResult = Assert.IsType<OkObjectResult>(result);
            var shippers = Assert.IsAssignableFrom<IEnumerable<Shipper>>(okResult.Value);
            Assert.Equal(2, ((List<Shipper>)shippers).Count);
        }
    }
}
