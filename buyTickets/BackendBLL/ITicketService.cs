using buyTickets.BackendModel;
using System.Collections.Generic;

namespace buyTickets.BackendBLL
{
    public interface ITicketService
    {
        Ticket GetTicketById(int id);
        List<Ticket> GetTickets(string originStation, string destinationStation, DateTime departureDate);
        // 其他业务逻辑方法
    }
}
