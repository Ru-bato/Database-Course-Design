using DB_Backend.DB_BackendDAL;
using DB_Backend.DB_BackendModel;
using System.Data;

namespace DB_Backend.DB_BackendBLL
{
    public class ScreenManager
    {
        public static List<TrainInfo> SearchTrainsByDepartureStation(string query)
        {
            var trains = new List<TrainInfo>();

            DataTable dt = ScreenServer.SearchTrainsByDepartureStation(query);
            trains = ExtractDepartureTrainsInfo(dt);

            return trains;
        }

        public static List<TrainInfo> SearchTrainsByArrivalStation(string query)
        {
            var trains = new List<TrainInfo>();

            DataTable dt = ScreenServer.SearchTrainsByArrivalStation(query);
            trains = ExtractArrivalTrainsInfo(dt);

            return trains;
        }

        public static List<TrainInfo> ExtractDepartureTrainsInfo(DataTable dt)
        {
            var trains = new List<TrainInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TRAIN_ID"] != DBNull.Value && 
                    dr["ARRIVAL_STATION"] != DBNull.Value && 
                    dr["DEPARTURE_TIME"] != DBNull.Value && 
                    dr["TRAIN_ENTRANCE"] != DBNull.Value && 
                    dr["DEPART_TRAIN_STATUS"] != DBNull.Value)
                {
                    var info = new TrainInfo();

                    string? id = dr["TRAIN_ID"].ToString();
                    string? station = dr["ARRIVAL_STATION"].ToString();
                    string? _time = dr["DEPARTURE_TIME"].ToString();
                    string? entrance = dr["TRAIN_ENTRANCE"].ToString();
                    string? status = dr["DEPART_TRAIN_STATUS"].ToString();

                    if (id != null && station != null && _time != null && entrance != null && status != null)
                    {
                        info.number = id; info.station = station; info._time = _time; info.check = entrance; info.status = status;
                    }

                    trains.Add(info);
                }
            }

            return trains;
        }

        public static List<TrainInfo> ExtractArrivalTrainsInfo(DataTable dt)
        {
            var trains = new List<TrainInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TRAIN_ID"] != DBNull.Value &&
                    dr["DEPARTURE_STATION"] != DBNull.Value &&
                    dr["ARRIVAL_TIME"] != DBNull.Value &&
                    dr["TRAIN_EXIT"] != DBNull.Value &&
                    dr["ARRIVE_TRAIN_STATUS"] != DBNull.Value)
                {
                    var info = new TrainInfo();

                    string? id = dr["TRAIN_ID"].ToString();
                    string? station = dr["DEPARTURE_STATION"].ToString();
                    string? _time = dr["ARRIVAL_TIME"].ToString();
                    string? exit = dr["TRAIN_EXIT"].ToString();
                    string? status = dr["ARRIVE_TRAIN_STATUS"].ToString();

                    if (id != null && station != null && _time != null && exit != null && status != null)
                    {
                        info.number = id; info.station = station; info._time = _time; info.check = exit; info.status = status;
                    }

                    trains.Add(info);
                }
            }

            return trains;
        }
    }
}
