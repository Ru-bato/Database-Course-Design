<template>
  <div class="order-container">
    <h2>已支付订单</h2>

    <!-- Date range picker -->
    <div class="date-picker">
      <div class="date-picker-inner">
        <label for="start-date">起始日期:</label>
        <input type="date" id="start-date" v-model="startDate" />
        <label for="end-date">结束日期:</label>
        <input type="date" id="end-date" v-model="endDate" />
        <button @click="filterByDate">筛选</button>
      </div>
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
          <!-- <button @click="handleChangeTicket(order.orderId)">改签</button> -->
          <button class="orange-button" @click="gotoFoodServer()">餐饮服务</button>
          <button @click="handleCancelOrder(order.orderId)">取消订单</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { useRouter } from 'vue-router';

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
    const startDate = ref<string>('');
    const endDate = ref<string>('');
    const filteredOrders = ref<Order[]>([]);
    const userId = localStorage.getItem('User_ID');
    const router = useRouter();

    const fetchOrders = () => {
      console.log(`http://localhost:5000/api/MyOrder/GetMyPaidOrder?cust=${userId}`);
      axios.get(`http://localhost:5000/api/MyOrder/GetMyPaidOrder?cust=${userId}`)
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
        const matchesDate = (!startDate.value || new Date(order.departureTime) >= new Date(startDate.value)) &&
                            (!endDate.value || new Date(order.departureTime) <= new Date(endDate.value));
        return matchesDate;
      });
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

    const getMapUrl = (station: string) => {
      return `https://www.amap.com/search?query=${encodeURIComponent(station)}`;
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

    const gotoFoodServer=()=>{
      router.push({name:'FoodServer'});
    }

    const handleCancelOrder = (orderId: string) => {
      axios.post('http://localhost:5000/api/tickets/refundTickets',{
        OrderID:orderId,
        IsPaid:true
      })
      .then(response =>{
        console.log(response.data);
      })
      .catch(error => {
        console.error('Error:', error);
      })
      console.log('取消订单:', orderId);
      window.alert('取消订单成功！');
      fetchOrders();
    };

    onMounted(() => {
      fetchOrders();
    });

    return {
      filteredOrders,
      startDate,
      endDate,
      filterByDate,
      getStatusLabel,
      getStatusClass,
      getTicketTypeLabel,
      getMapUrl,
      handleChangeTicket,
      handlePay,
      handleWaitlistStatus,
      handleCancelOrder,
      gotoFoodServer
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

.orange-button {
  background-color: #ff9800;
  color: white;
  border: none;
  padding: 10px 20px;
  border-radius: 5px;
  margin-left: 10px;
  cursor: pointer;
}
</style>