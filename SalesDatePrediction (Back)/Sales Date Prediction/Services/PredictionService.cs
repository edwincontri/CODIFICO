using Dapper;
using Sales_Date_Prediction.DataContext;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Models;
using System.Data;

namespace Sales_Date_Prediction.Services
{
    public class PredictionService : IPredictionService
    {
        public readonly DapperContext _dappercontext;
        public PredictionService(DapperContext dapperContext)
        {
            _dappercontext = dapperContext;
        }

        public async Task<IEnumerable<Prediction>> GetPredictedOrdersAsync()
        {
            using IDbConnection _connection = _dappercontext.CreateConnection();

            string sql = @"SELECT
                                c.custid, c.companyname AS CustomerName,
                                u.ultima_fecha AS LastOrderDate,
                                DATEADD(DAY, p.promedio_dias, u.ultima_fecha) AS NextPredictedOrder
                            FROM (
                                SELECT
                                    custid,
                                    MAX(orderdate) AS ultima_fecha
                                FROM Sales.Orders
                                WHERE custid IS NOT NULL
                                GROUP BY custid
                            ) u
                            JOIN (
                                SELECT
                                    custid,
                                    AVG(dias * 1.0) AS promedio_dias
                                FROM (
                                    SELECT
                                        custid,
                                        DATEDIFF(DAY, 
                                                 LAG(orderdate) OVER (PARTITION BY custid ORDER BY orderdate), 
                                                 orderdate) AS dias
                                    FROM Sales.Orders
                                    WHERE custid IS NOT NULL
                                ) sub
                                WHERE dias IS NOT NULL
                                GROUP BY custid
                            ) p ON u.custid = p.custid
                            JOIN Sales.Customers c ON u.custid = c.custid";

            return await _connection.QueryAsync<Prediction>(sql);

        }
    }
}
