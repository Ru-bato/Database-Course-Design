
using DB_Backend.DB_backendDAL;
using System.Data;

namespace DB_Backend.DB_BackendDAL
{
    public class OrderListServer
    {
        public static DataTable TotalTickets(int tickettype)
        {
            string ticketTypeCondition;
            switch (tickettype)
            {
                case 1:
                    ticketTypeCondition = "adult";
                    break;
                case 2:
                    ticketTypeCondition = "student";
                    break;
                default:
                    throw new ArgumentException("Invalid ticket type");
            }

            string sql = $@"SELECT COUNT(*) FROM ORDERLIST WHERE TICKET_TYPE = '{ticketTypeCondition}' AND ORDER_STATUS = 'paid'";
          
            DataTable dt = DBServer.FetchData(sql);
            return dt;
        }

        public static DataTable TotalMoney(int tickettype)
        {
            string ticketTypeCondition;
            switch (tickettype)
            {
                case 1:
                    ticketTypeCondition = "adult";
                    break;
                case 2:
                    ticketTypeCondition = "student";
                    break;
                default:
                    throw new ArgumentException("Invalid ticket type");
            }
            string sql = $@"SELECT SUM(PRICE) AS TotalPrice FROM ORDERLIST WHERE TICKET_TYPE ='{ticketTypeCondition}'";
            DataTable dt = DBServer.FetchData(sql);
            return dt;
        }
    }
}
