using Dapper;
using Sales_Date_Prediction.DataContext;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;
using System.Data;

namespace Sales_Date_Prediction.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly DapperContext _dapperContext;
        public EmployeeService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        } 

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using IDbConnection _connection = _dapperContext.CreateConnection();

            var sql = "SELECT EmpId, FirstName + ' ' + LastName AS FullName FROM [HR].[Employees]";
            return await _connection.QueryAsync<Employee>(sql);
        }
    }
}
