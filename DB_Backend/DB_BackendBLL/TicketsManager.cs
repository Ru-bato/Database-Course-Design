using DB_Backend.DB_backendDAL;
using DB_Backend.DB_BackendDAL;
using DB_Backend.DB_BackendModel;
using System.Data;

namespace DB_Backend.DB_BackendBLL
{
    public class TicketsManager
    {
        /// <summary>
        /// 搜索车票处理函数(非中转)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<TicketsSearchResponseModel> SearchTickets(TicketsSearchModel model) 
        {
            List<TicketsSearchResponseModel> responses = [];
            DataTable dt = TicketsServer.SearchTickets(model,false);
            foreach (DataRow dr in dt.Rows)
            {
                TicketsSearchResponseModel response = TicketsSearchResponseModel.ExtractModel(dr);
                responses.Add(response);
            }
            
            return responses;
        }

        /// <summary>
        /// 搜索车票处理函数(中转)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<TicketsSearchResponseModel_middle> SearchTicketsMiddle(TicketsSearchModel model)
        {
            List<TicketsSearchResponseModel_middle> responses = [];
            DataTable dt = TicketsServer.SearchTickets(model,true);
            foreach (DataRow dr in dt.Rows)
            {
                TicketsSearchResponseModel_middle response = TicketsSearchResponseModel_middle.ExtractModel(dr);
                responses.Add(response);
            }

            return responses;
        }

        /// <summary>
        /// 获取乘车人处理函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<PassengerResponseModel> GetPassenger(PassengerGetModle model)
        {
            List<PassengerResponseModel> responses = [];

            DataTable dt =TicketsServer.GetPassenger(model);
            foreach (DataRow dr in dt.Rows) {
                PassengerResponseModel response = PassengerResponseModel.ExtractModel(dr);
                responses.Add(response);
            }

            return responses;
        }

        /// <summary>
        /// 减少车票处理函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TicketsResponseModel ReduceTickets(TicketsReduceModel model)
        {
            TicketsResponseModel response = new TicketsResponseModel
            {
                Is_success = TicketsServer.ReduceTickets(model)
            };

            return response;
        }

        /// <summary>
        /// 创建订单处理函数
        /// </summary>
        /// <returns></returns>
        public static TicketsResponseModel CreateOrder(CreateOrderModel model)
        {
            TicketsResponseModel response = new TicketsResponseModel
            {
                Is_success = TicketsServer.CreateOrder(model)
            };

            return response;
        }

        /// <summary>
        /// 退票处理函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TicketsResponseModel RefundTickets(TicketsRefundModel model)
        {
            TicketsResponseModel response = new TicketsResponseModel
            {
                Is_success = TicketsServer.RefundTickets(model)
            };

            return response;
        }

        /// <summary>
        /// 改签处理函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TicketsSearchModel ChangeTickets(TicketsChangeModel model)
        {
            DataTable dt = TicketsServer.ChangeTickets(model);

            TicketsSearchModel searchModel = TicketsSearchModel.ExtractModel(dt.Rows[0]);

            return searchModel;
        }
    }
}
