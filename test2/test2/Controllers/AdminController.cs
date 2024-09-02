using DB_BackendBLL;
using DB_BackendModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace test2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager _userManager;
        private readonly AdminManager _adminManager;
        private readonly OrderManager _orderManager;
        private readonly PassengerManager _passengerManager;

        public AdminController(UserManager userManager, AdminManager adminManager, OrderManager orderManager, PassengerManager passengerManager)
        {
            _userManager = userManager;
            _adminManager = adminManager;
            _orderManager = orderManager;
            _passengerManager = passengerManager;
        }

        [HttpPost("CreateAdmin")]
        public IActionResult CreateAdmin(Admin admin)
        {
            try
            {
                _adminManager.CreateAdmin(admin);
                return Ok("Admin created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAdmin/{id}")]
        public IActionResult GetAdmin(string id)
        {
            try
            {
                var admin = _adminManager.GetAdminById(id);
                if (admin == null) return NotFound("Admin not found.");
                return Ok(admin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateAdmin")]
        public IActionResult UpdateAdmin(Admin admin)
        {
            try
            {
                _adminManager.UpdateAdmin(admin);
                return Ok("Admin updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAdmin/{id}")]
        public IActionResult DeleteAdmin(string id)
        {
            try
            {
                _adminManager.DeleteAdmin(id);
                return Ok("Admin deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
