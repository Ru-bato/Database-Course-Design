using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using DB_BackendModel;

namespace DB_BackendDAL
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

            // 通用方法：执行查询
            public DataTable ExecuteQuery(string query)
        {
            using (var connection = GetConnection())
            {
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                DataTable resultTable = new DataTable();
                connection.Open();
                adapter.Fill(resultTable);
                return resultTable;
            }
        }

        // 通用方法：执行非查询（如INSERT, UPDATE, DELETE）
        public int ExecuteNonQuery(string query)
        {
            using (var connection = GetConnection())
            {
                OracleCommand command = new OracleCommand(query, connection);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        // 创建管理员
        public void CreateAdmin(Admin admin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("INSERT INTO Admins (Admin_id, Username, Password, Id_number, Phone_number) VALUES (:Admin_id, :Username, :Password, :Id_number, :Phone_number)", connection))
                {
                    command.Parameters.Add(new OracleParameter("Admin_id", admin.Admin_id));
                    command.Parameters.Add(new OracleParameter("Username", admin.Username));
                    command.Parameters.Add(new OracleParameter("Password", admin.Password));
                    command.Parameters.Add(new OracleParameter("Id_number", admin.Id_number));
                    command.Parameters.Add(new OracleParameter("Phone_number", admin.Phone_number));

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
                                Admin_id = reader["Admin_id"].ToString(),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Id_number = reader["Id_number"].ToString(),
                                Phone_number = reader["Phone_number"].ToString()
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
                    command.Parameters.Add(new OracleParameter("Id_number", admin.Id_number));
                    command.Parameters.Add(new OracleParameter("Phone_number", admin.Phone_number));
                    command.Parameters.Add(new OracleParameter("Admin_id", admin.Admin_id));

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
