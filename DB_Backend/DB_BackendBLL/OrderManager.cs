using DB_Backend.DB_BackendDAL;
using DB_Backend.DB_BackendModel;
using System;

namespace DB_Backend.DB_BackendBLL
{
    public class OrderManager
    {
        private readonly OrderServer _orderServer;

        public OrderManager(OrderServer orderServer)
        {
            _orderServer = orderServer;
        }

        // 创建订单
        public void CreateOrder(Orderlist order)
        {
            if (string.IsNullOrWhiteSpace(order.User_id) || string.IsNullOrWhiteSpace(order.Train_id))
            {
                throw new ArgumentException("订单的用户ID和列车ID不能为空");
            }

            // 可以添加其他的业务逻辑或验证
            _orderServer.CreateOrder(order);
        }

        // 根据ID获取订单信息
        public Orderlist? GetOrderById(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentException("订单ID不能为空");
            }

            return _orderServer.GetOrderById(orderId);
        }

        public List<Orderlist> GetOrdersByUserId(string userId)
        {
            return _orderServer.GetOrdersByUserId(userId);
        }

        // 更新订单信息
        public void UpdateOrder(Orderlist order)
        {
            if (string.IsNullOrWhiteSpace(order.User_id) || string.IsNullOrWhiteSpace(order.Train_id))
            {
                throw new ArgumentException("订单的用户ID和列车ID不能为空");
            }

            _orderServer.UpdateOrder(order);
        }

        // 删除订单
        public void DeleteOrder(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentException("订单ID不能为空");
            }

            _orderServer.DeleteOrder(orderId);
        }
    }
}
