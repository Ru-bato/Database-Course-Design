<template>
  <div class="order-list">
    <!-- 界面切换按钮 -->
    <div class="switch-buttons">
      <button :class="{ active: showPaid }" @click="showPaidOrders">已支付订单</button>
      <button :class="{ active: showUnpaid }" @click="showUnpaidOrders">未支付订单</button>
      <button :class="{ active: showPending }" @click="showPendingOrders">候补订单</button>
    </div>

    <!-- 未支付订单部分 -->
    <div v-if="showUnpaid">
      <!-- 日期筛选器 -->
      <div class="filter-section">
        <label>起始日期：</label>
        <input type="date" v-model="unpaidStartDate" />
        <label>结束日期：</label>
        <input type="date" v-model="unpaidEndDate" />
        <button @click="applyFilter('unpaid')">筛选</button>
      </div>
      <div v-for="order in filteredUnpaidOrders" :key="order.orderId" class="order-item">
        <div class="order-header">
          <span>订票日期：{{ order.ticketDate }}</span>
          <span class="order-id">订单号：{{ order.orderId }}</span>
        </div>
        <div class="order-content">
          <div class="train-info">
            <div>{{ order.route }}</div>
            <div>{{ order.departureDate }} {{ order.departureTime }} 开</div>
          </div>
          <div class="passenger-info-container">
            <div v-for="passenger in order.passengers" :key="passenger.name" class="passenger-info">
              <div class="passenger-field">{{ passenger.name }}</div>
              <div class="passenger-field">{{ passenger.idType }}</div>
              <div class="passenger-field">{{ passenger.seatType }} {{ passenger.seatNumber }}</div>
              <div class="passenger-field">{{ passenger.ticketType }}</div>
              <div class="passenger-field">{{ passenger.ticketPrice }}元</div>
              <div class="passenger-field discount" v-if="passenger.discount">{{ passenger.discount }}</div>
            </div>
          </div>
        </div>
        <div class="order-actions">
          <button class="details-btn">订单详情</button>
          <button class="insurance-btn">购/赠保险</button>
          <button class="pay-btn">支付</button>
        </div>
      </div>
    </div>

    <!-- 已支付订单部分 -->
    <div v-if="showPaid">
      <!-- 日期筛选器 -->
      <div class="filter-section">
        <label>起始日期：</label>
        <input type="date" v-model="paidStartDate" />
        <label>结束日期：</label>
        <input type="date" v-model="paidEndDate" />
        <button @click="applyFilter('paid')">筛选</button>
      </div>
      <div v-for="order in filteredPaidOrders" :key="order.orderId" class="order-item">
        <div class="order-header">
          <span>订票日期：{{ order.ticketDate }}</span>
          <span class="order-id">订单号：{{ order.orderId }}</span>
        </div>
        <div class="order-content">
          <div class="train-info">
            <div>{{ order.route }}</div>
            <div>{{ order.departureDate }} {{ order.departureTime }} 开</div>
          </div>
          <div class="passenger-info-container">
            <div v-for="passenger in order.passengers" :key="passenger.name" class="passenger-info">
              <div class="passenger-field">{{ passenger.name }}</div>
              <div class="passenger-field">{{ passenger.idType }}</div>
              <div class="passenger-field">{{ passenger.seatType }} {{ passenger.seatNumber }}</div>
              <div class="passenger-field">{{ passenger.ticketType }}</div>
              <div class="passenger-field">{{ passenger.ticketPrice }}元</div>
              <div class="passenger-field discount" v-if="passenger.discount">{{ passenger.discount }}</div>
            </div>
          </div>
        </div>
        <div class="order-actions">
          <button class="details-btn">订单详情</button>
          <button class="insurance-btn">购/赠保险</button>
        </div>
      </div>
    </div>

    <!-- 候补订单部分 -->
    <div v-if="showPending">
      <!-- 日期筛选器 -->
      <div class="filter-section">
        <label>起始日期：</label>
        <input type="date" v-model="pendingStartDate" />
        <label>结束日期：</label>
        <input type="date" v-model="pendingEndDate" />
        <button @click="applyFilter('pending')">筛选</button>
      </div>
      <div v-for="order in filteredPendingOrders" :key="order.orderId" class="order-item">
        <div class="order-header">
          <span>订票日期：{{ order.ticketDate }}</span>
          <span class="order-id">订单号：{{ order.orderId }}</span>
        </div>
        <div class="order-content">
          <div class="train-info">
            <div>{{ order.route }}</div>
            <div>{{ order.departureDate }} {{ order.departureTime }} 开</div>
          </div>
          <div class="passenger-info-container">
            <div v-for="passenger in order.passengers" :key="passenger.name" class="passenger-info">
              <div class="passenger-field">{{ passenger.name }}</div>
              <div class="passenger-field">{{ passenger.idType }}</div>
              <div class="passenger-field">{{ passenger.seatType }} {{ passenger.seatNumber }}</div>
              <div class="passenger-field">{{ passenger.ticketType }}</div>
              <div class="passenger-field">{{ passenger.ticketPrice }}元</div>
              <div class="passenger-field discount" v-if="passenger.discount">{{ passenger.discount }}</div>
            </div>
          </div>
        </div>
        <div class="order-actions">
          <button class="details-btn">订单详情</button>
          <button class="insurance-btn">购/赠保险</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      showPaid: false, // 控制显示已支付的订单
      showUnpaid: false, // 控制显示未支付的订单
      showPending: false, // 控制显示候补订单
      unpaidStartDate: '',
      unpaidEndDate: '',
      paidStartDate: '',
      paidEndDate: '',
      pendingStartDate: '',
      pendingEndDate: '',
      orders: [
        {
          orderId: 'EH84968178',
          ticketDate: '2024-08-20',
          route: '桂林北→上海南 T78',
          departureDate: '2024-08-26',
          departureTime: '15:54',
          paid: true,
          pending: false,
          passengers: [
            { name: '谭赛', idType: '居民身份证', seatType: '硬卧', seatNumber: '06车14号中铺', ticketType: '成人票', ticketPrice: 339.0 },
            { name: '陈黎', idType: '居民身份证', seatType: '硬卧', seatNumber: '06车13号上铺', ticketType: '成人票', ticketPrice: 328.0 },
            { name: '谭乐', idType: '居民身份证', seatType: '硬卧', seatNumber: '06车14号上铺', ticketType: '学生票', ticketPrice: 232.0, discount: '7.1折' }
          ]
        },
        {
          orderId: 'EH72756083',
          ticketDate: '2024-08-17',
          route: '长沙→桂林北 Z285',
          departureDate: '2024-08-19',
          departureTime: '11:54',
          paid: false,
          pending: true,
          passengers: [
            { name: '谭赛', idType: '居民身份证', seatType: '硬卧', seatNumber: '加5车02号中铺', ticketType: '成人票', ticketPrice: 138.0 },
            { name: '谭乐', idType: '居民身份证', seatType: '硬卧', seatNumber: '加5车01号中铺', ticketType: '成人票', ticketPrice: 138.0 }
          ]
        }
      ]
    };
  },
  computed: {
    filteredUnpaidOrders() {
      return this.orders.filter(order => !order.paid && !order.pending &&
        (!this.unpaidStartDate || order.ticketDate >= this.unpaidStartDate) &&
        (!this.unpaidEndDate || order.ticketDate <= this.unpaidEndDate));
    },
    filteredPaidOrders() {
      return this.orders.filter(order => order.paid &&
        (!this.paidStartDate || order.ticketDate >= this.paidStartDate) &&
        (!this.paidEndDate || order.ticketDate <= this.paidEndDate));
    },
    filteredPendingOrders() {
      return this.orders.filter(order => order.pending &&
        (!this.pendingStartDate || order.ticketDate >= this.pendingStartDate) &&
        (!this.pendingEndDate || order.ticketDate <= this.pendingEndDate));
    }
  },
  methods: {
    showPaidOrders() {
      this.showPaid = true;
      this.showUnpaid = false;
      this.showPending = false;
    },
    showUnpaidOrders() {
      this.showPaid = false;
      this.showUnpaid = true;
      this.showPending = false;
    },
    showPendingOrders() {
      this.showPaid = false;
      this.showUnpaid = false;
      this.showPending = true;
    },
    applyFilter(type) {
      // 根据类型应用筛选逻辑
      if (type === 'unpaid') {
        this.filteredUnpaidOrders();
      } else if (type === 'paid') {
        this.filteredPaidOrders();
      } else if (type === 'pending') {
        this.filteredPendingOrders();
      }
    }
  }
};
</script>

