using System.Collections.Generic;
using System.Data;

namespace DB_Backend.DB_BackendModel
{
    /// <summary>
    /// 
    /// 搜索车票请求模型
    /// 
    /// 属性：
    /// ·起始站
    /// ·终点站
    /// 
    /// 方法：
    /// ·ExtractModel
    ///     功能：从一行数据中提取出模型
    ///     参数：要转换的数据
    ///     返回值：转换出的模型
    /// 
    /// </summary>
    public class TicketsSearchModel
    {
        public string? DepartureStation { set; get; }

        public string? ArrivalStation { set; get; }

        public string? Date { set; get; }

        public static TicketsSearchModel ExtractModel(DataRow dr)
        {
            TicketsSearchModel model = new TicketsSearchModel
            {   
                DepartureStation = dr["DEPARTURE_STATION"].ToString(),
                ArrivalStation = dr["ARRIVAL_STATION"].ToString()
            };

            return model;
        }
    }

    /// <summary>
    /// 
    /// 搜索车票响应模型(非中转)
    /// 
    /// 属性：
    /// ·车次ID
    /// ·起始站
    /// ·终点站
    /// ·出发时间
    /// ·到达时间
    /// ·历时
    /// ·票价
    /// ·余票
    /// 
    /// 方法：
    /// ·ExtractModel
    ///     功能：从一行数据中提取出模型
    ///     参数：要转换的数据
    ///     返回值：转换出的模型
    /// 
    /// </summary>
    public class TicketsSearchResponseModel
    { 
        public string? TrainID {  set; get; }

        public string? DepartureStation {  get; set; }

        public string? ArrivalStation {  get; set; }

        public string? DepartureTime { set; get; }

        public string? ArrivalTime { set; get; }

        public string? Duration { set; get; }

        public int? Price { set; get; }

        public int? TicketsNum { set; get; }

        public static TicketsSearchResponseModel ExtractModel(DataRow dr) {
            TicketsSearchResponseModel model = new TicketsSearchResponseModel {
                TrainID = dr["TRAIN_ID"].ToString(),
                DepartureStation = dr["DEPARTURE_STATION"].ToString(),
                ArrivalStation = dr["ARRIVAL_STATION"].ToString(),
                DepartureTime = dr["DEPARTURE_TIME"].ToString(),
                ArrivalTime = dr["ARRIVAL_TIME"].ToString(),
                Duration = (TimeSpan.Parse(dr["ARRIVAL_TIME"].ToString())
                                    - TimeSpan.Parse(dr["DEPARTURE_TIME"].ToString())).ToString(@"hh\:mm"),
                Price = dr["PRICE"] != DBNull.Value ? Convert.ToInt32(dr["PRICE"]) : (int?)null,
                TicketsNum = dr["REMAINING_TICKETS"] != DBNull.Value ? Convert.ToInt32(dr["REMAINING_TICKETS"]) : (int?)null
            };

            return model;
        }
    }

    public class PassengerGetModle
    { 
        public string? UserID { set; get; }
    }

    public class PassengerResponseModel
    { 
        public string? Name {  set; get; }

        public int? IsStudent { set; get; }

        public string? PhoneNumber { set; get; }

        public static PassengerResponseModel ExtractModel(DataTable dt) {
            PassengerResponseModel response = new PassengerResponseModel();

            foreach (DataRow dr in dt.Rows)
            {
                response.Name = dr["USERNAME"].ToString();
                response.IsStudent = dr["IS_STUDENT"] != DBNull.Value ? Convert.ToInt32(dr["IS_STUDENT"]) : (int?)null; ;
                response.PhoneNumber = dr["PHONE_NUMBER"].ToString();
            }

            return response;
        }
    }

    public class TicketsBuyModel
    {
        public string? UserID {  get; set; }

        public string? TrainID {  set; get; }

        public int? Price { set; get; }
        
        public string? PassengerID {  set; get; }
    }

    public class TicketsResponseModel
    {
        public bool Is_success { set; get; }
    }

    public class TicketsRefundModel
    { 
        public string? OrderId {  set; get; }
    }

    public class TicketsChangeModel
    { 
        public string? OrderId { set; get; }

    }
}
