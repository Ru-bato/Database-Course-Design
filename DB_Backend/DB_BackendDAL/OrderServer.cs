using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using DB_Backend.DB_BackendModel;

namespace DB_Backend.DB_BackendDAL
{
    public class OrderServer
    {
        private readonly string _connectionString;

        // 使用依赖注入 (DI) 来获取配置
        public OrderServer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleDbConnection")
                ?? throw new ArgumentNullException(nameof(_connectionString), "Connection string cannot be null.");
        }

        // 获取数据库连接
        public OracleConnection GetConnection()
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            return connection;
        }

        // 创建订单
        public void CreateOrder(Orderlist order)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("INSERT INTO Orders (Order_id, User_id, Train_id, Orderstatus, Price, Passenger_id, Ticket_type) VALUES (:Order_id, :User_id, :Train_id, :Orderstatus, :Price, :Passenger_id, :Ticket_type)", connection))
                {
                    command.Parameters.Add(new OracleParameter("Order_id", order.Order_id));
                    command.Parameters.Add(new OracleParameter("User_id", order.User_id));
                    command.Parameters.Add(new OracleParameter("Train_id", order.Train_id));
                    command.Parameters.Add(new OracleParameter("Orderstatus", order.Orderstatus));
                    command.Parameters.Add(new OracleParameter("Price", order.Price));
                    command.Parameters.Add(new OracleParameter("Passenger_id", order.passenger_id));
                    command.Parameters.Add(new OracleParameter("Ticket_type", order.ticket_type));

                    command.ExecuteNonQuery();
                }
            }
        }

        // 读取订单信息
        public Orderlist? GetOrderById(string orderId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT * FROM Orders WHERE Order_id = :Order_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("Order_id", orderId));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Orderlist
                            {
                                Order_id = reader["Order_id"].ToString(),
                                User_id = reader["User_id"].ToString(),
                                Train_id = reader["Train_id"].ToString(),
                                Orderstatus = reader["Orderstatus"].ToString(),
                                Price = reader["Price"].ToString(),
                                passenger_id = reader["Passenger_id"].ToString(),
                                ticket_type = reader["Ticket_type"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // 根据User_id获取所有相关的乘车人
        public List<Orderlist> GetOrdersByUserId(string userId)
        {
            List<Orderlist> orders = new List<Orderlist>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT * FROM Orders WHERE User_id = :User_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("User_id", userId));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Orderlist
                            {
                                Order_id = reader["Order_id"].ToString(),
                                User_id = reader["User_id"].ToString(),
                                Train_id = reader["Train_id"].ToString(),
                                Orderstatus = reader["Orderstatus"].ToString(),
                                Price = reader["Price"].ToString(),
                                passenger_id = reader["Passenger_id"].ToString(),
                                ticket_type = reader["Ticket_type"].ToString()
                            });
                        }
                    }
                }
            }
            return orders;
        }

        // 更新订单信息
        public void UpdateOrder(Orderlist order)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("UPDATE Orders SET User_id = :User_id, Train_id = :Train_id, Orderstatus = :Orderstatus, Price = :Price, Passenger_id = :Passenger_id, Ticket_type = :Ticket_type WHERE Order_id = :Order_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("User_id", order.User_id));
                    command.Parameters.Add(new OracleParameter("Train_id", order.Train_id));
                    command.Parameters.Add(new OracleParameter("Orderstatus", order.Orderstatus));
                    command.Parameters.Add(new OracleParameter("Price", order.Price));
                    command.Parameters.Add(new OracleParameter("Passenger_id", order.passenger_id));
                    command.Parameters.Add(new OracleParameter("Ticket_type", order.ticket_type));
                    command.Parameters.Add(new OracleParameter("Order_id", order.Order_id));

                    command.ExecuteNonQuery();
                }
            }
        }

        // 删除订单
        public void DeleteOrder(string orderId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("DELETE FROM Orders WHERE Order_id = :Order_id", connection))
                {
                    command.Parameters.Add(new OracleParameter("Order_id", orderId));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
