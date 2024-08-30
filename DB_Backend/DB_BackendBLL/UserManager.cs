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
        public static string ComputeSHA256Hash(string input)
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

        public static User Login(string User_ID, string Password)
        {
            User candidate = UserServer.GetUserByUID(User_ID);
            return candidate;
        }
        private static bool ValidatePassword(string password)
        {
            bool hasMinimumLength = password.Length >= 10;
            bool hasDigit = Regex.IsMatch(password, @"\d");
            bool hasLowerCase = Regex.IsMatch(password, @"[a-z]");
            //bool hasUpperCase = Regex.IsMatch(password, @"[A-Z]");
            //bool hasSpecialCharacter = Regex.IsMatch(password, @"[/!@#$%^&*()]");

            //bool isValid = hasMinimumLength && hasDigit && hasLowerCase && hasUpperCase && hasSpecialCharacter;
            bool isValid = hasMinimumLength && hasDigit && hasLowerCase;
            return isValid;
        }

        public static int Register(out string User_ID, string Username, string Password)
        {
            User_ID = null;
            bool code = ValidatePassword(Password);
            if (!code)
            {
                return -2;
            }
            User_ID = UserServer.InsertUser(Username, ComputeSHA256Hash(Password));
            if(User_ID == "-1")
            {
                return -1;
            }
            return 0;
        }
    }
}
