using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DB_Backend.DB_backendDAL
{
    public class DBServer
    {
        public static readonly string conStr = "User Id=system;Password=Db_12306;Data Source=//47.100.21.14:1521/orcl;";

        // 简单查询
        public static DataTable FetchData(string sql)
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

        // 含参数查询
        public static DataTable FetchData(string sql, Dictionary<string, object> parameters)
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
        /// <summary>
        /// 含参数修改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
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
