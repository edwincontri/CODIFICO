using Dapper;
using Sales_Date_Prediction.DataContext;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;
using System.Data;

namespace Sales_Date_Prediction.Services
{
    public class OrderService : IOrderService
    {
        public readonly DapperContext _dapperContext;
        public OrderService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId)
        {
            using IDbConnection _connection = _dapperContext.CreateConnection();

            var sql = @"SELECT OrderId, RequiredDate, ShippedDate, ShipName, ShipAddress, ShipCity 
                        FROM [Sales].[Orders] WHERE custid = @ClientId";
            return await _connection.QueryAsync<Order>(sql, new { ClientId = clientId });
        }

        public async Task AddOrderAsync(PostOrder order, OrderDetail detail)
        {
            using IDbConnection _connection = _dapperContext.CreateConnection();

            _connection.Open();

            using var tran = _connection.BeginTransaction();
            try
            {
                string sql = @"INSERT INTO [Sales].[Orders] (Custid, EmpId, ShipperId, ShipName, ShipAddress, ShipCity, OrderDate, RequiredDate, ShippedDate, Freight, ShipCountry)
                               OUTPUT INSERTED.OrderId
                               VALUES (@Custid, @EmpId, @ShipperId, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry)";

                var orderId = await _connection.ExecuteScalarAsync<int>(sql, order, tran);

                detail.OrderId = orderId;

                string sqldet = @"INSERT INTO [Sales].[OrderDetails] (OrderId, ProductId, UnitPrice, Qty, Discount)
                                  VALUES (@OrderId, @ProductId, @UnitPrice, @Qty, @Discount)";

                await _connection.ExecuteAsync(sqldet, detail, tran);

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }
    }
}
