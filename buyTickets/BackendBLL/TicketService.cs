using buyTickets.BackendDAL;
using buyTickets.BackendModel;
using System;
using System.Collections.Generic;

namespace buyTickets.BackendBLL
{
    public class TicketService: ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.GetTicketById(id);
        }

        public List<Ticket> GetTickets(string originStation, string destinationStation, DateTime departureDate)
        {
            // 这里可以加入业务逻辑，例如验证输入、处理特殊情况等
            return _ticketRepository.GetTickets(originStation, destinationStation, departureDate);
        }
    }
}
