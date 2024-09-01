using DB_BackendBLL;
using DB_BackendModel;
using Microsoft.AspNetCore.Mvc;

namespace test2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AdminManager _adminManager;

        public AdminController(AdminManager adminManager)
        {
            _adminManager = adminManager;
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
