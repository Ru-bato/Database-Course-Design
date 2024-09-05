using Microsoft.AspNetCore.Mvc;
using DB_Backend.DB_BackendBLL;

namespace DB_Backend.Controllers
{

    public class TicketTypeRequest
    {
        public int TicketType { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class OrderListController : Controller
    {
        [HttpPost]
        public IActionResult TotalTickets([FromBody] TicketTypeRequest request)
        {
            int sum= OrderListManager.TotalTickets(request.TicketType);
            return Ok(sum);
        }
    }
}
