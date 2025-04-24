using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetOrdersByClient(int clientId)
        {
            var orders = await _orderService.GetOrdersByClientIdAsync(clientId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var order = request.PostOrder;
            var detail = request.Detail;

            await _orderService.AddOrderAsync(order, detail);
            return Ok();
        }
    }
}
