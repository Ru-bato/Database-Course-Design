using DB_BackendBLL;
using DB_BackendModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace test2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly UserManager _userManager;
        private readonly AdminManager _adminManager;
        private readonly OrderManager _orderManager;
        private readonly PassengerManager _passengerManager;

        public OrderController(UserManager userManager, AdminManager adminManager, OrderManager orderManager, PassengerManager passengerManager)
        {
            _userManager = userManager;
            _adminManager = adminManager;
            _orderManager = orderManager;
            _passengerManager = passengerManager;
        }

        [HttpPost("CreateOrder")]//添加订单（其实与本程序无关）
        public IActionResult CreateOrder(Orderlist order)
        {
            try
            {
                _orderManager.CreateOrder(order);
                return Ok("Order created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrder/{id}")]//由order_id得到对应的订单信息
        public IActionResult GetOrder(string id)
        {
            try
            {
                var order = _orderManager.GetOrderById(id);
                if (order == null) return NotFound("Order not found.");
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateOrder")]//更新订单信息，但需要提供新的order表
        public IActionResult UpdateOrder(Orderlist order)
        {
            try
            {
                _orderManager.UpdateOrder(order);
                return Ok("Order updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateUserOrder")]//修改用户已有的订单，调用上述程序
        public IActionResult UpdateUserOrder(string orderid, string userid, string trainid, string orderstatus, string price, string passengerid, string tickettype)
        {
            try
            {

                Orderlist order = new Orderlist
                {
                    Order_id = orderid,
                    User_id = userid,
                    Train_id = trainid,
                    Orderstatus = orderstatus,
                    Price = price,
                    passenger_id = passengerid,
                    ticket_type = tickettype,

                };
                _orderManager.UpdateOrder(order);
                return Ok("Order updated successfully.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteOrder/{id}")]//由order_id删除对应的项
        public IActionResult DeleteOrder(string id)
        {
            try
            {
                _orderManager.DeleteOrder(id);
                return Ok("Order deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPassengersByUserId/{userId}")]//由用户的id得到订单的信息
        public IActionResult GetOrdersByUserId(string userId)
        {
            try
            {
                var orders = _orderManager.GetOrdersByUserId(userId);
                if (orders == null || orders.Count == 0)
                    return NotFound("No passengers found for the given user ID.");
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
