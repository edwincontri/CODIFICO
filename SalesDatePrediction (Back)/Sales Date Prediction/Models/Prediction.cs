namespace Sales_Date_Prediction.Models
{
    public class Prediction
    {
        public int custid { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
