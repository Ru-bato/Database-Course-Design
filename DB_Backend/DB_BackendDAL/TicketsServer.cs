using DB_Backend.DB_backendDAL;
using DB_Backend.DB_BackendModel;
using System.Data;
using System.Drawing;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace DB_Backend.DB_BackendDAL
{
    public class TicketsServer
    {   
        public static DataTable SearchTickets(TicketsSearchModel model)
        {
            if (string.IsNullOrEmpty(model.DepartureStation)|| string.IsNullOrEmpty(model.ArrivalStation))
            {
                throw new ArgumentException("Query cannot be null or empty");
            }

            string sql = @"SELECT t.TRAIN_ID,t.PRICE,t.REMAINING_TICKETS,ts1.DEPARTURE_TIME,ts2.ARRIVAL_TIME
                           FROM TRAIN t
                           JOIN TRAINSTATION ts1 ON t.TRAIN_ID = ts1.TRAIN_ID
                           JOIN TRAINSTATION ts2 ON t.TRAIN_ID = ts2.TRAIN_ID
                           JOIN STATION s1 ON ts1.STATION_ID = s1.STATION_ID
                           JOIN STATION s2 ON ts2.STATION_ID = s2.STATION_ID
                           WHERE s1.STATION_NAME = :departureStation
                             AND s2.STATION_NAME = :arrivalStation
                             AND TO_DATE(ts1.DEPARTURE_TIME, 'HH24:MI') < TO_DATE(ts2.ARRIVAL_TIME, 'HH24:MI')"
            ;

            var parameters = new Dictionary<string, object> {
                { ":departureStation",  model.DepartureStation },
                { ":arrivalStation", model.ArrivalStation}
            };

            DataTable dt = DBServer.FetchData(sql, parameters);

            return dt;
        }

        public static DataTable GetPassenger(PassengerGetModle model)
        {
            if (string.IsNullOrEmpty(model.UserID))
            {
                throw new ArgumentException("Query cannot be null or empty");
            }

            string sql = @"SELECT u.USERNAME,u.IS_STUDENT,u.PHONE_NUMBER
                           FROM USERS u,USERPASSENGER up
                           WHERE up.PASSENGER_ID = u.USER_ID
                             AND up.USER_ID = :userId";

            var parameters = new Dictionary<string, object> {
                { ":userId",  model.UserID }
            };

            DataTable dt = DBServer.FetchData(sql,parameters);

            return dt;
        }

        public static bool BuyTickets(TicketsBuyModel model)
        {
            string sql= @"INSERT INTO ORDERLIST(ORDER_ID,USER_ID,TRAIN_ID,ORDER_STATUS,PRICE,TICKET_TYPE,PASSENGER_ID)
                         VALUES(,:user_id,:train_id,,:price,,:passenger_id)";

            var parameters = new Dictionary<string, object> {
                { ":userId",  model.UserID },
                { ":train_id", model.TrainID},
                { ":price",model.Price},
                { ":passenger_id",model.PassengerID}
            };

            return DBServer.ModifyDB(sql,parameters);
        }

        public static bool RefundTickets(TicketsRefundModel model)
        {
            string sql =@"DELETE FROM ORDERLIST
                          WHERE ORDER_ID =:orderId";

            var parameters = new Dictionary<string, object> {
                { ":orderId",  model.OrderId }
            };

            return DBServer.ModifyDB(sql);
        }

        public static DataTable ChangeTickets(TicketsChangeModel model)
        {
            string sql = @"";

            DataTable dt = DBServer.FetchData(sql);

            return dt;
        }

    }
}
