namespace DB_Backend.DB_BackendModel
{
    public class OrderListModel
    {
        public string Order_id { get; set; } = string.Empty;
        public string User_id { get; set; } = string.Empty;
        public string Train_id { get; set; } = string.Empty;
        public string Order_status { get; set; } = string.Empty;
        public double Price { get; set; }
        public string passenger_id { get; set; } = string.Empty;
        public string ticket_type { get; set; } = string.Empty;
    }
}
