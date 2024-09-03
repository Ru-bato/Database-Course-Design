using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using DB_BackendModel;

namespace DB_BackendDAL
{
    public class UserServer
    {
        private readonly string _connectionString;

        // 使用依赖注入 (DI) 来获取配置
        public UserServer(IConfiguration configuration)
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

        // 创建用户
        public void CreateUser(User user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("INSERT INTO Users (User_id, Username, Password, Id_number, Is_student, Status, Phone_number, Riding_interval) VALUES (:User_id, :Username, :Password, :Id_number, :Is_student, :Status, :Phone_number, :Riding_interval)", connection))
                {
                    command.Parameters.Add(new OracleParameter("User_id", user.User_id));
                    command.Parameters.Add(new OracleParameter("Username", user.Username));
                    command.Parameters.Add(new OracleParameter("Password", user.Password));
                    command.Parameters.Add(new OracleParameter("Id_number", user.Id_number));
                    command.Parameters.Add(new OracleParameter("Is_student", user.Is_student));
                    command.Parameters.Add(new OracleParameter("Status", user.Status));
                    command.Parameters.Add(new OracleParameter("Phone_number", user.Phone_number));
                    command.Parameters.Add(new OracleParameter("Riding_interval", user.Riding_interval));

                    command.ExecuteNonQuery();
                }
            }
        }

        // 读取用户信息
        public User? GetUserById(string userId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT * FROM Users WHERE User_id = :User_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("User_id", userId));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                User_id = reader["User_id"].ToString(),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Id_number = reader["Id_number"].ToString(),
                                Is_student = Convert.ToBoolean(reader["Is_student"]),
                                Status = Convert.ToBoolean(reader["Status"]),
                                Phone_number = reader["Phone_number"].ToString(),
                                Riding_interval = reader["Riding_interval"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // 更新用户信息
        public void UpdateUser(User user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("UPDATE Users SET Username = :Username, Password = :Password, Id_number = :Id_number, Is_student = :Is_student, Status = :Status, Phone_number = :Phone_number, Riding_interval = :Riding_interval WHERE User_id = :User_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("Username", user.Username));
                    command.Parameters.Add(new OracleParameter("Password", user.Password));
                    command.Parameters.Add(new OracleParameter("Id_number", user.Id_number));
                    command.Parameters.Add(new OracleParameter("Is_student", user.Is_student));
                    command.Parameters.Add(new OracleParameter("Status", user.Status));
                    command.Parameters.Add(new OracleParameter("Phone_number", user.Phone_number));
                    command.Parameters.Add(new OracleParameter("Riding_interval", user.Riding_interval));
                    command.Parameters.Add(new OracleParameter("User_id", user.User_id));

                    command.ExecuteNonQuery();
                }
            }
        }

        // 删除用户
        public void DeleteUser(string userId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("DELETE FROM Users WHERE User_id = :User_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("User_id", userId));
                    command.ExecuteNonQuery();
                }
            }
        }

        // 获取所有用户
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT * FROM Users", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                User_id = reader["User_id"].ToString(),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Id_number = reader["Id_number"].ToString(),
                                Is_student = Convert.ToBoolean(reader["Is_student"]),
                                Status = Convert.ToBoolean(reader["Status"]),
                                Phone_number = reader["Phone_number"].ToString(),
                                Riding_interval = reader["Riding_interval"].ToString(),
                            };
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }
    }
}
