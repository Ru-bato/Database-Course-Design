using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB_Backend.DB_BackendModel
{
    public class Train
    {
        [Key][Column("TRAIN_ID")] public string? Train_id { get; set; }
        [Column("DEPARTURE_STATION")] public string? Departure_station { get; set; }
        [Column("ARRIVAL_STATION")] public string? Arrival_station { get; set; }
        [Column("DEPARTURE_TIME")] public string? Departure_time { get; set; }
        [Column("ARRIVAL_TIME")] public string? Arrival_time { get; set; }

        public Train() { }
    }
}
