using DB_Backend.DB_BackendModel;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DB_Backend.DB_BackendDAL
{
    public class UserServer
    {
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
