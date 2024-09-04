<template>
  <div class="order-container">
    <h2>候补订单</h2>

    <!-- Order list -->
    <div v-if="paginatedOrders.length === 0" class="no-orders">
      <div class="order-card">
        <p>你目前没有订单</p>
      </div>
    </div>
    <div v-else>
      <div v-for="order in paginatedOrders" :key="order.orderId" class="order-card">
        <div class="order-header">
          <h3>订单号: {{ order.orderId }}</h3>
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
            <a :href="getMapUrl(order.departureStation)" target="_blank" class="station-link departure">{{ order.departureStation }}</a>
          </div>
          <div class="detail-row">
            <span class="label">目的站：</span>
            <a :href="getMapUrl(order.arrivalStation)" target="_blank" class="station-link arrival">{{ order.arrivalStation }}</a>
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
          <button @click="handleWaitlistStatus(order.orderId)">候补情况</button>
          <button @click="handleCancelOrder(order.orderId)">取消订单</button>
        </div>
      </div>
    </div>

    <!-- Pagination -->
    <div class="pagination">
      <button @click="prevPage" :disabled="currentPage === 1">上一页</button>
      <span>{{ currentPage }} / {{ totalPages }}</span>
      <button @click="nextPage" :disabled="currentPage === totalPages">下一页</button>
    </div>
  </div>
</template>

<script lang="ts">
import { ref, onMounted, computed } from 'vue';
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
    const filteredOrders = ref<Order[]>([]);
    const userId = localStorage.getItem('User_ID');
    const currentPage = ref(1);
    const pageSize = ref(2); // 每页显示的订单数量

    const fetchOrders = () => {
      axios.get(`http://localhost:5000/api/MyOrder/GetMyWaitOrder?cust=${userId}`)
        .then(response => {
          orders.value = response.data.sort((a: Order, b: Order) => b.orderId.localeCompare(a.orderId));
          applyFilters();
        })
        .catch(error => {
          console.error('Error fetching orders:', error);
        });
    };

    const applyFilters = () => {
      filteredOrders.value = orders.value;
      currentPage.value = 1; // 重置到第一页
    };

    const paginatedOrders = computed(() => {
      const start = (currentPage.value - 1) * pageSize.value;
      const end = start + pageSize.value;
      return filteredOrders.value.slice(start, end);
    });

    const totalPages = computed(() => {
      return Math.ceil(filteredOrders.value.length / pageSize.value);
    });

    const prevPage = () => {
      if (currentPage.value > 1) {
        currentPage.value--;
      }
    };

    const nextPage = () => {
      if (currentPage.value < totalPages.value) {
        currentPage.value++;
      }
    };

    const getStatusLabel = (status: string) => {
      return status === 'paid' ? '已支付' : status === 'unpaid' ? '未支付' : '候补';
    };

    const getStatusClass = (status: string) => {
      return status === 'paid' ? 'completed' : status === 'unpaid' ? 'pending' : 'wait';
    };

    const getTicketTypeLabel = (ticketType: string) => {
      return ticketType === 'adult' ? '成人票' : '学生票';
    };

    const getMapUrl = (station: string) => {
      return `https://www.amap.com/search?query=${encodeURIComponent(station)}`;
    };

    const handleWaitlistStatus = (orderId: string) => {
      console.log('查看候补情况:', orderId);
    };

    const handleCancelOrder = (orderId: string) => {
      if (window.confirm('确定要取消订单吗？')) {
        axios.delete(`http://localhost:5000/api/MyOrder/DeleteWaitOrder?o_id=${orderId}`)
          .then(response => {
            console.log('订单已取消:', response.data);
            fetchOrders(); // 重新获取订单列表
          })
          .catch(error => {
            console.error('Error canceling order:', error);
          });
      }
    };

    onMounted(() => {
      fetchOrders();
    });

    return {
      filteredOrders,
      paginatedOrders,
      getStatusLabel,
      getStatusClass,
      getTicketTypeLabel,
      getMapUrl,
      handleWaitlistStatus,
      handleCancelOrder,
      currentPage,
      totalPages,
      prevPage,
      nextPage,
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

h2 {
  font-weight: bold; /* 使 "已支付订单" 文本加粗 */
}

.date-picker {
  margin-bottom: 20px;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 15px;
  background-color: #f9f9f9;
}

.date-picker-inner {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
}

.date-picker label {
  margin-right: 10px;
  font-weight: bold;
}

.date-picker input {
  margin-right: 10px;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

.date-picker button {
  padding: 8px 15px;
  border: none;
  border-radius: 4px;
  background-color: #007bff;
  color: #fff;
  cursor: pointer;
  transition: background-color 0.3s;
}

.date-picker button:hover {
  background-color: #0056b3;
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
  background-color: #007bff;
  color: #fff;
  transition: background-color 0.3s;
}

.order-actions button:hover {
  background-color: #0056b3;
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

.station-link {
  text-decoration: none;
  color: inherit;
  padding-bottom: 2px;
  border-bottom: 1px solid;
}

.station-link.departure {
  color: #007bff;
  border-color: #007bff;
}

.station-link.arrival {
  color: #28a745;
  border-color: #28a745;
}

.pagination {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 20px;
}

.pagination button {
  margin: 0 5px;
  padding: 5px 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  background-color: #fff;
  cursor: pointer;
  transition: background-color 0.3s;
}

.pagination button:disabled {
  cursor: not-allowed;
  background-color: #f9f9f9;
}

.pagination button:hover:not(:disabled) {
  background-color: #f0f0f0;
}

.pagination span {
  margin: 0 10px;
  font-size: 14px;
}
</style>