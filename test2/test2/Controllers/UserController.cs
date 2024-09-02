using DB_BackendBLL;
using DB_BackendModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace test2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager _userManager;
        private readonly AdminManager _adminManager;
        private readonly OrderManager _orderManager;
        private readonly PassengerManager _passengerManager;

        public UserController(UserManager userManager, AdminManager adminManager, OrderManager orderManager, PassengerManager passengerManager)
        {
            _userManager = userManager;
            _adminManager = adminManager;
            _orderManager = orderManager;
            _passengerManager = passengerManager;
        }

        [HttpPost("CreateUser")]//创建用户，同时决定是否为管理员
        public IActionResult CreateUser(User user, bool isadmin)
        {
            try
            {
                // 创建用户信息
                _userManager.CreateUser(user);

                if (isadmin)
                {
                    // 如果用户是管理员，创建管理员记录
                    Admin admin = new Admin
                    {
                        Admin_id = user.User_id, // 使用 User_id 作为 Admin_id
                        Username = user.Username,
                        Password = user.Password,
                        Id_number = user.Id_number,
                        Phone_number = user.Phone_number,
                    };
                    _adminManager.CreateAdmin(admin);

                    return Ok("Admin created successfully.");
                }
                else
                {
                    return Ok("User created successfully.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUser/{id}")]//查询用户信息，判断是否为管理员
        public IActionResult GetUser(string id)
        {
            try
            {
                // 查询用户信息
                var user = _userManager.GetUserById(id);
                if (user == null) return NotFound("User not found.");

                // 判断用户是否为管理员
                var admin = _adminManager.GetAdminById(user.User_id);
                bool isAdmin = admin != null; // 如果 admin 不为空，则说明用户是管理员

                // 创建一个新的对象来返回用户信息和管理员状态
                var response = new
                {
                    User = user,
                    IsAdmin = isAdmin
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateUser")]//更新用户
        public IActionResult UpdateUser(User user)
        {
            try
            {
                // 判断用户是否为管理员
                var admin = _adminManager.GetAdminById(user.User_id);
                if (admin != null)
                {
                    // 用户是管理员，更新User以及Admin表
                    _userManager.UpdateUser(user);
                    Admin admin_new = new Admin
                    {
                        Admin_id = user.User_id, // 使用 User_id 作为 Admin_id
                        Username = user.Username,
                        Password = user.Password,
                        Id_number = user.Id_number,
                        Phone_number = user.Phone_number,
                    };
                    _adminManager.UpdateAdmin(admin_new);
                    return Ok("Admin user updated successfully.");
                }
                else
                {
                    // 用户不是管理员，仅更新非管理员的User表
                    _userManager.UpdateUser(user);
                    return Ok("User updated successfully.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUser/{id}")]//删除用户，判断是否要删除admin表
        public IActionResult DeleteUser(string id)
        {
            try
            {
                // 判断用户是否为管理员
                var admin = _adminManager.GetAdminById(id);
                if (admin != null)
                {
                    _userManager.DeleteUser(id);
                    _adminManager.DeleteAdmin(id);
                }
                else
                {
                    _userManager.DeleteUser(id);
                }
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
