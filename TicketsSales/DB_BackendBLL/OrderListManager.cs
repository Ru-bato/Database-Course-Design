using DB_Backend.DB_BackendDAL;
using System.Data;
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
    }
}
