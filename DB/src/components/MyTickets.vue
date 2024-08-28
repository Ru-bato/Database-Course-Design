<template>
  <div class="tickets-container">
    <div class="filter-section">
      <span class="notice">订单信息保存期限为30日。</span>
      <label>乘车日期:</label>
      <div class="date-picker-container">
        <input type="date" v-model="filters.startDate" class="date-picker" />
        <span>至</span>
        <input type="date" v-model="filters.endDate" class="date-picker" />
      </div>
      <label>
        <input type="checkbox" v-model="filters.studentOnly" /> 学生票
      </label>
      <button @click="filterTickets" class="search-button">查询</button>
    </div>

    <ul class="ticket-list">
      <li v-for="(ticket, index) in filteredTickets" :key="index" class="ticket-item">
        <div class="ticket-header">
          <span class="ticket-date">{{ ticket.date }} {{ ticket.weekday }}</span>
          <span class="order-number">订单号: {{ ticket.orderNumber }}</span>
        </div>
        <div class="ticket-body">
          <div class="ticket-details">
            <p>乘客姓名: {{ ticket.passengerName }}</p>
            <p>火车号: {{ ticket.trainNumber }}</p>
            <p>出发时间: {{ ticket.departureTime }}</p>
            <p>出发站: {{ ticket.departureStation }}</p>
            <p>到达站: {{ ticket.arrivalStation }}</p>
          </div>
          <div class="ticket-payment">
            <span>{{ ticket.paymentMethod }}</span>
          </div>
          <div class="ticket-actions">
            <button v-if="ticket.status === '待支付'" class="pay-button">改签票</button>
            <button v-if="ticket.status === '已支付'" class="pay-button">改签</button>
            <button class="change-destination-button">变更到站</button>
            <button class="food-specialties-button">餐饮·特产</button>
            <button class="print-button">打印信息单</button>
            <a href="#" class="refund-link">退票</a>
          </div>
        </div>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      filters: {
        startDate: "",
        endDate: "",
        studentOnly: false,
      },
      tickets: [
        {
          date: "2024-07-19",
          weekday: "周五",
          orderNumber: "EJ67234897",
          passengerName: "张三",
          trainNumber: "G1234",
          departureTime: "08:00",
          departureStation: "北京南站",
          arrivalStation: "上海虹桥",
          paymentMethod: "线上购买 非现金支付",
          status: "待支付",
        },
        {
          date: "2024-07-20",
          weekday: "周六",
          orderNumber: "EJ84329264",
          passengerName: "李四",
          trainNumber: "D5678",
          departureTime: "09:30",
          departureStation: "南京南站",
          arrivalStation: "杭州东站",
          paymentMethod: "线上购买 非现金支付",
          status: "已支付",
        },
        // 更多车票数据...
      ],
      filteredTickets: [],
    };
  },
  mounted() {
    this.filterTickets();
  },
  methods: {
    filterTickets() {
      this.filteredTickets = this.tickets.filter((ticket) => {
        let matchesDate = true;
        let matchesStudent = true;

        if (this.filters.startDate && this.filters.endDate) {
          matchesDate =
            ticket.date >= this.filters.startDate &&
            ticket.date <= this.filters.endDate;
        }

        if (this.filters.studentOnly) {
          // 假设学生票信息在 ticket 中有一个字段可以用来判断
          matchesStudent = ticket.studentTicket === true;
        }

        return matchesDate && matchesStudent;
      });
    },
  },
};
</script>

<style scoped>
.tickets-container {
  padding: 20px;
  background-color: #f7f7f7;
}

.notice {
  color: orange;
  margin-bottom: 15px;
  display: block;
  text-align: center;
}

.filter-section {
  margin-bottom: 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.date-picker-container {
  display: flex;
  align-items: center;
  margin: 10px 0;
}

.date-picker {
  margin: 0 5px;
  padding: 5px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

.search-button {
  padding: 5px 15px;
  background-color: #3b99fc;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.ticket-list {
  list-style: none;
  padding: 0;
  margin: 0;
}

.ticket-item {
  background-color: white;
  padding: 15px;
  margin-bottom: 10px;
  border: 1px solid #ddd;
  border-radius: 4px;
  max-width: 700px;
  margin-left: auto;
  margin-right: auto;
}

.ticket-header {
  display: flex;
  justify-content: space-between;
  margin-bottom: 10px;
  font-weight: bold;
}

.ticket-body {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
}

.ticket-details {
  flex: 1;
}

.ticket-details p {
  margin: 5px 0;
}

.ticket-payment {
  flex: 1;
  text-align: right;
}

.ticket-actions {
  flex: 2;
  text-align: right;
}

.ticket-actions button,
.ticket-actions .refund-link {
  margin-right: 10px;
  padding: 5px 10px;
  background-color: #3b99fc;
  color: white;
  border: none;
  cursor: pointer;
  border-radius: 4px;
}

.ticket-actions .refund-link {
  background-color: transparent;
  color: #3b99fc;
  text-decoration: underline;
}

.ticket-actions button:last-child,
.ticket-actions .refund-link:last-child {
  margin-right: 0;
}

.pay-button {
  background-color: #ff9800;
}

.change-destination-button {
  background-color: #4caf50;
}

.food-specialties-button {
  background-color: #9c27b0;
}

.print-button {
  background-color: #009688;
}
</style>
