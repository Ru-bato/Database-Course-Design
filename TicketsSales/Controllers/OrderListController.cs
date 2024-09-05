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
        [HttpPost("TotalTickets")]
        public IActionResult TotalTickets([FromBody] TicketTypeRequest request)
        {
            int sum= OrderListManager.TotalTickets(request.TicketType);
            return Ok(sum);
        }

        [HttpPost("TotalMoney")]
        public IActionResult TotalMoney([FromBody] TicketTypeRequest request)
        {
            int sum = OrderListManager.TotalMoney(request.TicketType);
            return Ok(sum);
        }
    }
}
