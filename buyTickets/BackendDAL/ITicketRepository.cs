using buyTickets.BackendModel;
using System.Collections.Generic;
using System.Linq;

namespace buyTickets.BackendDAL
{
    public interface ITicketRepository
    {
        Ticket GetTicketById(int id);
        List<Ticket> GetTickets(string originStation, string destinationStation, DateTime departureDate);
    }
}
