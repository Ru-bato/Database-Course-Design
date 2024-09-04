using DB_Backend.DB_BackendModel;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DB_Backend.DB_BackendDAL
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
                    command.Parameters.Add(new OracleParameter("User_id", user.User_ID));
                    command.Parameters.Add(new OracleParameter("Username", user.Username));
                    command.Parameters.Add(new OracleParameter("Password", user.Password));
                    command.Parameters.Add(new OracleParameter("Id_number", user.ID_Number));
                    //command.Parameters.Add(new OracleParameter("Is_student", user.Is_student));
                    //command.Parameters.Add(new OracleParameter("Status", user.Status));
                    // 将布尔值转换为数据库中的数值
                    command.Parameters.Add(new OracleParameter("Is_student", user.Is_Student ? 1 : 0));
                    command.Parameters.Add(new OracleParameter("Status", user.Status ? 1 : 0));
                    command.Parameters.Add(new OracleParameter("Phone_number", user.Phone_Number));
                    command.Parameters.Add(new OracleParameter("Riding_interval", user.Riding_Interval));

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
                                User_ID = reader["User_id"].ToString(),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                ID_Number = reader["Id_number"].ToString(),
                                Is_Student = Convert.ToBoolean(reader["Is_student"]),
                                Status = Convert.ToBoolean(reader["Status"]),
                                Phone_Number = reader["Phone_number"].ToString(),
                                Riding_Interval = reader["Riding_interval"].ToString()
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
                    command.Parameters.Add(new OracleParameter("Id_number", user.ID_Number));
                    //command.Parameters.Add(new OracleParameter("Is_student", user.Is_student));
                    //command.Parameters.Add(new OracleParameter("Status", user.Status));
                    // 将布尔值转换为数据库中的数值
                    command.Parameters.Add(new OracleParameter("Is_student", user.Is_Student ? 1 : 0));
                    command.Parameters.Add(new OracleParameter("Status", user.Status ? 1 : 0));
                    command.Parameters.Add(new OracleParameter("Phone_number", user.Phone_Number));
                    command.Parameters.Add(new OracleParameter("Riding_interval", user.Riding_Interval));
                    command.Parameters.Add(new OracleParameter("User_id", user.User_ID));

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
                                User_ID = reader["User_id"].ToString(),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                ID_Number = reader["Id_number"].ToString(),
                                Is_Student = Convert.ToBoolean(reader["Is_student"]),
                                Status = Convert.ToBoolean(reader["Status"]),
                                Phone_Number = reader["Phone_number"].ToString(),
                                Riding_Interval = reader["Riding_interval"].ToString(),
                            };
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public static string conStr = AccommodateServer.conStr;
        public static User GetUserByTel(string Tel)
        {
            User user = new User();
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful in UserServer.cs!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed:! " + ex);
                }
                OracleCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM USERSTEST WHERE Phone_Number = :tel";
                command.Parameters.Clear();
                command.Parameters.Add("tel", OracleDbType.Varchar2, Tel, ParameterDirection.Input);
                Console.WriteLine("Tel = " +  Tel);
                try
                {
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user.User_ID = reader["User_ID"].ToString();
                        user.Username = reader["Username"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.Phone_Number = reader["Phone_Number"].ToString();
                        user.ID_Number = reader["ID_Number"].ToString();
                        user.Is_Student = reader["Is_Student"].ToString() == "Y";
                        user.Status = reader["Status"].ToString() == "Y";
                        user.Riding_Interval = reader["Riding_Interval"].ToString();
                    }
                    if (user.User_ID == "-1")
                        throw new Exception("不存在的用户，请注册新用户！");
                    else
                    {
                        Console.WriteLine("this user exists");
                        Console.WriteLine(user.Username == null ? "空" : user.Username.ToString());
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                connection.Close();
            }
            return user;
        }

        public static string InsertUser(string Username, string Password, string Phone_Number, string ID_Number)
        {
            string UID = "-1";
            try
            {
                using (OracleConnection connection = new OracleConnection(conStr))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection successful in UserServer.cs!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Connection failed:! " + ex);
                    }
                    OracleCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string status = "Y";
                    command.CommandText = "INSERT INTO USERSTEST (User_ID, Username, Password, Phone_Number, ID_Number, Status)" +
                        "VALUES (user_id_seq.NEXTVAL, :username, :Password, :Phone_number, :ID_Number, :Status)";
                    command.Parameters.Clear();
                    command.Parameters.Add("username", OracleDbType.Varchar2, Username, ParameterDirection.Input);
                    command.Parameters.Add("Password", OracleDbType.Varchar2, Password, ParameterDirection.Input);
                    command.Parameters.Add("Phone_Number", OracleDbType.Varchar2, Phone_Number, ParameterDirection.Input);
                    command.Parameters.Add("ID_Number", OracleDbType.Varchar2, ID_Number, ParameterDirection.Input);
                    command.Parameters.Add("Status", OracleDbType.Varchar2, status, ParameterDirection.Input);
                    try
                    {
                        command.ExecuteNonQuery();
                        command.CommandText = "select user_id_seq.CURRVAL from dual";
                        UID = command.ExecuteScalar().ToString();
                        Console.WriteLine("Regist success, UID = " + UID);
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("错误码" + ex.ErrorCode.ToString());
                        throw;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // 处理异常
                Console.WriteLine(ex.ToString());
            }
            return UID;
        }
        public static void UpdatePassword(string User_ID, string New_Password)
        {
            // 更改信息
            try
            {
                using (OracleConnection connection = new OracleConnection(conStr))
                {
                    connection.Open();
                    OracleCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE USERSTEST SET password=:password " +
                        " where user_id=:user_id";
                    command.Parameters.Clear();
                    command.Parameters.Add("password", OracleDbType.Varchar2, New_Password, ParameterDirection.Input);
                    command.Parameters.Add("user_id", OracleDbType.Varchar2, User_ID, ParameterDirection.Input);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("修改密码出错，错误码" + ex.ErrorCode.ToString());

                        throw;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // 处理异常
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
