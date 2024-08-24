using DB_Backend.DB_BackendModel;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DB_Backend.DB_BackendDAL
{
    public class UserServer
    {
        public static string conStr = "User ID=system;Password=Db_12306;Data Source=47.100.21.14:1521/orcl";
        public static User GetUserByUID(string UID)
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
                command.CommandText = "SELECT * FROM USERS WHERE USER_ID=3";
                //command.Parameters.Clear();
                //command.Parameters.Add("user_id", OracleDbType.Varchar2, UID, ParameterDirection.Input);
                Console.WriteLine("UID = " +  UID);
                Console.WriteLine("DEBUG: SQL = " + command.CommandText + " SQL END");
                try
                {
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user.User_ID = reader["USER_ID"].ToString();
                        user.Username = reader["Username"].ToString();
                        //user.Account_Status = reader["Account_Status"].ToString();
                        //user.Address = reader["Address"].ToString();
                        user.Password = reader["Password"].ToString();
                        //user.Phone_Number = reader["Phone_Number"].ToString();
                        //user.Role = reader["Role"].ToString();
                        //user.Avatar = GetAvatar(reader["User_ID"].ToString());
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
                }
            }
            return user;
        }

        public static string InsertUser(string Username, string pwd)
        {
            string UID = "-1";
            try
            {
                using (OracleConnection connection = new OracleConnection(conStr))
                {
                    connection.Open();
                    OracleCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    string account_status = "In Good Standing";
                    command.CommandText = "INSERT INTO User (User_ID, Username, password)" +
                        "VALUES (user_id_seq.NEXTVAL, :user_name, :password)";
                    command.Parameters.Clear();
                    command.Parameters.Add("user_name", OracleDbType.Varchar2, Username, ParameterDirection.Input);
                    command.Parameters.Add("password", OracleDbType.Varchar2, pwd, ParameterDirection.Input);
                    //command.Parameters.Add("phone_number", OracleDbType.Varchar2, phoneNumber, ParameterDirection.Input);
                    //command.Parameters.Add("account_status", OracleDbType.Varchar2, account_status, ParameterDirection.Input);
                    //command.Parameters.Add("address", OracleDbType.Varchar2, Address, ParameterDirection.Input);
                    //command.Parameters.Add("Role", OracleDbType.Varchar2, Role, ParameterDirection.Input);
                    try
                    {
                        command.ExecuteNonQuery();
                        command.CommandText = "select user_id_seq.CURRVAL from dual";
                        UID = command.ExecuteScalar().ToString();
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
    }
}
