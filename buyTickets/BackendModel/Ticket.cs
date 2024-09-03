namespace buyTickets.BackendModel
{
    public class Ticket
    {
        public int Id { get; set; }
        public string startStation { get; set; }
        public string endStation { get; set; }
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
    }
}