<style scoped>
/* 界面整体风格和布局 */
.order-list {
  padding: 20px;
  max-width: 800px;
  margin: 0 auto;
  background-color: #f9f9f9;
}

.switch-buttons {
  display: flex;
  gap: 10px;
  justify-content: center;
  margin-bottom: 20px;
}

.switch-buttons button {
  padding: 10px 20px;
  border: 1px solid #3b99fc;
  background-color: #fff;
  color: #3b99fc;
  cursor: pointer;
  border-radius: 4px;
}

.switch-buttons button.active {
  background-color: #3b99fc;
  color: #fff;
}

.switch-buttons button:hover {
  background-color: #3b99fc;
  color: #fff;
}

.filter-section {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  margin-bottom: 20px;
}

.filter-section input[type="date"] {
  padding: 5px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

.order-item {
  border: 1px solid #e0e0e0;
  background-color: #fff;
  margin-bottom: 15px;
  padding: 15px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.order-header {
  display: flex;
  justify-content: space-between;
  font-weight: bold;
  margin-bottom: 10px;
}

.train-info {
  font-size: 14px;
  margin-bottom: 10px;
}

.passenger-info-container {
  display: flex;
  flex-direction: column;
  gap: 5px;
}

.passenger-info {
  display: grid;
  grid-template-columns: repeat(6, 1fr);
  align-items: center;
  font-size: 14px;
  padding: 8px;
  background-color: #f3f4f6;
  border-radius: 4px;
}

.passenger-field {
  text-align: center;
}

.discount {
  color: #ff4d4f;
}

.order-actions {
  display: flex;
  justify-content: flex-end;
  gap: 10px;
  margin-top: 10px;
}

.details-btn,
.insurance-btn,
.pay-btn {
  padding: 5px 15px;
  border: 1px solid #3b99fc;
  background-color: #fff;
  color: #3b99fc;
  cursor: pointer;
  border-radius: 4px;
}

.details-btn:hover,
.insurance-btn:hover {
  background-color: #3b99fc;
  color: #fff;
}

.pay-btn {
  background-color: #ff4d4f;
  border-color: #ff4d4f;
  color: #fff;
}

.pay-btn:hover {
  background-color: #ff7875;
  border-color: #ff7875;
}
</style>
