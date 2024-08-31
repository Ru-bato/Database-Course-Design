<template>
  <div class="order-container">
    <h2>我的订单</h2>

    <!-- Order status filter buttons -->
    <div class="filter-buttons">
      <button 
        v-for="status in ['已支付', '未支付', '候补']" 
        :key="status" 
        :class="['filter-button', {'active': selectedStatus === status}]" 
        @click="filterByStatus(status)">
        {{ status }}
      </button>
    </div>

    <!-- Date range picker -->
    <div class="date-picker">
      <label for="start-date">起始日期:</label>
      <input type="date" id="start-date" v-model="startDate" />
      <label for="end-date">结束日期:</label>
      <input type="date" id="end-date" v-model="endDate" />
      <button @click="filterByDate">筛选</button>
    </div>

    <!-- Order list -->
    <div v-if="filteredOrders.length === 0" class="no-orders">
      <div class="order-card">
        <p>你目前没有订单</p>
      </div>
    </div>
    <div v-else>
      <div v-for="order in filteredOrders" :key="order.orderId" class="order-card">
        <div class="order-header">
          <h3>订单号: {{ order.orderId }}</h3>
          <!-- 状态显示为中文 -->
          <span :class="['order-status', getStatusClass(order.orderStatus)]">{{ getStatusLabel(order.orderStatus) }}</span>
        </div>
        <div class="order-details">
          <div class="detail-row">
            <span class="label">平台账号：</span>
            <span>{{ order.userId }}</span>
          </div>
          <div class="detail-row">
            <span class="label">火车列次：</span>
            <span>{{ order.trainId }}</span>
          </div>
          <div class="detail-row">
            <span class="label">乘车人号码：</span>
            <span>{{ order.passengerId }}</span>
          </div>
          <div class="detail-row">
            <span class="label">价格：</span>
            <span>{{ order.price }}元</span>
          </div>
        </div>
        <div class="order-details">
          <div class="detail-row">
            <span class="label">乘车类型：</span>
            <span>{{ getTicketTypeLabel(order.ticketType) }}</span>
          </div>
          <div class="detail-row">
            <span class="label">出发站：</span>
            <span>{{ order.departureStation }}</span>
          </div>
          <div class="detail-row">
            <span class="label">目的站：</span>
            <span>{{ order.arrivalStation }}</span>
          </div>
          <div class="detail-row">
            <span class="label">出发时间：</span>
            <span>{{ order.departureTime }}</span>
          </div>
          <div class="detail-row">
            <span class="label">到达时间：</span>
            <span>{{ order.arriveTime }}</span>
          </div>
        </div>
        <div class="order-actions">
          <button v-if="order.orderStatus === 'paid'" @click="handleChangeTicket(order.orderId)">改签</button>
          <button v-if="order.orderStatus === 'unpaid'" @click="handlePay(order.orderId)">支付</button>
          <button v-if="order.orderStatus === 'wait'" @click="handleWaitlistStatus(order.orderId)">候补情况</button>
          <button @click="handleCancelOrder(order.orderId)">取消订单</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';

interface Order {
  orderId: string;
  userId: string;
  trainId: string;
  passengerId: string;
  orderStatus: string;
  price: number;
  ticketType: string;
  departureStation: string;
  arrivalStation: string;
  departureTime: string;
  arriveTime: string;
}

