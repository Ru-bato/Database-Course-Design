using DB_BackendDAL;
using DB_BackendModel;
using System;

namespace DB_BackendBLL
{
    public class UserManager
    {
        private readonly UserServer _userServer;

        public UserManager(UserServer userServer)
        {
            _userServer = userServer;
        }

        // 创建用户
        public void CreateUser(User user)
        {
            // 业务规则：用户名和密码不能为空
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ArgumentException("用户名和密码不能为空");
            }

            // 可以在这里添加更多的业务验证或数据处理
            _userServer.CreateUser(user);
        }

        // 根据ID获取用户信息
        public User? GetUserById(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("用户ID不能为空");
            }

            return _userServer.GetUserById(userId);
        }

        // 更新用户信息
        public void UpdateUser(User user)
        {
            // 业务规则：用户名和密码不能为空
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ArgumentException("用户名和密码不能为空");
            }

            _userServer.UpdateUser(user);
        }

        // 删除用户
        public void DeleteUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("用户ID不能为空");
            }

            _userServer.DeleteUser(userId);
        }
    }
}

