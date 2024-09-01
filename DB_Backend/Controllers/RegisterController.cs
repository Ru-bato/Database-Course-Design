using Microsoft.AspNetCore.Mvc;
using DB_Backend.DB_BackendBLL;
using DB_Backend.DB_BackendDAL;
using static DB_Backend.Controllers.RegisterController;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public class RegisterModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Phone_Number { get; set; }
            public string ID_Number { get; set; }

            public RegisterModel()
            {
                Username = string.Empty;
                Password = string.Empty;
                Phone_Number = string.Empty;
                ID_Number = string.Empty;
            }
        }
        /// <summary>
        /// 注册接口
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns>IActionResult response</returns>
        [HttpPost]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            string username = registerModel.Username;
            string password = registerModel.Password;
            string phoneNumber = registerModel.Phone_Number;
            string idNumber = registerModel.ID_Number;
            string? UID;

            IActionResult response;

            Console.WriteLine(username + " " + password + " " + phoneNumber + " " + idNumber);
            int status = UserManager.Register(out UID, username, password, phoneNumber, idNumber);
            string message;
            if (status == 0) // code == 0 is correct
            {
                message = UID;
                response = Ok(message);
            }
            else
            {
                //message = JsonHelper.GetErrorMessage("register", status);
                response = Unauthorized(-4);
            }
            return response;
        }
    }
}
