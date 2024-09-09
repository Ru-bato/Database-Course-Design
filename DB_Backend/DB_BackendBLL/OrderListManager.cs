using DB_Backend.DB_backendDAL;
using DB_Backend.DB_BackendDAL;
using Microsoft.AspNetCore.SignalR;
using System.Data;
using System.Net.Sockets;
namespace DB_Backend.DB_BackendBLL
{

    public class OrderListManager
    {
        public static int TotalTickets(int tickettype)
        {
            DataTable dt = OrderListServer.TotalTickets(tickettype);
            int sum = 0;


            // 确保 DataTable 中有数据
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // 确保数据可以转换为整数
                    if (int.TryParse(row[0].ToString(), out int value))
                    {
                        sum += value;
                    }
                }
            }

            return sum;
        }

        public static int TotalWait(int tickettype)
        {
            DataTable dt = OrderListServer.TotalWait(tickettype);
            int sum = 0;

            // 确保 DataTable 中有数据
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // 确保数据可以转换为整数
                    if (int.TryParse(row[0].ToString(), out int value))
                    {
                        sum += value;
                    }
                }
            }

            return sum;
        }


        public static int TotalMoney(int tickettype)
        {
            DataTable dt = OrderListServer.TotalMoney(tickettype);
            if (dt.Rows.Count > 0)
            {
                // Assumes the column name is "TotalPrice"
                object totalPriceObj = dt.Rows[0]["TotalPrice"];
                if (totalPriceObj != DBNull.Value)
                {
                    // Convert to int
                    return Convert.ToInt32(totalPriceObj);
                }
            }
            return 0; // Or handle as needed if no rows or null value
        }
    }
}
