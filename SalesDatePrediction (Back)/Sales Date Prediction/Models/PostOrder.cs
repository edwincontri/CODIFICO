namespace Sales_Date_Prediction.Models
{
    public class PostOrder
    {
        public int custid { get; set; }
        public int empid { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime shippeddate { get; set; }
        public int shipperid { get; set; }
        public int freight { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
        public string shipcountry { get; set; }
    }
}
