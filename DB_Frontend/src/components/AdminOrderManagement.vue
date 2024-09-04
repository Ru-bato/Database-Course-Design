<template>
  <div>
    <h3>订单管理</h3>
    <input v-model="orderId" placeholder="输入订单ID" />
    <button @click="fetchOrder">查询订单</button>

    <div v-if="order">
      <h4>订单详情</h4>
      <p><strong>订单ID:</strong> {{ order.Order_id }}</p>
      <p><strong>火车ID:</strong> {{ order.Train_id }}</p>
      <button @click="viewOrderDetails(order.Order_id)">查看详细信息</button>
      <button @click="editOrder(order.Order_id)">编辑订单信息</button>
      <button @click="deleteOrder(order.Order_id)">删除订单</button>
    </div>
  
  <!-- 模态框用于展示订单详情 -->
<div v-if="showModal" class="modal">
  <div class="modal-content">
    <span class="close" @click="showModal = false">&times;</span>
    <h4>订单详情</h4>
    <p><strong>订单ID:</strong> {{ selectedOrder?.Order_id }}</p>
    <p><strong>用户ID:</strong> {{ selectedOrder?.User_id }}</p>
    <p><strong>火车ID:</strong> {{ selectedOrder?.Train_id }}</p>
    <p><strong>订单状态:</strong> {{ selectedOrder?.Orderstatus }}</p>
    <p><strong>价格:</strong> {{ selectedOrder?.Price }}</p>
    <p><strong>乘客ID:</strong> {{ selectedOrder?.passenger_id }}</p>
    <p><strong>车票类型:</strong> {{ selectedOrder?.ticket_type }}</p>
    <!-- 其他订单详细信息 -->
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
  Orderstatus: string;
  Price: string;
  passenger_id: string;
  ticket_type: string;
}

export default defineComponent({
  name: 'OrderManagement',
  setup() {
    const orderId = ref<string>('');
    const order = ref<Order | null>(null);
      const selectedOrder = ref<Order | null>(null);
const showModal = ref<boolean>(false);

    const fetchOrder = () => {
      if (!orderId.value) {
        alert("请输入订单ID");
        return;
      }

      axios.get(`http://localhost:5000/api/Order/GetOrder/${orderId.value}`)
        .then(response => {
          order.value = response.data;
        })
        .catch(error => {
          console.error("获取订单失败：", error);
        });
    };

    const viewOrderDetails = (id: string) => {
  axios.get(`http://localhost:5000/api/Order/GetOrder/${id}`)
    .then(response => {
      // 订单详情会被存储到 selectedOrder 中
      selectedOrder.value = response.data;
      showModal.value = true; // 显示模态框
    })
    .catch(error => {
      console.error("获取订单详情失败：", error);
    });
};


const editOrder = (id: string) => {
  if (!order.value) return;

  // 确保所有字段都完整传回后端，即使前端没有涉及到某些字段
  const updatedOrder: Order = {
    Order_id: order.value.Order_id ?? '',
    User_id: order.value.User_id ?? '',
    Train_id: order.value.Train_id ?? '',
    Orderstatus: order.value.Orderstatus ?? '',
    Price: order.value.Price ?? '',
    passenger_id: order.value.passenger_id ?? '',
    ticket_type: order.value.ticket_type ?? '',
  };

  axios.put('http://localhost:5000/api/Order/UpdateOrder', updatedOrder)
    .then(response => {
      alert("订单更新成功：" + response.data);
      // 这里可以根据需要执行额外操作，例如重新加载订单列表
    })
    .catch(error => {
      console.error("更新订单失败：", error);
    });
};


    const deleteOrder = (id: string) => {
      axios.delete(`http://localhost:5000/api/Order/DeleteOrder/${id}`)
        .then(response => {
          alert(response.data);
          order.value = null;
        })
        .catch(error => {
          console.error("删除订单失败：", error);
        });
    };

    return {
      orderId,
      order,
      fetchOrder,
      viewOrderDetails,
      editOrder,
      deleteOrder
    };
  }
});
</script>
