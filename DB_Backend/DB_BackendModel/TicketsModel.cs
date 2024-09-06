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
                TicketsNum = dr["TICKETS_NUM"] != DBNull.Value ? Convert.ToInt32(dr["TICKETS_NUM"]) : (int?)null
            };

            return model;
        }
    }

    /// <summary>
    /// 
    /// 搜索车票响应模型(中转)
    /// 
    /// 属性：
    /// ·车次1ID
    /// ·车次2ID
    /// ·起始站
    /// ·中转站
    /// ·终点站
    /// ·出发时间
    /// ·中转到达时间
    /// ·中转出发时间
    /// ·到达时间
    /// ·历时
    /// ·中转时间
    /// ·票价
    /// ·余票1
    /// ·余票2
    /// 
    /// 方法：
    /// ·ExtractModel
    ///     功能：从一行数据中提取出模型
    ///     参数：要转换的数据
    ///     返回值：转换出的模型
    /// 
    /// </summary>
    public class TicketsSearchResponseModel_middle
    {
        public string? TrainID_1 { set; get; }

        public string? TrainID_2 { set; get; }

        public string? DepartureStation { get; set; }

        public string? MiddleStation { get; set; }

        public string? ArrivalStation { get; set; }

        public string? DepartureTime { set; get; }

        public string? ArrivalTime_middle { set; get; }

        public string? DepartureTime_middle { set; get; }

        public string? ArrivalTime { set; get; }

        public string? Duration { set; get; }

        public string? Duration_middle { set; get; }

        public int? Price { set; get; }

        public int? TicketsNum_1 { set; get; }

        public int? TicketsNum_2 { set; get; }

        public static TicketsSearchResponseModel_middle ExtractModel(DataRow dr){
                TicketsSearchResponseModel_middle model = new TicketsSearchResponseModel_middle
                {
                    TrainID_1 = dr["TRAIN_ID_1"].ToString(),
                    TrainID_2 = dr["TRAIN_ID_2"].ToString(),
                    DepartureStation = dr["DEPARTURE_STATION"].ToString(),
                    MiddleStation = dr["MIDDLE_STATION"].ToString(),
                    ArrivalStation = dr["ARRIVAL_STATION"].ToString(),
                    DepartureTime = dr["DEPARTURE_TIME"].ToString(),
                    ArrivalTime_middle = dr["ARRIVAL_TIME_MIDDLE"].ToString(),
                    DepartureTime_middle = dr["DEPARTURE_TIME_MIDDLE"].ToString(),
                    ArrivalTime = dr["ARRIVAL_TIME"].ToString(),
                    Duration = (TimeSpan.Parse(dr["ARRIVAL_TIME"].ToString())
                                        - TimeSpan.Parse(dr["DEPARTURE_TIME"].ToString())).ToString(@"hh\:mm"),
                    Duration_middle = (TimeSpan.Parse(dr["DEPARTURE_TIME_MIDDLE"].ToString())
                                        - TimeSpan.Parse(dr["ARRIVAL_TIME_MIDDLE"].ToString())).ToString(@"hh\:mm"),
                    Price = dr["PRICE"] != DBNull.Value ? Convert.ToInt32(dr["PRICE"]) : (int?)null,
                    TicketsNum_1 = dr["TICKETS_NUM_1"] != DBNull.Value ? Convert.ToInt32(dr["TICKETS_NUM_1"]) : (int?)null,
                    TicketsNum_2 = dr["TICKETS_NUM_2"] != DBNull.Value ? Convert.ToInt32(dr["TICKETS_NUM_2"]) : (int?)null,
                };

                return model;
            }
        }

    /// <summary>
    /// 
    /// 获取乘车人请求模型
    /// 
    /// 属性：
    /// ·用户ID
    /// 
    /// </summary>
    public class PassengerGetModle
    { 
        public string? UserID { set; get; }
    }

    /// <summary>
    /// 
    /// 获取乘车人响应模型
    /// 
    /// 属性：
    /// ·乘车人姓名
    /// ·是否为学生
    /// ·电话号码
    /// 
    /// 方法：
    /// ·ExtractModel
    ///     功能：从一行数据中提取出模型
    ///     参数：要转换的数据
    ///     返回值：转换出的模型
    /// 
    /// </summary>
    public class PassengerResponseModel
    { 
        public string? Name {  set; get; }

        public string? IsStudent { set; get; }

        public string? PhoneNumber { set; get; }

        public static PassengerResponseModel ExtractModel(DataTable dt) {
            PassengerResponseModel response = new PassengerResponseModel();

            foreach (DataRow dr in dt.Rows)
            {
                response.Name = dr["USERNAME"].ToString();
                response.IsStudent = dr["IS_STUDENT"].ToString();
                response.PhoneNumber = dr["PHONE_NUMBER"].ToString();
            }

            return response;
        }
    }

    /// <summary>
    /// 
    /// 减少车票请求模型
    /// 
    /// 属性:
    /// ·订单ID
    /// 
    /// </summary>
    public class TicketsReduceModel
    {
        public string? orderID {  set; get; }

    }

    /// <summary>
    /// 
    /// 创建订单模型
    /// 
    /// 属性：
    /// ·用户ID
    /// ·车次ID
    /// ·票价
    /// ·乘车人ID
    /// 
    /// </summary>
    public class  CreateOrderModel
    {
        public string? UserID { get; set; }

        public string? TrainID { set; get; }

        public int? Price { set; get; }

        public string? PassengerID { set; get; }
    }

    /// <summary>
    /// 
    /// 退票请求模型
    /// 
    /// 属性：
    /// ·订单ID
    /// 
    /// </summary>
    public class TicketsRefundModel
    { 
        public string? OrderId {  set; get; }
    }

    /// <summary>
    /// 
    /// 改签请求模型
    /// 
    /// 属性：
    /// ·订单ID
    /// 
    /// </summary>
    public class TicketsChangeModel
    { 
        public string? OrderId { set; get; }

    }

    /// <summary>
    /// 
    /// 购票、退票、改签响应模型
    /// 
    /// 属性：
    /// ·是否成功
    /// 
    /// </summary>
    public class TicketsResponseModel
    {
        public bool Is_success { set; get; }
    }
}
