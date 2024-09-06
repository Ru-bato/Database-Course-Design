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

        /// <summary>
        /// 搜索车票接口(非中转)
        /// 调用方法：post <address>/api/tickets/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("search")]
        public IActionResult SearchTickets([FromBody] TicketsSearchModel model)
        {
            List<TicketsSearchResponseModel> response = TicketsManager.SearchTickets(model);
            return Ok(response);
        }

        /// <summary>
        /// 搜索车票接口(中转)
        /// 调用方法：post <address>/api/tickets/search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("searchMiddle")]
        public IActionResult SearchTicketsMiddle([FromBody] TicketsSearchModel model)
        {
            List<TicketsSearchResponseModel_middle> response = TicketsManager.SearchTicketsMiddle(model);
            return Ok(response);
        }

        /// <summary>
        /// 获取乘车人接口
        /// 调用方法：post <address>/api/tickets/getPassenger
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("getPassenger")]
        public IActionResult GetPassenger([FromBody] PassengerGetModle model)
        {
            PassengerResponseModel response = TicketsManager.GetPassenger(model);
            return Ok(response);
        }

        /// <summary>
        /// 减少车票接口
        /// 调用方法：post <address>/api/tickets/reduceTickets
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("reduceTickets")]
        public IActionResult ReduceTickets([FromBody] TicketsReduceModel model)
        {
            TicketsResponseModel response = TicketsManager.ReduceTickets(model);
            return Ok(response);
        }

        /// <summary>
        /// 创建订单接口
        /// 调用方法：post <address>/api/tickets/createOrder
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("createOrder")]
        public IActionResult CreateOrder([FromBody] CreateOrderModel model)
        {
            TicketsResponseModel response = TicketsManager.CreateOrder(model);
            return Ok(response);
        }

        /// <summary>
        /// 退票接口
        /// 调用方法：post <address>/api/tickets/refundTickets
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("refundTickets")]
        public IActionResult RefundTickets([FromBody] TicketsRefundModel model)
        {
            TicketsResponseModel response = TicketsManager.RefundTickets(model);
            return Ok(response);
        }

        /// <summary>
        /// 改签接口
        /// 调用方法：post <address>/api/tickets/changeTickets
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("changeTickets")]
        public IActionResult ChangeTickets([FromBody] TicketsChangeModel model)
        {
            TicketsSearchModel searchModel = TicketsManager.ChangeTickets(model);
            return SearchTickets(searchModel);
        }
    }
}
