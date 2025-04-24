using Sales_Date_Prediction.DataContext;
using Sales_Date_Prediction.Interfaces;
using Sales_Date_Prediction.Services;

namespace Sales_Date_Prediction.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPredictionService, PredictionService>();
            return services;
        }
    }
}
