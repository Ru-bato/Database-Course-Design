
using buyTickets.BackendModel;
using System.Linq;
using System.Collections.Generic;


namespace buyTickets.BackendDAL
   
{
    public class TicketRepository:ITicketRepository
    {
        private readonly ApplicationDbContext _context; // 假设你有一个 DbContext 用于数据库连接

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Ticket GetTicketById(int id)
        {
            return _context.Tickets.Find(id); // 假设 Tickets 是你的 DbSet<Ticket>
        }

        public List<Ticket> GetTickets(string originStation, string destinationStation, DateTime departureDate)
        {
            return _context.Tickets
                .Where(t => t.startStation == originStation && t.endStation == destinationStation && t.DepartureDate == departureDate)
                .ToList();
        }
    }
}
