using api.DB_backendDAL;
using System.Data;

namespace DB_Backend.DB_BackendDAL
{
    public class ScreenServer
    {
        public static DataTable SearchTrainsByDepartureStation(string stationName)
        {
            if (string.IsNullOrEmpty(stationName))
            {
                throw new ArgumentNullException("Query cannot be null or empty", nameof(stationName));
            }

            string sql = @"SELECT TRAIN.TRAIN_ID, TRAIN.ARRIVAL_STATION, TRAINSTATION.DEPARTURE_TIME, TRAIN_ENTRANCE, DEPART_TRAIN_STATUS
                           FROM TRAIN, STATION, TRAINSTATION
                           WHERE TRAIN.TRAIN_ID = TRAINSTATION.TRAIN_ID AND STATION.STATION_ID = TRAINSTATION.STATION_ID AND STATION.STATION_NAME = :stationName";

            var parameters = new Dictionary<string, object>
            {
                { ":stationName", stationName }
            };

            DataTable dt = DBServer.FetchData(sql, parameters); ;
            return dt;
        }

        public static DataTable SearchTrainsByArrivalStation(string stationName)
        {
            if (string.IsNullOrEmpty(stationName))
            {
                throw new ArgumentNullException("Query cannot be null or empty", nameof(stationName));
            }

            string sql = @"SELECT TRAIN.TRAIN_ID, TRAIN.DEPARTURE_STATION, TRAINSTATION.ARRIVAL_TIME, TRAIN_EXIT, ARRIVE_TRAIN_STATUS
                           FROM TRAIN, STATION, TRAINSTATION
                           WHERE TRAIN.TRAIN_ID = TRAINSTATION.TRAIN_ID AND STATION.STATION_ID = TRAINSTATION.STATION_ID AND STATION.STATION_NAME = :stationName";

            var parameters = new Dictionary<string, object>
            {
                { ":stationName", stationName }
            };

            DataTable dt = DBServer.FetchData(sql, parameters); ;
            return dt;
        }
    }
}
