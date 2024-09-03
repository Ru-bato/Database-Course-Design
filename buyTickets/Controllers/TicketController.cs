using buyTickets.BackendBLL;
using buyTickets.BackendDAL;
using buyTickets.BackendModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace buyTickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController: ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ApplicationDbContext _context;

        public TicketController(ITicketService ticketService, ApplicationDbContext context)
        {
            _ticketService = ticketService;
            _context = context;
        }

        [HttpGet("tickets")]
        public IActionResult GetTickets([FromQuery] string originStation, [FromQuery] string destinationStation, [FromQuery] DateTime departureDate)
        {
            var tickets = _ticketService.GetTickets(originStation, destinationStation, departureDate);
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public IActionResult GetTicketById(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpGet("testdb")]
        public IActionResult TestDatabaseConnection()
        {
            try
            {
                // 尝试从数据库中获取数据
                var ticketCount = _context.Tickets.Count();
                return Ok($"Database connection is working. Number of tickets: {ticketCount}");
            }
            catch (Exception ex)
            {
                // 捕获异常并返回错误信息
                return StatusCode(500, $"Error connecting to the database: {ex.Message}");
            }
        }
    }
}
