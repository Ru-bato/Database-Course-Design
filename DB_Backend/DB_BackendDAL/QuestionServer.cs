using DB_Backend.DB_BackendModel;
using DB_Backend.DB_backendDAL;
using System.Data;

namespace DB_Backend.DB_BackendDAL
{
    public class QuestionServer
    {
        public static DataTable ReturnList()
        {
            string sql = @"SELECT *
                       FROM QUESTION";
            DataTable dt = DBServer.FetchData(sql);
            return dt;
           
        }

        public static DataTable SearchInSQL(string questionSearch)
        {
            string sql = @"SELECT QUESTION_TEXT, QUESTION_ANSWER FROM QUESTION WHERE QUESTION_TEXT LIKE '%' || :questionSearch || '%'";
            // 创建参数字典
            var parameters = new Dictionary<string, object>
    {
        { "@questionSearch", questionSearch }
    };

            // 使用 DBServer.FetchData 方法执行查询并返回 DataTable
            DataTable dt = DBServer.FetchData(sql, parameters);
            return dt;
        }
    }
}
