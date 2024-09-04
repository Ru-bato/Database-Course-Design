using DB_BackendDAL;
using DB_BackendModel;
using System;

namespace DB_BackendBLL
{
    public class AdminManager
    {
        private readonly AdminServer _adminServer;

        public AdminManager(AdminServer adminServer)
        {
            _adminServer = adminServer;
        }

        // 创建管理员
        public void CreateAdmin(Admin admin)
        {
            if (string.IsNullOrWhiteSpace(admin.Username) || string.IsNullOrWhiteSpace(admin.Password))
            {
                throw new ArgumentException("管理员用户名和密码不能为空");
            }

            // 可以添加其他的业务逻辑或验证
            _adminServer.CreateAdmin(admin);
        }

        // 根据ID获取管理员信息
        public Admin? GetAdminById(string adminId)
        {
            if (string.IsNullOrWhiteSpace(adminId))
            {
                throw new ArgumentException("管理员ID不能为空");
            }

            return _adminServer.GetAdminById(adminId);
        }

        // 更新管理员信息
        public void UpdateAdmin(Admin admin)
        {
            if (string.IsNullOrWhiteSpace(admin.Username) || string.IsNullOrWhiteSpace(admin.Password))
            {
                throw new ArgumentException("管理员用户名和密码不能为空");
            }

            _adminServer.UpdateAdmin(admin);
        }

        // 删除管理员
        public void DeleteAdmin(string adminId)
        {
            if (string.IsNullOrWhiteSpace(adminId))
            {
                throw new ArgumentException("管理员ID不能为空");
            }

            _adminServer.DeleteAdmin(adminId);
        }
    }
}
