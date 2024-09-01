using DB_BackendBLL;
using DB_BackendModel;
using Microsoft.AspNetCore.Mvc;

namespace test2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderManager _orderManager;

        public OrderController(OrderManager orderManager)
        {
            _orderManager = orderManager;
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
    }
}
