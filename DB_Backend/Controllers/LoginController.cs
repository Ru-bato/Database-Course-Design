using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using DB_Backend.DB_BackendModel;
using DB_Backend.DB_BackendBLL;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace DB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public class LoginFormat
        {
            public string User_ID { get; set; }
            public string Password { get; set; }
            public LoginFormat()
            {
                User_ID = string.Empty;
                Password = string.Empty;
            }
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

        [HttpPost]
        public IActionResult Login([FromBody] LoginFormat loginFormat)
        {
            string uid = loginFormat.User_ID;
            string password = loginFormat.Password;
            Console.WriteLine("Login: " + uid + " " + password);
            User candidate = UserManager.Login(uid, password);
            //password = ComputeSHA256Hash(password);
            if(candidate.Password != password)
            {
                return Unauthorized(-1); //"密码错误，请重新输入"
            }
            else if(candidate.Status == false)
            {
                return Unauthorized(-2); //"账号已被封禁，请等待解禁"
            }
            else if(candidate.User_ID == "-1")
            {
                return Unauthorized(-3); //"用户不存在"
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
                string responseJson = JsonSerializer.Serialize(responseData);
                return Ok(responseJson);
            }
        }
    }
}
