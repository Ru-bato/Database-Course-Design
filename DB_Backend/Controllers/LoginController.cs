using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using DB_Backend.DB_BackendModel;
using DB_Backend.DB_BackendBLL;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using static DB_Backend.Controllers.LoginController;

namespace DB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public class LoginFormat
        {
            public string Phone_Number { get; set; }
            public string Password { get; set; }
            public LoginFormat()
            {
                Phone_Number = string.Empty;
                Password = string.Empty;
            }
        }

        public class VerifyFormat
        {
            public string Phone_Number { get; set; }
            public string ID_Number { get; set; }
            public VerifyFormat()
            {
                Phone_Number = string.Empty;
                ID_Number = string.Empty;
            }
        }

        public class ResetPasswordFormat
        {
            public string User_ID { get; set; }
            public string New_Password { get; set; }
            public ResetPasswordFormat()
            {
                User_ID = string.Empty;
                New_Password = string.Empty;
            }
        }

        // 哈希密码
        public string HashSecretString(string plainString)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainString);
        }

        // 验证密码
        public bool VerifySecretString(string plainString, string hashedString)
        {
            return BCrypt.Net.BCrypt.Verify(plainString, hashedString);
        }

        static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // 将输入字符串转换为字节数组
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // 计算哈希值
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // 将字节数组转换为十六进制字符串
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2")); // 使用 "x2" 格式将字节转换为两位十六进制
                }

                return stringBuilder.ToString();
            }
        }
        /// <summary>
        /// 登录接口，使用手机号登录
        /// </summary>
        /// <param name="loginFormat"></param>
        /// <returns>Ok or Unauthorized</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginFormat loginFormat)
        {
            string phoneNumber = loginFormat.Phone_Number;
            string password = loginFormat.Password;
            Console.WriteLine("Login: " + phoneNumber + " " + password);
            User candidate = UserManager.Login(phoneNumber);
            if (candidate.User_ID == "-1")
            {
                Console.WriteLine("用户不存在");
                return Unauthorized(new { code = -3, message = "用户不存在" });
            }
            //else if (!VerifySecretString(password, candidate.Password))
            //{
            //    Console.WriteLine("密码错误，请重新输入");
            //    return Unauthorized(new { code = -1, message = "密码错误，请重新输入" });
            //}
            else if (password != candidate.Password)
            {
                Console.WriteLine("密码错误，请重新输入");
                return Unauthorized(new { code = -1, message = "密码错误，请重新输入" });
            }
            else if (candidate.Status == false)
            {
                Console.WriteLine("账号已被封禁，请等待解禁");
                return Unauthorized(new { code = -2, message = "账号已被封禁，请等待解禁" });
            }
            else
            {
                var responseData = new
                {
                    data = new
                    {
                        User_ID = candidate.User_ID,
                        Username = candidate.Username,
                        Password = candidate.Password,
                        Is_Student = candidate.Is_Student,
                        Status = candidate.Status,
                        ID_Number = candidate.ID_Number,
                        Phone_Number = candidate.Phone_Number,
                        Riding_Interval = candidate.Riding_Interval
                    }
                };
                return Ok(responseData);
            }
        }
        [HttpPost("forgot_verify")]
        public IActionResult Forgot_Verify([FromBody] VerifyFormat verifyFormat)
        {
            string phoneNumber = verifyFormat.Phone_Number;
            string idNumber = verifyFormat.ID_Number;
            Console.WriteLine("Verify: " + phoneNumber + " " + idNumber);
            User candidate = UserManager.Login(phoneNumber);
            // TODO: 此处应加密身份证号？
            if (candidate.ID_Number != idNumber)
            {
                Console.WriteLine("身份信息不匹配，请重新输入");
                return Unauthorized(new { code = -1, message = "身份信息不匹配，请重新输入" });
            }
            else if (candidate.Status == false)
            {
                Console.WriteLine("账号已被封禁，请等待解禁");
                return Unauthorized(new { code = -2, message = "账号已被封禁，请等待解禁" });
            }
            else if (candidate.User_ID == "-1")
            {
                Console.WriteLine("用户不存在");
                return Unauthorized(new { code = -3, message = "用户不存在" });
            }
            else
            {
                var responseData = new
                {
                    data = new
                    {
                        User_ID = candidate.User_ID,
                        Username = candidate.Username,
                        Password = candidate.Password,
                        Is_Student = candidate.Is_Student,
                        Status = candidate.Status,
                        ID_Number = candidate.ID_Number,
                        Phone_Number = candidate.Phone_Number,
                        Riding_Interval = candidate.Riding_Interval
                    }
                };
                return Ok(responseData);
            }
        }
        [HttpPost("reset_password")]
        public IActionResult EditUserPassword([FromBody] ResetPasswordFormat resetPasswordFormat)
        {
            try
            {
                // TODO: 这里要加密
                int result = UserManager.ChangePassword(resetPasswordFormat.User_ID, resetPasswordFormat.New_Password);
                if (result == 0)
                {
                    return Ok(0);
                }
                else
                {
                    Console.WriteLine("更改密码接口报错");
                    return BadRequest(new { code = -1, message = "更改密码失败，系统发生未知错误" });
                }
            }
            catch
            {
                return BadRequest("更改密码失败！");
            }

        }
    }
}
