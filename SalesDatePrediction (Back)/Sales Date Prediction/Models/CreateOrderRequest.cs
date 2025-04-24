namespace Sales_Date_Prediction.Models
{
    public class CreateOrderRequest
    {
        public PostOrder PostOrder { get; set; }
        public OrderDetail Detail { get; set; }
    }
}
