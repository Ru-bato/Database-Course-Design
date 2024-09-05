using DB_Backend.DB_BackendBLL;
using DB_Backend.DB_BackendModel;
using Microsoft.AspNetCore.Mvc;

namespace DB_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("search")]
        public IActionResult SearchTickets([FromBody] TicketsSearchModel model)
        {
            List<TicketsSearchResponseModel> response = TicketsManager.SearchTickets(model);
            return Ok(response);
        }

        [HttpPost("getPassenger")]
        public IActionResult getPassenger([FromBody] PassengerGetModle model)
        {
            PassengerResponseModel response = TicketsManager.GetPassenger(model);
            return Ok(response);
        }

        [HttpPost("buyTickets")]
        public IActionResult BuyTickets([FromBody] TicketsBuyModel model)
        {
            TicketsResponseModel response = TicketsManager.BuyTickets(model);
            return Ok(response);
        }

        [HttpPost("refundTickets")]
        public IActionResult RefundTickets([FromBody] TicketsRefundModel model)
        {
            TicketsResponseModel response = TicketsManager.RefundTickets(model);
            return Ok(response);
        }

        [HttpPost("changeTickets")]
        public IActionResult ChangeTickets([FromBody] TicketsChangeModel model)
        {
            TicketsSearchModel searchModel = TicketsManager.ChangeTickets(model);
            return SearchTickets(searchModel);
        }
    }
}
