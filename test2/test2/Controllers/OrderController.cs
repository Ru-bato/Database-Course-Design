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

        [HttpPost("CreateOrder")]
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

        [HttpGet("GetOrder/{id}")]
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

        [HttpPut("UpdateOrder")]
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

        [HttpDelete("DeleteOrder/{id}")]
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

        //由用户的id得到订单的信息
        [HttpGet("GetPassengersByUserId/{userId}")]
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
