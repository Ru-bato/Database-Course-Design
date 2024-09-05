using DB_Backend.DB_backendDAL;
using DB_Backend.DB_BackendDAL;
using DB_Backend.DB_BackendModel;
using System.Data;

namespace DB_Backend.DB_BackendBLL
{
    public class TicketsManager
    {

        public static List<TicketsSearchResponseModel> SearchTickets(TicketsSearchModel model) 
        {
            List<TicketsSearchResponseModel> responses = [];
            DataTable dt = TicketsServer.SearchTickets(model);
            foreach (DataRow dr in dt.Rows)
            {
                TicketsSearchResponseModel response = TicketsSearchResponseModel.ExtractModel(dr);
                responses.Add(response);
            }
            
            return responses;
        }

        public static PassengerResponseModel GetPassenger(PassengerGetModle model)
        {
            DataTable dt =TicketsServer.GetPassenger(model);
            PassengerResponseModel response = PassengerResponseModel.ExtractModel(dt);

            return response;
        }

        public static TicketsResponseModel BuyTickets(TicketsBuyModel model)
        {
            TicketsResponseModel response = new TicketsResponseModel
            {
                Is_success = TicketsServer.BuyTickets(model)
            };

            return response;
        }

        public static TicketsResponseModel RefundTickets(TicketsRefundModel model)
        {
            TicketsResponseModel response = new TicketsResponseModel
            {
                Is_success = TicketsServer.RefundTickets(model)
            };

            return response;
        }

        public static TicketsSearchModel ChangeTickets(TicketsChangeModel model)
        {
            DataTable dt = TicketsServer.ChangeTickets(model);

            TicketsSearchModel searchModel = TicketsSearchModel.ExtractModel(dt.Rows[0]);

            return searchModel;
        }
    }
}
