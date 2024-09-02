using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using DB_BackendModel;

namespace DB_BackendDAL
{
    public class PassengerServer
    {
        private readonly string _connectionString;

        public PassengerServer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleDbConnection")
                ?? throw new ArgumentNullException(nameof(_connectionString), "Connection string cannot be null.");
        }

        public OracleConnection GetConnection()
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            return connection;
        }

        // 创建乘车人
        public void CreatePassenger(Passenger passenger)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("INSERT INTO Passengers (passenger_id, User_id, Passenger_name, Id_number) VALUES (:passenger_id, :User_id, :Passenger_name, :Id_number)", connection))
                {
                    command.Parameters.Add(new OracleParameter("passenger_id", passenger.passenger_id));
                    command.Parameters.Add(new OracleParameter("User_id", passenger.User_id));
                    command.Parameters.Add(new OracleParameter("Passenger_name", passenger.Passenger_name));
                    command.Parameters.Add(new OracleParameter("Id_number", passenger.Id_number));

                    command.ExecuteNonQuery();
                }
            }
        }

        // 读取乘车人信息
        public Passenger? GetPassengerById(string passengerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT * FROM Passengers WHERE passenger_id = :passenger_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("passenger_id", passengerId));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Passenger
                            {
                                passenger_id = reader["passenger_id"].ToString(),
                                User_id = reader["User_id"].ToString(),
                                Passenger_name = reader["Passenger_name"].ToString(),
                                Id_number = reader["Id_number"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // 根据User_id获取所有相关的乘车人
        public List<Passenger> GetPassengersByUserId(string userId)
        {
            List<Passenger> passengers = new List<Passenger>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT * FROM Passengers WHERE User_id = :User_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("User_id", userId));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            passengers.Add(new Passenger
                            {
                                passenger_id = reader["passenger_id"].ToString(),
                                User_id = reader["User_id"].ToString(),
                                Passenger_name = reader["Passenger_name"].ToString(),
                                Id_number = reader["Id_number"].ToString()
                            });
                        }
                    }
                }
            }
            return passengers;
        }

        // 更新乘车人信息
        public void UpdatePassenger(Passenger passenger)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("UPDATE Passengers SET User_id = :User_id, Passenger_name = :Passenger_name, Id_number = :Id_number WHERE passenger_id = :passenger_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("User_id", passenger.User_id));
                    command.Parameters.Add(new OracleParameter("Passenger_name", passenger.Passenger_name));
                    command.Parameters.Add(new OracleParameter("Id_number", passenger.Id_number));
                    command.Parameters.Add(new OracleParameter("passenger_id", passenger.passenger_id));

                    command.ExecuteNonQuery();
                }
            }
        }

        // 删除乘车人
        public void DeletePassenger(string passengerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("DELETE FROM Passengers WHERE passenger_id = :passenger_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("passenger_id", passengerId));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

