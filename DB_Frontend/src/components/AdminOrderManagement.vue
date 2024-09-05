<template>
  <div>
    <h3>订单管理</h3>
    <input v-model="userId" placeholder="输入用户ID" />
    <button @click="fetchOrders">查询订单</button>
    <button @click="openAddOrderModal">添加订单</button>

    <div v-if="orders && orders.length">
      <h4>订单详情</h4>
      <div v-for="order in orders" :key="order.Order_id">
        <p><strong>订单ID:</strong> {{ order.Order_id }}</p>
        <p><strong>火车ID:</strong> {{ order.Train_id }}</p>
        <button @click="viewOrderDetails(order.Order_id)">查看详细信息</button>
        <button @click="editOrder(order.Order_id)">编辑订单信息</button>
        <button @click="deleteOrder(order.Order_id)">删除订单</button>
      </div>
    </div>

    <!-- 模态框用于添加订单 -->
    <div v-if="showAddOrderModal" class="modal">
      <div class="modal-content">
        <span class="close" @click="showAddOrderModal = false">&times;</span>
        <h4>添加新订单</h4>
        <input v-model="newOrder.Train_id" placeholder="火车ID" />
        <input v-model="newOrder.Order_Status" placeholder="订单状态" />
        <input v-model="newOrder.Price" placeholder="价格" />
        <input v-model="newOrder.passenger_id" placeholder="乘客ID" />
        <input v-model="newOrder.ticket_type" placeholder="车票类型" />
        <button @click="createOrder">确认添加</button>
      </div>
    </div>

    <!-- 模态框用于展示订单详情 -->
    <div v-if="showModal" class="modal">
      <div class="modal-content">
        <span class="close" @click="showModal = false">&times;</span>
        <h4>订单详情</h4>
        <p><strong>订单ID:</strong> {{ selectedOrder?.Order_id }}</p>
        <p><strong>用户ID:</strong> {{ selectedOrder?.User_id }}</p>
        <p><strong>火车ID:</strong> {{ selectedOrder?.Train_id }}</p>
        <p><strong>订单状态:</strong> {{ selectedOrder?.Order_Status }}</p>
        <p><strong>价格:</strong> {{ selectedOrder?.Price }}</p>
        <p><strong>乘客ID:</strong> {{ selectedOrder?.passenger_id }}</p>
        <p><strong>车票类型:</strong> {{ selectedOrder?.ticket_type }}</p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import axios from 'axios';

interface Order {
  Order_id: string;
  User_id: string;
  Train_id: string;
  Order_Status: string;
  Price: number;
  passenger_id: string;
  ticket_type: string;
}

export default defineComponent({
  name: 'OrderManagement',
  setup() {
    const userId = ref<string>(''); // 使用 userId 替代 orderId
    const orders = ref<Order[]>([]); // 用于存储多个订单
    const selectedOrder = ref<Order | null>(null);
    const showModal = ref<boolean>(false);
    const showAddOrderModal = ref<boolean>(false); // 控制添加订单模态框
    const newOrder = ref<Order>({
      Order_id: '',
      User_id: '',
      Train_id: '',
      Order_Status: '',
      Price: 0,
      passenger_id: '',
      ticket_type: ''
    }); // 新订单的数据
    


    const fetchOrders = () => {
      if (!userId.value) {
        alert("请输入用户ID");
        return;
      }

      axios.get(`http://localhost:5000/api/Order/GetOrderssByUserId/${userId.value}`)
        .then(response => {
          orders.value = response.data;
        })
        .catch(error => {
          console.error("获取订单失败：", error);
        });
    };

    // 显示添加订单模态框
    const openAddOrderModal = () => {
      showAddOrderModal.value = true;
    };
    // 创建新订单方法
    const createOrder = () => {
      axios.post('http://localhost:5000/api/Order/CreateOrder', newOrder.value)
        .then(response => {
          alert('订单创建成功');
          showAddOrderModal.value = false; // 关闭模态框
          fetchOrders(); // 重新加载订单
        })
        .catch(error => {
          console.error("创建订单失败：", error);
        });
    };





    const viewOrderDetails = (id: string) => {
      axios.get(`http://localhost:5000/api/Order/GetOrder/${id}`)
        .then(response => {
          selectedOrder.value = response.data;
          showModal.value = true;
        })
        .catch(error => {
          console.error("获取订单详情失败：", error);
        });
    };

    const editOrder = (id: string) => {
      if (!selectedOrder.value) return;

      const updatedOrder: Order = {
        Order_id: selectedOrder.value.Order_id ?? '',
        User_id: selectedOrder.value.User_id ?? '',
        Train_id: selectedOrder.value.Train_id ?? '',
        Order_Status: selectedOrder.value.Order_Status ?? '',
        Price: selectedOrder.value.Price ?? 0,
        passenger_id: selectedOrder.value.passenger_id ?? '',
        ticket_type: selectedOrder.value.ticket_type ?? '',
      };

      axios.put('http://localhost:5000/api/Order/UpdateOrder', updatedOrder)
        .then(response => {
          alert("订单更新成功：" + response.data);
        })
        .catch(error => {
          console.error("更新订单失败：", error);
        });
    };

    const deleteOrder = (id: string) => {
      axios.delete(`http://localhost:5000/api/Order/DeleteOrder/${id}`)
        .then(response => {
          alert(response.data);
          fetchOrders(); // 删除后重新查询订单
        })
        .catch(error => {
          console.error("删除订单失败：", error);
        });
    };

    return {
      userId, // 更改为 userId
      orders, // 存储多个订单
      fetchOrders, // 更改为 fetchOrders
      viewOrderDetails,
      editOrder,
      deleteOrder,
      showModal,
      selectedOrder,
      showAddOrderModal,
      openAddOrderModal,
      newOrder,
      createOrder
    };
  }
});
</script>
