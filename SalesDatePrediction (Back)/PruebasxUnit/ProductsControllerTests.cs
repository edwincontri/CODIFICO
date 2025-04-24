using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales_Date_Prediction.Controllers;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;

namespace PruebasxUnit
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task GetProductListOk()
        {            
            var mockService = new Mock<IProductService>();
            var fakeProducts = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Product HHYDP"},
                new Product { ProductId = 2, ProductName = "Product RECZE"}
            };

            mockService.Setup(s => s.GetAllAsync())
                       .ReturnsAsync(fakeProducts);

            var controller = new ProductsController(mockService.Object);
                        
            var result = await controller.GetAll();
                        
            var okResult = Assert.IsType<OkObjectResult>(result);
            var products = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal(2, ((List<Product>)products).Count);
        }
    }
}
