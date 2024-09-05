using DB_Backend.DB_BackendBLL;
using DB_Backend.DB_BackendModel;
using Microsoft.AspNetCore.Mvc;

namespace DB_Backend.Controllers
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

        // 创建乘车人
        [HttpPost("CreatePassenger")]
        public IActionResult CreatePassenger(Passenger passenger)
        {
            try
            {
                _passengerManager.CreatePassenger(passenger);
                return Ok("Passenger created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating passenger: {ex.Message}");
            }
        }

        // 根据乘车人姓名和身份证号查找关联的用户，并返回用户信息
        [HttpPost("FindUserByPassengerDetails")]
        public IActionResult FindUserByPassengerDetails(string userid, string passengerName, string idNumber)
        {
            try
            {
                var user = _passengerManager.GetPassengersByNameAndId(passengerName, idNumber);
                if (user == null)
                    return NotFound("No user found matching the provided passenger details.");
                CreateUserPassenger(user.User_ID, userid, passengerName, idNumber);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error finding user: {ex.Message}");
            }
        }

        // 根据用户信息和乘车人信息创建新的乘车人
        [HttpPost("CreateUserPassenger")]
        public IActionResult CreateUserPassenger(string passengerId, string userId, string passengerName, string idNumber)
        {
            try
            {
                Passenger passenger = new Passenger
                {
                    passenger_id = passengerId,
                    User_id = userId,
                    Passenger_name = passengerName,
                    Id_number = idNumber
                };
                _passengerManager.CreatePassenger(passenger);
                return Ok("Passenger created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating passenger: {ex.Message}");
            }
        }

        // 根据乘车人ID获取乘车人信息
        [HttpGet("GetPassenger/{id}")]
        public IActionResult GetPassenger(string id)
        {
            try
            {
                var passenger = _passengerManager.GetPassengerById(id);
                if (passenger == null)
                    return NotFound("Passenger not found.");
                return Ok(passenger);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching passenger: {ex.Message}");
            }
        }

        // 更新乘车人信息
        [HttpPut("UpdatePassenger")]
        public IActionResult UpdatePassenger(Passenger passenger)
        {
            try
            {
                var user = _passengerManager.GetPassengersByNameAndId(passenger.Passenger_name, passenger.Id_number);
                 if (user == null)
                     return NotFound("No user found matching the provided passenger details.");
                _passengerManager.UpdatePassenger(passenger);
                return Ok("Passenger updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating passenger: {ex.Message}");
            }
        }

        // 根据用户ID和乘车人ID更新乘车人信息
        [HttpPut("UpdateUserPassenger")]
        public IActionResult UpdateUserPassenger(string passengerId, string userId, string passengerName, string idNumber)
        {
            try
            {
                Passenger passenger = new Passenger
                {
                    passenger_id = passengerId,
                    User_id = userId,
                    Passenger_name = passengerName,
                    Id_number = idNumber
                };
                _passengerManager.UpdatePassenger(passenger);
                return Ok("Passenger updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating passenger: {ex.Message}");
            }
        }

        // 根据乘车人ID删除乘车人信息
        [HttpDelete("DeletePassenger/{id}")]
        public IActionResult DeletePassenger(string id)
        {
            try
            {
                _passengerManager.DeletePassenger(id);
                return Ok("Passenger deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting passenger: {ex.Message}");
            }
        }

        // 根据用户ID获取所有乘车人信息
        [HttpGet("GetPassengersByUserId/{userId}")]
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
                return BadRequest($"Error fetching passengers: {ex.Message}");
            }
        }
    }
}
