using Dapper;
using Sales_Date_Prediction.DataContext;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;
using System.Data;

namespace Sales_Date_Prediction.Services
{
    public class ShipperService : IShipperService
    {
        public readonly DapperContext _dapperContext;
        public ShipperService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Shipper>> GetAllAsync()
        {
            using IDbConnection _connection = _dapperContext.CreateConnection();

            string sql = @"SELECT ShipperId, CompanyName FROM [Sales].[Shippers]";

            return await _connection.QueryAsync<Shipper>(sql);
        }
    }
}
