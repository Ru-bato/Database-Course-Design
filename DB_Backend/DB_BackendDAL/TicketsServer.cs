using DB_Backend.DB_backendDAL;
using DB_Backend.DB_BackendModel;
using System.Data;
using System.Drawing;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace DB_Backend.DB_BackendDAL
{
    public class TicketsServer
    {   
        /// <summary>
        /// 搜索车票数据访问函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DataTable SearchTickets(TicketsSearchModel model,bool middle =false)
        {
            if (string.IsNullOrEmpty(model.DepartureStation)|| string.IsNullOrEmpty(model.ArrivalStation))
            {
                throw new ArgumentException("Query cannot be null or empty");
            }

            string sql = @"SELECT t.TRAIN_ID AS TRAIN_ID,
                                  s1.STATION_NAME AS DEPARTURE_STATION,
                                  s2.STATION_NAME AS ARRIVAL_STATION,
                                  ts1.DEPARTURE_TIME AS DEPARTURE_TIME,
                                  ts2.ARRIVAL_TIME AS ARRIVAL_TIME,
                                  t.PRICE AS PRICE,
                                  t.REMAINING_TICKETS AS TICKETS_NUM
                             FROM TRAIN t
                             JOIN TRAINSTATION ts1 ON t.TRAIN_ID = ts1.TRAIN_ID
                             JOIN TRAINSTATION ts2 ON t.TRAIN_ID = ts2.TRAIN_ID
                             JOIN STATION s1 ON ts1.STATION_ID = s1.STATION_ID
                             JOIN STATION s2 ON ts2.STATION_ID = s2.STATION_ID
                            WHERE t.DEPARTURE_TIME LIKE :mydate
                              AND s1.STATION_NAME = :departureStation
                              AND s2.STATION_NAME = :arrivalStation
                              AND TO_DATE(ts1.DEPARTURE_TIME, 'HH24:MI') < TO_DATE(ts2.ARRIVAL_TIME, 'HH24:MI')";

            var parameters = new Dictionary<string, object> {
                { ":mydate","%"+model.myDate+"%"},
                { ":departureStation", model.DepartureStation},
                { ":arrivalStation", model.ArrivalStation},
            };

            DataTable dt = DBServer.FetchData(sql, parameters);

            return dt;
        }

        /// <summary>
        /// 获取乘车人数据访问函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DataTable GetPassenger(PassengerGetModle model)
        {
            if (string.IsNullOrEmpty(model.UserID))
            {
                throw new ArgumentException("Query cannot be null or empty");
            }

            string sql = @"SELECT u.USERNAME,u.IS_STUDENT,u.PHONE_NUMBER,u.USER_ID AS PASSENGER_ID
                           FROM USERSTEST u,PASSENGERS p
                           WHERE p.PASSENGER_ID = u.USER_ID
                             AND p.USER_ID = :userID";

            var parameters = new Dictionary<string, object> {
                { ":userID",  model.UserID }
            };

            DataTable dt = DBServer.FetchData(sql,parameters);

            return dt;
        }

        /// <summary>
        /// 减少或增加车票数据操作函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool ReduceOrAddTickets(TicketsReduceOrAddModel model,bool reduce = true)
        {
            if (string.IsNullOrEmpty(model.TrainID)) {
                throw new ArgumentException("Query cannot be null or empty");
            }

            var parameters = new Dictionary<string, object> {
                { ":trainID",model.TrainID},
            };

            if (reduce == true)
            {
                string sql = @"UPDATE TRAIN
                                  SET REMAINING_TICKETS = REMAINING_TICKETS -1
                                WHERE TRAIN_ID = :trainID
                                  AND REMAINING_TICKETS > 0";
                return DBServer.ModifyDB(sql, parameters);
            }
            else
            {
                string sql = @"UPDATE TRAIN
                               SET REMAINING_TICKETS = REMAINING_TICKETS + 1
                               WHERE TRAIN_ID = :trainID";
                return DBServer.ModifyDB(sql, parameters);
            }
            
        }

        /// <summary>
        /// 创建订单数据操作函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CreateOrder(CreateOrderModel model)
        {
            if (string.IsNullOrEmpty(model.UserID)||
                string.IsNullOrEmpty(model.TrainID)||
                string.IsNullOrEmpty(model.PassengerID)||
                string.IsNullOrEmpty(model.TicketType)
                ) {
                throw new ArgumentException("Query cannot be null or empty");
            }

            string maxID_sql = "SELECT MAX(TO_NUMBER(ORDER_ID))+1 AS ORDER_ID FROM ORDERLIST";
            string orderID = "0" + DBServer.FetchData(maxID_sql).Rows[0]["ORDER_ID"].ToString();

            string orderStatus = model.IsWaiting ? "wait" : "unpaid";

            var parameters = new Dictionary<string, object> {
                { ":orderID", orderID },
                { ":userID",  model.UserID },
                { ":trainID",  model.TrainID },
                { ":orderStatus",orderStatus},
                { ":price",model.Price},
                { ":ticketType",model.TicketType},
                { ":passengerID",model.PassengerID},
            };

            string sql = @"INSERT INTO ORDERLIST(ORDER_ID,USER_ID,TRAIN_ID,ORDER_STATUS,PRICE,TICKET_TYPE,PASSENGER_ID)
                           VALUES(:orderID,:userID,:trainID,:orderStatus,:price,:ticketType,:passengerID)";

            return DBServer.ModifyDB(sql,parameters);
        }

        /// <summary>
        /// 支付订单数据操作函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool PayOrder(PayOrderModel model)
        {
            if (string.IsNullOrEmpty(model.OrderID))
            {
                throw new ArgumentException("Query cannot be null or empty");
            }

            var parameters = new Dictionary<string, object> {
                { ":orderID",model.OrderID}
            };

            string sql_trainID = "SELECT DISTINCT TRAIN_ID FROM ORDERLIST WHERE ORDER_ID = :orderID";
            string trainID = DBServer.FetchData(sql_trainID,parameters).Rows[0]["TRAIN_ID"].ToString();

            TicketsReduceOrAddModel Rmodel = new TicketsReduceOrAddModel
            {
                TrainID = trainID
            };
            if (ReduceOrAddTickets(Rmodel,reduce:true)) {
                string sql = @"UPDATE ORDERLIST
                               SET ORDER_STATUS = 'paid'
                               WHERE ORDER_ID = :orderID";
                return DBServer.ModifyDB(sql,parameters);
            }
            return false;
        }

        /// <summary>
        /// 退票数据操作函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool RefundTickets(TicketsRefundModel model)
        {
            if (string.IsNullOrEmpty(model.OrderID)) {
                throw new ArgumentException("Query cannot be null or empty");
            }

            var parameters = new Dictionary<string, object> {
                { ":orderID",model.OrderID}
            };

            if (model.IsPaid) {
                string sql_trainID = "SELECT DISTINCT TRAIN_ID FROM ORDERLIST WHERE ORDER_ID = :orderID";
                string trainID = DBServer.FetchData(sql_trainID, parameters).Rows[0]["TRAIN_ID"].ToString();

                TicketsReduceOrAddModel Rmodel = new TicketsReduceOrAddModel
                {
                    TrainID = trainID
                };

                if (ReduceOrAddTickets(Rmodel, reduce: false))
                {
                    WaitTickets(trainID);
                }
                else {
                    return false;
                }
            }

            string sql = @"DELETE FROM ORDERLIST
                           WHERE ORDER_ID = :orderID";

            return DBServer.ModifyDB(sql,parameters);
        }

        /// <summary>
        /// 补票数据操作函数
        /// </summary>
        /// <param name="trainID"></param>
        /// <returns></returns>
        public static void WaitTickets(string trainID)
        {
            TicketsReduceOrAddModel Rmodel = new TicketsReduceOrAddModel
            {
                TrainID = trainID
            };
            var parameters = new Dictionary<string, object> {
                    { ":trainID",trainID}
            };
            string sql = @"UPDATE ORDERLIST
                            SET ORDER_STATUS = 'paid'
                            WHERE ORDER_ID = (
                                SELECT ORDER_ID
                                FROM (
                                    SELECT ORDER_ID
                                    FROM ORDERLIST
                                    WHERE TRAIN_ID = :trainID
                                    AND ORDER_STATUS = 'wait'
                                    ORDER BY ORDER_ID
                                )
                                WHERE ROWNUM = 1
                            )";
            if (DBServer.ModifyDB(sql, parameters)) {
                ReduceOrAddTickets(Rmodel,reduce:true);
            }

            return ;
        }

        /// <summary>
        /// 改签数据操作函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DataTable ChangeTickets(TicketsChangeModel model)
        {
            string sql = @"";

            DataTable dt = DBServer.FetchData(sql);

            return dt;
        }

    }
}
