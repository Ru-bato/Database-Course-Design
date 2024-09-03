using DB_BackendBLL;
using DB_BackendModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace test2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengerController : ControllerBase
    {
        private readonly UserManager _userManager;
        private readonly AdminManager _adminManager;
        private readonly OrderManager _orderManager;
        private readonly PassengerManager _passengerManager;

        public PassengerController(UserManager userManager, AdminManager adminManager, OrderManager orderManager, PassengerManager passengerManager)
        {
            _userManager = userManager;
            _adminManager = adminManager;
            _orderManager = orderManager;
            _passengerManager = passengerManager;
        }

        [HttpPost("CreatePassenger")]//创建乘车人，需要用户提供passenger表
        public IActionResult CreatePassenger(Passenger passenger)
        {
            try
            {
                _passengerManager.CreatePassenger(passenger);
                return Ok("Passenger created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        [HttpGet("GetPassenger/{id}")]//根据passenger_id得到passenger的所有信息
        public IActionResult GetPassenger(string id)
        {
            try
            {
                var passenger = _passengerManager.GetPassengerById(id);
                if (passenger == null) return NotFound("Passenger not found.");
                return Ok(passenger);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePassenger")]//更新passenger乘客信息，但需要提供passenger表
        public IActionResult UpdatePassenger(Passenger passenger)
        {
            try
            {
                _passengerManager.UpdatePassenger(passenger);
                return Ok("Passenger updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateUserPassenger")]//修改用户已有的乘车人，调用上述程序
        public IActionResult UpdateUserPassenger(string passengerid, string userid, string passengername, string idnumber)
        {
            try
            {

                Passenger passenger = new Passenger
                {
                    passenger_id = passengerid,
                    User_id = userid,
                    Passenger_name=passengername,
                    Id_number=idnumber

                };
                _passengerManager.UpdatePassenger(passenger);
                return Ok("Passenger updated successfully.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletePassenger/{id}")]//根据passenger_id删除对应的passenger项
        public IActionResult DeletePassenger(string id)
        {
            try
            {
                _passengerManager.DeletePassenger(id);
                return Ok("Passenger deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPassengersByUserId/{userId}")]//将User_id下的Passenger项以一个新的表的形式全部输出
        public IActionResult GetPassengersByUserId(string userId)
        {
            try
            {
                var passengers = _passengerManager.GetPassengersByUserId(userId);
                if (passengers == null || passengers.Count == 0)
                    return NotFound("No passengers found for the given user ID.");
                return Ok(passengers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

