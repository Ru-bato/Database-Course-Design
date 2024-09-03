<template>
  <div>
    <h3>订单管理</h3>
    <table>
      <thead>
        <tr>
          <th>订单ID</th>
          <th>用户ID</th>
          <th>支付状态</th>
          <th>操作</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="order in orders" :key="order.id">
          <td>{{ order.id }}</td>
          <td>{{ order.userId }}</td>
          <td>{{ order.paid ? '已支付' : '未支付' }}</td>
          <td>
            <button @click="viewOrderDetails(order.id)">查看详情</button>
            <button @click="cancelPayment(order.id)" :disabled="order.paid">取消支付</button>
            <button @click="updateOrderStatus(order.id)">更新状态</button>
          </td>
        </tr>
      </tbody>
    </table>
    <!-- 订单详情的模态框 -->
    <div v-if="selectedOrder" class="modal">
      <div class="modal-content">
        <span class="close" @click="selectedOrder = null">&times;</span>
        <h4>订单详情</h4>
        <p><strong>订单ID:</strong> {{ selectedOrder.id }}</p>
        <p><strong>用户ID:</strong> {{ selectedOrder.userId }}</p>
        <p><strong>支付状态:</strong> {{ selectedOrder.paid ? '已支付' : '未支付' }}</p>
        <!-- 其他订单详情字段 -->
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'OrderManagement',
  data() {
    return {
      orders: [], // 从后端获取订单数据
      selectedOrder: null, // 用于存储查看的订单详情
    };
  },
  created() {
    this.fetchOrders();
  },
  methods: {
    fetchOrders() {
      // 获取所有订单的示例代码，假设有一个获取所有订单的API
      axios.get('http://localhost:5000/api/Order/GetOrders')
        .then(response => {
          this.orders = response.data;
        })
        .catch(error => {
          console.error("获取订单失败：", error);
        });
    },
    viewOrderDetails(orderId) {
      axios.get(`http://localhost:5000/api/Order/GetOrder/${orderId}`)
        .then(response => {
          this.selectedOrder = response.data;
        })
        .catch(error => {
          console.error("获取订单详情失败：", error);
        });
    },
    cancelPayment(orderId) {
      axios.put(`http://localhost:5000/api/Order/UpdateOrder`, {
        id: orderId,
        paid: false
      })
        .then(response => {
          alert(response.data);
          this.fetchOrders(); // 重新加载订单信息
        })
        .catch(error => {
          console.error("取消支付失败：", error);
        });
    },
    updateOrderStatus(orderId) {
      axios.put(`http://localhost:5000/api/Order/UpdateOrder`, {
        id: orderId,
        // 可以添加其他需要更新的字段
      })
        .then(response => {
          alert(response.data);
          this.fetchOrders(); // 重新加载订单信息
        })
        .catch(error => {
          console.error("更新订单状态失败：", error);
        });
    },
  },
};
</script>

<style scoped>
/* 添加模态框样式 */
.modal {
  display: block;
  position: fixed;
  z-index: 1;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  overflow: auto;
  background-color: rgb(0,0,0);
  background-color: rgba(0,0,0,0.4);
}

.modal-content {
  background-color: #fefefe;
  margin: 15% auto;
  padding: 20px;
  border: 1px solid #888;
  width: 80%;
}

.close {
  color: #aaa;
  float: right;
  font-size: 28px;
  font-weight: bold;
}

.close:hover,
.close:focus {
  color: black;
  text-decoration: none;
  cursor: pointer;
}
</style>
