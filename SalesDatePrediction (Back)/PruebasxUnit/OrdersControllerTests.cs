using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales_Date_Prediction.Controllers;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;

namespace PruebasxUnit
{
    public class OrdersControllerTests
    {
        [Fact]
        public async Task GetOrders_ok()
        {
            var mockService = new Mock<IOrderService>();

            var clientId = 1;

            var fakeOrders = new List<Order>
            {
                new Order
                {
                    OrderId = 101,
                    RequiredDate = DateTime.Today,
                    ShippedDate = DateTime.Today,
                    ShipName = "Ship to 85-B",
                    ShipAddress = "6789 rue de l'Abbaye",
                    ShipCity = "Reims"
                }
            };

            mockService.Setup(s => s.GetOrdersByClientIdAsync(clientId)).ReturnsAsync(fakeOrders);

            var controller = new OrdersController(mockService.Object);

            var result = await controller.GetOrdersByClient(clientId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var orders = Assert.IsAssignableFrom<IEnumerable<Order>>(okResult.Value);
            Assert.Single(orders);

        }

        [Fact]
        public async Task CreateOrder_ok()
        {            
            var mockService = new Mock<IOrderService>();

            var request = new CreateOrderRequest
            {
                PostOrder = new PostOrder
                {
                    empid = 1,
                    orderdate = DateTime.Today,
                    requireddate = DateTime.Today,
                    shippeddate = DateTime.Today,
                    shipperid = 0,
                    freight = 0,
                    shipname = "string",
                    shipaddress = "string",
                    shipcity = "string",
                    shipcountry = "string"
                },
                Detail = new OrderDetail
                {
                    OrderId = 0,
                    ProductId = 0,
                    UnitPrice = 0,
                    Qty = 0,
                    Discount = 0                    
                }
            };

            mockService.Setup(s => s.AddOrderAsync(request.PostOrder, request.Detail))
                       .Returns(Task.CompletedTask);

            var controller = new OrdersController(mockService.Object);

            var result = await controller.CreateOrder(request);
                        
            Assert.IsType<OkResult>(result);
        }
    }
}
