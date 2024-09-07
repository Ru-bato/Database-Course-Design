using DB_Backend.DB_backendDAL;
using DB_Backend.DB_BackendDAL;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DB_Backend.DB_BackendDAL
{
    public class FoodServer
    {
        // 获取食物表信息
        public static DataTable GetFood()
        {
            string sql = "";
            DataTable dt = DBServer.FetchData(sql);
            return dt;
        }
        // 获取食物信息
        public static DataTable GetFoodNames()
        {
            string sql = @"SELECT FOOD_NAME
                           FROM FOOD";
            DataTable dt = DBServer.FetchData(sql);
            return dt;
        }
    }
}