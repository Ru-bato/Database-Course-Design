using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DB_Backend.DB_backendDAL
{
    public class StationsServer
    {
        // 获取车站表信息
        public static DataTable GetStations()
        {
            string sql = "";
            DataTable dt = DBServer.FetchData(sql);
            return dt;
        }

        // 获取车站名信息
        public static DataTable GetStationsNames()
        {
            string sql = @"SELECT STATION_NAME
                           FROM STATION";
            DataTable dt = DBServer.FetchData(sql);
            return dt;
        }

        // 搜索车站
        public static DataTable SearchStationsByKW(string keyword)
        {
            // 关键字不能为空
            if (string.IsNullOrEmpty(keyword))
            {
                throw new ArgumentException("Query cannot be null or empty", nameof(keyword));
            }

            string sql = @"SELECT STATION_NAME 
                           FROM STATION WHERE
                           STATION_NAME LIKE :stationName";

            var parameters = new Dictionary<string, object> {
                { ":stationName", "%" + keyword + "%" }
            };

            DataTable dt = DBServer.FetchData(sql, parameters);
            return dt;
        }

    }
}
