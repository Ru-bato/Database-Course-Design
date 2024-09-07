using DB_Backend.DB_BackendDAL;
using System.Data;
using System.Runtime.CompilerServices;

namespace DB_Backend.DB_BackendBLL
{
    public class FoodManager
    {
        // 获取所有的食物名 
        public static List<string> GetFoodNames()
        {
            var names = new List<string>();

            DataTable dt = FoodServer.GetFoodNames();
            names = ExtractFoodName(dt);
            return names;
        }
        // 获取表中FOOD_NAME
        private static List<string> ExtractFoodName(DataTable dt)
        {
            var names = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["FOOD_NAME"] != DBNull.Value)
                {
                    string? name = dr["FOOD_NAME"].ToString();
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
