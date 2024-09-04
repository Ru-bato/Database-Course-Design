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

        // 修改用户登录状态（通过修改Status属性）
        [HttpPut("ProhibitUserLogin/{id}")]
        public IActionResult ProhibitUserLogin(string id, bool status)
        {
            try
            {
                var user = _userManager.GetUserById(id);
                if (user == null) return NotFound("User not found.");
                var admin = _adminManager.GetAdminById(id);
                if (admin != null)
                {
                    return BadRequest("Admins cannot be changed.");
                }
                user.Status = status;
                _userManager.UpdateUser(user);

                return Ok($"User login status updated to {status}.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //创建以及查询信息与UserController.cs中内容重复，不重复编程

        // 删除用户
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteNoAdminUser(string id)
        {
            try
            {
                var admin = _adminManager.GetAdminById(id);
                if (admin != null)
                {
                    return BadRequest("Admins cannot be deleted.");
                }

                _userManager.DeleteUser(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 修改用户信息
        [HttpPut("UpdateUser")]
        public IActionResult UpdateNoAdminUser(User user)
        {
            try
            {
                var admin = _adminManager.GetAdminById(user.User_id);
                if (admin != null)
                {
                    return BadRequest("Admins cannot be modified.");
                }

                _userManager.UpdateUser(user);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //为Admin添加一个能够得到全部用户id列表的功能
        [HttpGet("GetAllUserIds")]
        public IActionResult GetAllUserIds()
        {
            try
            {
                var userIds = _userManager.GetAllUserIds();
                if (userIds == null || userIds.Count == 0)
                {
                    return NotFound("No users found.");
                }
                return Ok(userIds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
