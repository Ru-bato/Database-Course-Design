using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB_Backend.DB_BackendModel
{
    public class MyTicket
    {
        [Key][Column("ORDER_ID")] public string? Order_id { get; set; }
        [Column("USER_ID")] public string? User_id { get; set; }
        [Column("TRAIN_ID")] public string? Train_id { get; set; }
        [Column("ORDER_STATUS")] public string? Order_status { get; set; }
        [Column("PRICE")] public double? Price { get; set; }
        [Column("TICKET_TYPE")] public string? Ticket_type { get; set; }
        [Column("PASSENGER_ID")] public string? Passenger_id { get; set; }

        public MyTicket() { }
    }
}
