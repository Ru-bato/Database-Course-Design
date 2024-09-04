<template>
  <div class="order-container">
    <h2>我的车票</h2>

    <!-- Date range picker -->
    <!--<div class="date-picker">
      <label for="start-date">起始日期:</label>
      <input type="date" id="start-date" v-model="startDate" />
      <label for="end-date">结束日期:</label>
      <input type="date" id="end-date" v-model="endDate" />
      <button @click="filterByDate">筛选</button>
    </div>-->

    <!-- Order list -->
    <div v-if="paginatedOrders.length === 0" class="no-orders">
      <p>你目前没有车票</p>
    </div>
    <div v-else>
      <div v-for="(order, index) in paginatedOrders" :key="order.orderId" class="order-card" :class="{'alternate-bg': index % 2 === 1}">
        <div class="order-header">
          <h3>订单号: <span class="blue-text">{{ order.orderId }}</span></h3>
        </div>
        <div class="order-details">
          <div class="detail-row">
            <span class="label">列车号：</span>
            <span class="blue-text">{{ order.trainId }}</span>
          </div>
          <div class="detail-row">
            <span class="label">价格：</span>
            <span class="blue-text">{{ order.price }}元</span>
          </div>
          <div class="detail-row">
            <span class="label">车票类型：</span>
            <span class="blue-text">{{ getTicketTypeLabel(order.ticketType) }}</span>
          </div>
          <div class="detail-row">
            <span class="label">出发站：</span>
            <span class="station-link" @click="openMap(order.departureStation)">{{ order.departureStation }}</span>
          </div>
          <div class="detail-row">
            <span class="label">终点站：</span>
            <span class="station-link" @click="openMap(order.arrivalStation)">{{ order.arrivalStation }}</span>
          </div>
          <div class="detail-row">
            <span class="label">出发时间：</span>
            <span class="blue-text">{{ order.departureTime }}</span>
          </div>
          <div class="detail-row">
            <span class="label">到达时间：</span>
            <span class="blue-text">{{ order.arriveTime }}</span>
          </div>
        </div>
        <div class="order-actions">
          <button class="orange-button">餐饮</button>
          <button class="blue-button" @click="confirmDelete(order.orderId)">退票</button>
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
  trainId: string;
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
    const startDate = ref<string>('');
    const endDate = ref<string>('');
    const filteredOrders = ref<Order[]>([]);
    const userId = localStorage.getItem('User_ID'); // 获得当前登录的userId
    const currentPage = ref(1);
    const pageSize = ref(2); // 每页显示的订单数量

    const fetchOrders = async () => {
      try {
        const response = await axios.get(`http://localhost:5000/api/MyTicket/GetMyTicket?cust=${userId}`);
        orders.value = response.data.sort((a: Order, b: Order) => b.orderId.localeCompare(a.orderId));
        applyFilters();
      } catch (error) {
        console.error('Error fetching orders:', error);
      }
    };

    const applyFilters = () => {
      filteredOrders.value = orders.value.filter(order => {
        const matchesDate = (!startDate.value || new Date(order.departureTime) >= new Date(startDate.value)) &&
                            (!endDate.value || new Date(order.departureTime) <= new Date(endDate.value));
        return matchesDate;
      });
      currentPage.value = 1; // 重置到第一页
    };

    const filterByDate = () => {
      applyFilters();
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

    const getTicketTypeLabel = (ticketType: string) => {
      return ticketType === 'adult' ? '成人票' : '学生票';
    };

    const openMap = (stationName: string) => {
      const encodedStationName = encodeURIComponent(stationName);
      const mapUrl = `https://www.amap.com/search?query=${encodedStationName}`;
      window.open(mapUrl, '_blank');
    };

    const confirmDelete = (orderId: string) => {
      if (window.confirm('确定要退票吗？')) {
        deleteOrder(orderId);
      }
    };

    const deleteOrder = async (orderId: string) => {
      try {
        await axios.delete(`http://localhost:5000/api/MyTicket/DeleteMyTicket?o_id=${orderId}`);
        fetchOrders(); // 重新获取订单列表
      } catch (error) {
        console.error('Error deleting order:', error);
      }
    };

    onMounted(() => {
      fetchOrders();
    });

    return {
      orders,
      startDate,
      endDate,
      filteredOrders,
      paginatedOrders,
      filterByDate,
      getTicketTypeLabel,
      openMap,
      currentPage,
      totalPages,
      prevPage,
      nextPage,
      confirmDelete
    };
  }
};
</script>

<style scoped>
.order-container {
  max-width: 2000px; /* 增加最大宽度 */
  margin: 0 auto;
  padding: 20px;
  display: flex;
  flex-direction: column;
  align-items: center; /* 水平居中 */
  justify-content: flex-start; /* 顶部对齐 */
  min-height: 100vh; /* 确保容器至少占据视口高度 */
  width: 100%; /* 确保容器占据全宽 */
  box-sizing: border-box; /* 确保 padding 不会影响总宽度 */
}

.date-picker {
  margin: 20px auto;
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%; /* 确保日期选择器占据全宽 */
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
  flex-direction: column; /* 改为竖向布局 */
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  width: 100%; /* 占据全宽 */
  box-sizing: border-box; /* 确保 padding 不会影响总宽度 */
}

.order-card.alternate-bg {
  background-color: #f9f9f9; /* 交替背景色 */
}

.order-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 10px; /* 增加底部间距 */
}

.order-header h3 {
  margin: 0;
  font-size: 16px;
}

.order-details {
  display: flex;
  flex-wrap: wrap; /* 换行排列 */
  justify-content: space-between;
  font-size: 14px;
}

.detail-row {
  margin-bottom: 10px;
  width: 48%; /* 调整为每行两个元素 */
}

.label {
  color: #007bff; /* 蓝色字体 */
}

.blue-text {
  color: #333; /* 标签字体颜色 */
}

.station-link {
  color: #007bff; /* 链接颜色 */
  text-decoration: underline; /* 下划线 */
  cursor: pointer; /* 鼠标指针样式 */
}

.no-orders {
  text-align: center;
  color: #6c757d;
  font-size: 18px;
  margin-top: 20px;
}

.order-actions {
  display: flex;
  justify-content: flex-end;
  margin-top: 20px;
}

.orange-button {
  background-color: #ff9800;
  color: white;
  border: none;
  padding: 10px 20px;
  border-radius: 5px;
  margin-left: 10px;
  cursor: pointer;
}

.blue-button {
  background-color: #007bff;
  color: white;
  border: none;
  padding: 10px 20px;
  border-radius: 5px;
  margin-left: 10px;
  cursor: pointer;
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