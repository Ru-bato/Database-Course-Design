using DB_BackendBLL;
using DB_BackendModel;
using Microsoft.AspNetCore.Mvc;

namespace test2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerManager _passengerManager;

        public PassengerController(PassengerManager passengerManager)
        {
            _passengerManager = passengerManager;
        }

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
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPassenger/{id}")]
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

        [HttpPut("UpdatePassenger")]
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
                return BadRequest(ex.Message);
            }
        }
    }
}

