using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
