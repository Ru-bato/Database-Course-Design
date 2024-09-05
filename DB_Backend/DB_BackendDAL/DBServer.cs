using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DB_Backend.DB_backendDAL
{
    public class DBServer
    {
        public static readonly string conStr = "User Id=system;Password=Db_12306;Data Source=//47.100.21.14:1521/orcl;";

        // 含参数查询
        public static DataTable FetchData(string sql, Dictionary<string, object>? parameters = null)
        {
            DataTable dt = new DataTable();

            using (OracleConnection connection = new OracleConnection(conStr))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = sql;

                        // 增加参数
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.Add(new OracleParameter(param.Key, param.Value));
                            }
                        }

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dt;
        }

        // 含参数修改
        public static bool ModifyDB(string sql, Dictionary<string, object>? parameters = null)
        {
            bool is_success = false;

            using (OracleConnection connection = new OracleConnection(conStr))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = sql;

                        // 增加参数
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.Add(new OracleParameter(param.Key, param.Value));
                            }
                        }

                        int affectedRows = command.ExecuteNonQuery();
                        is_success = affectedRows > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return is_success;
        }
    }

}
