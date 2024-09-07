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
            int tickets = OrderListManager.TotalTickets(request.TicketType);
            int sales = OrderListManager.TotalMoney(request.TicketType);
            int wait = OrderListManager.TotalWait(request.TicketType);
            var response = new
            {
                ticketsSum = tickets,
                salesSum = sales,
                WaitSum = wait,
            };
            return Ok(response);
        }

        //[HttpPost("TotalMoney")]
        //public IActionResult TotalMoney([FromBody] TicketTypeRequest request)
        //{
        //    int sum = OrderListManager.TotalMoney(request.TicketType);
        //    return Ok(sum);
        //}
    }
}
