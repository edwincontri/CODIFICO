using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales_Date_Prediction.Controllers;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;

namespace PruebasxUnit
{
    public class EmployeesControllerTests
    {
        [Fact]
        public async Task GetEmployeeOk()
        {            
            var mockService = new Mock<IEmployeeService>();
            var fakeEmployees = new List<Employee>
            {
                new Employee { EmpId = 1, FullName = "Sara Davis"},
                new Employee { EmpId = 2, FullName = "Don Funk"}
            };

            mockService.Setup(s => s.GetAllAsync())
                       .ReturnsAsync(fakeEmployees);

            var controller = new EmployeesController(mockService.Object);
                        
            var result = await controller.GetAll();
                        
            var okResult = Assert.IsType<OkObjectResult>(result);
            var employees = Assert.IsAssignableFrom<IEnumerable<Employee>>(okResult.Value);
            Assert.Equal(2, ((List<Employee>)employees).Count);
        }
    }
}