export default {
  setup() {
    const orders = ref<Order[]>([]);
    const selectedStatus = ref<string>('已支付');
    const startDate = ref<string>('');
    const endDate = ref<string>('');
    const filteredOrders = ref<Order[]>([]);

    const userId = '0001';

    const fetchOrders = () => {
      axios.get(`http://localhost:5138/api/MyOrder/GetMyOrder?cust=${userId}`)
        .then(response => {
          orders.value = response.data;
          applyFilters();
        })
        .catch(error => {
          console.error('Error fetching orders:', error);
        });
    };

    const applyFilters = () => {
      filteredOrders.value = orders.value.filter(order => {
        const matchesStatus = selectedStatus.value === getStatusLabel(order.orderStatus);
        const matchesDate = (!startDate.value || new Date(order.departureTime) >= new Date(startDate.value)) &&
                            (!endDate.value || new Date(order.departureTime) <= new Date(endDate.value));
        return matchesStatus && matchesDate;
      });
    };

    const filterByStatus = (status: string) => {
      selectedStatus.value = status;
      applyFilters();
    };

    const filterByDate = () => {
      applyFilters();
    };

    // 将状态映射到中文标签
    const getStatusLabel = (status: string) => {
      return status === 'paid' ? '已支付' : status === 'unpaid' ? '未支付' : '候补';
    };

    // 根据状态映射到相应的 CSS 类
    const getStatusClass = (status: string) => {
      return status === 'paid' ? 'completed' : status === 'unpaid' ? 'pending' : 'wait';
    };

    const getTicketTypeLabel = (ticketType: string) => {
      return ticketType === 'adult' ? '成人票' : '学生票';
    };

    const handleChangeTicket = (orderId: string) => {
      console.log('改签订单:', orderId);
    };

    const handlePay = (orderId: string) => {
      console.log('支付订单:', orderId);
    };

    const handleWaitlistStatus = (orderId: string) => {
      console.log('查看候补情况:', orderId);
    };

    const handleCancelOrder = (orderId: string) => {
      console.log('取消订单:', orderId);
    };

    onMounted(() => {
      fetchOrders();
    });

    return {
      filteredOrders,
      selectedStatus,
      startDate,
      endDate,
      filterByStatus,
      filterByDate,
      getStatusLabel,
      getStatusClass,
      getTicketTypeLabel,
      handleChangeTicket,
      handlePay,
      handleWaitlistStatus,
      handleCancelOrder,
    };
  }
};
</script>

<style scoped>
.order-container {
  width: 100%;
  max-width: 1200px; /* 调整为适合的最大宽度 */
  margin: 0 auto;
  padding: 20px;
  display: flex;
  flex-direction: column;
  justify-content: flex-start; /* 保持顶部对齐 */
  min-height: 100vh;
}

.filter-buttons {
  margin-bottom: 20px;
  display: flex;
  width: 100%;
  justify-content: center;
}

.filter-buttons .filter-button {
  padding: 10px 20px;
  margin-right: 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  flex: 1;
  max-width: 120px;
}

.filter-buttons .filter-button.active {
  background-color: #007bff;
  color: #fff;
}

.date-picker {
  margin-bottom: 20px;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
}

.date-picker label {
  margin-right: 10px;
}

.date-picker input {
  margin-right: 10px;
}

.order-card {
  border: 1px solid #ddd;
  border-radius: 8px;
  margin-bottom: 20px;
  padding: 20px;
  background-color: #fff;
  display: flex;
  flex-direction: column;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  width: 100%; /* 确保占满全宽 */
  min-height: 200px;
}

.order-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 10px;
}

.order-header h3 {
  margin: 0;
  font-size: 16px;
}

.order-status {
  font-size: 14px;
  font-weight: bold;
  padding: 4px 8px;
  border-radius: 4px;
}

.order-status.completed {
  color: #28a745;
  background-color: #d4edda;
}

.order-status.pending {
  color: #ffc107;
  background-color: #fff3cd;
}

.order-status.wait {
  color: #17a2b8;
  background-color: #d1ecf1;
}

.order-details {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  font-size: 14px;
}

.detail-row {
  margin-bottom: 10px;
  width: 48%;
}

.order-actions {
  display: flex;
  justify-content: flex-end;
  margin-top: 10px;
}

.order-actions button {
  margin-left: 10px;
  padding: 5px 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.no-orders {
  width: 100%; /* 占满全宽 */
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  color: #6c757d;
  font-size: 18px;
  margin-top: 20px;
}

.no-orders .order-card {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
}

.no-orders .order-card p {
  margin: 0;
  width: 100%;
  text-align: center;
}

</style>