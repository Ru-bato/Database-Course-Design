using DB_Backend.DB_backendDAL;
using System.Data;
using System.Runtime.CompilerServices;

namespace DB_Backend.DB_BackendBLL
{
    public class StationsManager
    {   
        // 获取所有的车站名 
        public static List<string> GetStationsNames()
        {
            var names = new List<string>();

            DataTable dt = StationsServer.GetStationsNames();
            names = ExtractStationName(dt);

            return names;
        }

        // 搜索车站名(根据关键词)
        public static List<string> SearchStationsByKW(string query) {
            var names = new List<string>();

            DataTable dt = StationsServer.SearchStationsByKW(query);
            names =ExtractStationName(dt);

            return names;
        }

        // 获取表中STATION_NAME
        private static List<string> ExtractStationName(DataTable dt)
        {
            var names = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["STATION_NAME"] != DBNull.Value)
                {
                    string? name = dr["STATION_NAME"].ToString();
                    if (name != null)
                    {
                        names.Add(name);
                    }
                }
            }

            return names;
        }
    }
}
