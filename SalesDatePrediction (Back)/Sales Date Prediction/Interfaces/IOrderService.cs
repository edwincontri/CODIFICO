using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId);
        Task AddOrderAsync(PostOrder order, OrderDetail detail);
    }
}
