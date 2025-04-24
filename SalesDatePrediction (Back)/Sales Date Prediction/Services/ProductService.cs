using Dapper;
using Sales_Date_Prediction.DataContext;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;
using System.Data;

namespace Sales_Date_Prediction.Services
{
    public class ProductService : IProductService
    {
        public readonly DapperContext _dappercontext;

        public ProductService(DapperContext dapperContext)
        {
            _dappercontext = dapperContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using IDbConnection _connection = _dappercontext.CreateConnection();

            return await _connection.QueryAsync<Product>("SELECT ProductId, ProductName FROM [Production].[Products]");
        }
    }
}
