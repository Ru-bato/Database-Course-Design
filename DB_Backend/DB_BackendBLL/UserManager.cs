using DB_Backend.DB_BackendDAL;
using DB_Backend.DB_BackendModel;
using System.Net;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DB_Backend.DB_BackendBLL
{
    public class UserManager
    {
        /// <summary>
        /// 在后端接收到密码后，进行哈希处理。为了增加安全性，使用一个强密码哈希算法。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ComputeSHA256Hash(string input) // TODO: 暂时不加盐
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var saltedInput = input; // TODO: 暂时不加盐
                byte[] inputBytes = Encoding.UTF8.GetBytes(saltedInput);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
        /// <summary>
        /// 登录，这是一个通用接口，既能用于手机号+密码登录，又能用于手机号+身份证号验证身份
        /// </summary>
        /// <param name="Phone_Number"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static User Login(string Phone_Number)
        {
            User candidate = UserServer.GetUserByTel(Phone_Number);
            return candidate;
        }
        //public static User Verify(string Phone_Number, string ID_Number) 
        //{ 
        //    User candidate = UserServer.GetUserByVerify(Phone_Number, ID_Number);
        //}
        /// <summary>
        /// 检验手机号格式是否合法
        /// </summary>
        /// <param name="Phone_Number"></param>
        /// <returns>true: 合法, false: 不合法</returns>
        private static bool ValidatePhoneNumber(string Phone_Number)
        {
            string pattern = @"^\d{11}$";
            bool isValid = Regex.IsMatch(Phone_Number, pattern);
            return isValid;
        }
        /// <summary>
        /// 检验密码格式是否合法
        /// </summary>
        /// <param name="password"></param>
        /// <returns>true: 合法, false: 不合法</returns>
        private static bool ValidatePassword(string password)
        {
            bool hasMinimumLength = password.Length >= 10;
            bool hasDigit = Regex.IsMatch(password, @"\d");
            bool hasLowerCase = Regex.IsMatch(password, @"[a-z]");
            bool hasUpperCase = Regex.IsMatch(password, @"[A-Z]");
            bool hasSpecialCharacter = Regex.IsMatch(password, @"[/!@#$%^&*_()]");

            bool isValid = hasMinimumLength && hasDigit && hasLowerCase && hasUpperCase && hasSpecialCharacter;
            return isValid;
        }
        /// <summary>
        /// 检验注册格式是否合法
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Phone_Number"></param>
        /// <returns>
        /// <para>!ValidatePhoneNumber: 1</para> 
        /// <para>!ValidatePassword: 2</para> 
        /// <para>Username.Length > 20: 3</para>
        /// <para>valid: 0</para>
        /// </returns>
        private static int ValidRegistration(string Username, string Password, string Phone_Number)
        {
            if (!ValidatePhoneNumber(Phone_Number))
            {
                return 1;
            }
            else if (!ValidatePassword(Password))
            {
                return 2;
            }
            else if (Username.Length > 20)
            {
                return 3;
            }
            else
                return 0;

        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="User_ID"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Phone_Number"></param>
        /// <returns></returns>
        public static int Register(out string User_ID, string Username, string Password, string Phone_Number, string ID_Number)
        {
            User_ID = null;
            int code = ValidRegistration(Username, Password, Phone_Number);
            Console.WriteLine("code = " + code);
            if (code != 0) { return code; } // means incorrect
            User_ID = UserServer.InsertUser(Username, Password, Phone_Number, ID_Number);
            if (User_ID == "-1")
            {
                return -1;
            }
            return code;
        }

        public static int ChangePassword(string User_ID, string New_Password)
        {
            try
            {
                UserServer.UpdatePassword(User_ID, New_Password);
            }
            catch (Exception ex)
            {
                Console.WriteLine("密码修改失败，发生未知错误");
                return -1;
            }
            return 0;
        }
    }
}
