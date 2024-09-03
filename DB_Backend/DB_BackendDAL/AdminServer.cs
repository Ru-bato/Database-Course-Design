using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using DB_Backend.DB_BackendModel;

namespace DB_Backend.DB_BackendDAL
{
    public class AdminServer
    {
        private readonly string _connectionString;

        // 使用依赖注入 (DI) 来获取配置
        public AdminServer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleDbConnection")
                ?? throw new ArgumentNullException(nameof(_connectionString), "Connection string cannot be null.");
        }

        // 获取数据库连接
        public OracleConnection GetConnection()
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            return connection;
        }

        // 创建管理员
        public void CreateAdmin(Admin admin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("INSERT INTO Admins (Admin_id, Username, Password, Id_number, Phone_number) VALUES (:Admin_id, :Username, :Password, :Id_number, :Phone_number)", connection))
                {
                    command.Parameters.Add(new OracleParameter("Admin_id", admin.Admin_ID));
                    command.Parameters.Add(new OracleParameter("Username", admin.Username));
                    command.Parameters.Add(new OracleParameter("Password", admin.Password));
                    command.Parameters.Add(new OracleParameter("Id_number", admin.ID_Number));
                    command.Parameters.Add(new OracleParameter("Phone_number", admin.Phone_Number));

                    command.ExecuteNonQuery();
                }
            }
        }

        // 读取管理员信息
        public Admin? GetAdminById(string adminId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT * FROM Admins WHERE Admin_id = :Admin_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("Admin_id", adminId));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Admin
                            {
                                Admin_ID = reader["Admin_id"].ToString(),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                ID_Number = reader["Id_number"].ToString(),
                                Phone_Number = reader["Phone_number"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // 更新管理员信息
        public void UpdateAdmin(Admin admin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("UPDATE Admins SET Username = :Username, Password = :Password, Id_number = :Id_number, Phone_number = :Phone_number WHERE Admin_id = :Admin_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("Username", admin.Username));
                    command.Parameters.Add(new OracleParameter("Password", admin.Password));
                    command.Parameters.Add(new OracleParameter("Id_number", admin.ID_Number));
                    command.Parameters.Add(new OracleParameter("Phone_number", admin.Phone_Number));
                    command.Parameters.Add(new OracleParameter("Admin_id", admin.Admin_ID));

                    command.ExecuteNonQuery();
                }
            }
        }

        // 删除管理员
        public void DeleteAdmin(string adminId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("DELETE FROM Admins WHERE Admin_id = :Admin_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("Admin_id", adminId));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
