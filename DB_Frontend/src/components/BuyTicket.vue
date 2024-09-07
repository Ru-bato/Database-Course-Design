<template>
  <div class="BodyWrapper">
    <div class="passenger-list">
      <!-- 乘车人列表 -->
      <div class="passenger-list-hd">
        请选择乘车人
      </div>

      <div class="passenger-list-bd">
        <div v-for="(passenger,index) in passengerList" :key="passenger.name" class="passenger-item">
          <div class="passenger-info">
            <div class="passenger-check-box">
              <input type="checkbox" :id="passenger.name" :checked="checkedStatus[passenger.name]"
                @change="handleCheckboxChange(passenger.name, $event)">
              <label :for="passenger.name">{{ passenger.name }}({{ passenger.isStudent ? '学生' : '成人' }})</label>
            </div>
          </div>
          <table class="passenger-ticket">
            <tbody>
              <tr>
                <th width="50" rowspan="1" colspan="1">序号</th>
                <th rowspan="1" colspan="1">票种</th>
                <th rowspan="1" colspan="1">姓名</th>
                <th rowspan="1" colspan="1">电话号码</th>
                <th width="100" rowspan="1" colspan="1"></th>
              </tr>
            </tbody>
            <tbody id="ticketInfo_tb">
              <tr id="ticketInfo_tr">
                <td align="center">{{ index + 1 }}</td>
                <td>
                  <select :id="`${passenger.name}-ticket-type`" v-model="ticketTypes[passenger.name]"
                    @change="handleTicketTypeChange(index, passenger.name, $event)">
                    <option value="学生票">学生票</option>
                    <option value="成人票">成人票</option>
                  </select>
                </td>
                <td align="center">{{ passenger.name }}</td>
                <td align="center">{{ passenger.phoneNumber }}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>

    <div class="layout-submitBtn">
      <button id="submit" class="btn btn-primary" @click="submitOrder">提交订单</button>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
import axios from 'axios';

export interface Passenger {
  name: string; // 名字
  isStudent: number; // 是否为学生
  phoneNumber: string; // 电话号码
  passengerID: string; // 乘客的用户ID
}

export interface OrderDetails {
  name: string; // 乘客名字
  isChecked: boolean; // 是否选中
  ticketType: string; // 车票类型
  passengerID: string; // 乘客的用户ID
}

export interface TicketDetails {
  trainID: string;
  price: string;
}

export default defineComponent({
  setup() {
    const user_ID = localStorage.getItem('User_ID');
    // const user_ID = '8';
    const passengerList = ref<Passenger[]>([]);

    /* 测试数据
    passengerList.value = [
            { name: '张三', isStudent: 1, phoneNumber: '13888888888', passengerID: '' },
            { name: '李四', isStudent: 0, phoneNumber: '15959595959', passengerID: '' },
            { name: '王五', isStudent: 1, phoneNumber: '17666666666', passengerID: '' },
            // 其他乘客...
        ];
    */

    // 接受上一级页面数据
    const route = useRoute();
    const receivedData = ref<TicketDetails>({
      trainID: '',
      price: '',
    });
    receivedData.value.trainID = route.query.trainID as string;
    receivedData.value.price = route.query.price as string;

    // 创建一个对象来存储每个乘客的选中状态  
    const checkedStatus = ref<{ [key: string]: boolean }>({});
    // 存储每个乘客的票种类型
    const ticketTypes = ref<{ [key: string]: string }>({});

    const handleCheckboxChange = (passengerName: string, event: Event) => {
      const target = event.target as HTMLInputElement;
      checkedStatus.value[passengerName] = target.checked;
      if (target.checked) {
        console.log(`${passengerName} 复选框已选中`);
        // 加上这个人
      } else {
        console.log(`${passengerName} 复选框已取消`);
        // 减去这个人
      }
    };

    const handleTicketTypeChange = (index: number, passengerName: string, event: Event) => {  
      const target = event.target as HTMLSelectElement;  
      const selectedValue = target.value; // 获取当前选择的值  

      // 确保 ticketTypes 是一个对象，且每个乘客的票种类型独立  
      if (passengerList.value[index].isStudent ||   
        (!passengerList.value[index].isStudent && selectedValue === '成人票')  
      ) {  
        ticketTypes.value[passengerName] = selectedValue; // 更新特定乘客的票种类型  
        console.log(`${passengerName} 选择的票种类型: ${selectedValue}`);  
      } else {  
        console.log(`${passengerName} 选择的票种类型: ${selectedValue} 不符合！`);  
        
        // 将选择框的值重置为 '成人票'  
        target.value = '成人票';  
        
        // 更新 ticketTypes 中的值  
        ticketTypes.value[passengerName] = '成人票'; // 明确更新为成人票  
        console.log(`${passengerName} 的票种类型已修改为: 成人票`);  

        // 弹窗提示  
        window.alert(`${passengerName} 选择的票种类型不符合！已自动修改为: 成人票`);   

        // 后续处理  
      }  
    };  

    const submitOrder = () => {
      const orderDetails = passengerList.value
      .filter(passenger => checkedStatus.value[passenger.name]) // 过滤出 isChecked 为 true 的乘客 
      .map(passenger => {
        return {
          name: passenger.name as string,
          isChecked: checkedStatus.value[passenger.name] as boolean,
          ticketType: ticketTypes.value[passenger.name] as string,
          passengerID: passenger.passengerID as string,
        };
      });

      if (!orderDetails.length) {
        window.alert('您没有选择乘客，请选择至少一个乘客！');
      } else {
        // 检查是否有未选择 ticketType 的订单  
        const hasUnselectedTicketType = orderDetails.some(order => !order.ticketType);  
        if (hasUnselectedTicketType) {  
          // 弹窗提示  
          window.alert('请确保所有选中的乘客都选择了票种类型！');  
          // 终止
        } else {
          // 后续处理
          orderDetails.forEach(item => {
            createOrder(item);
          });
          
          window.alert('订单提交成功！');
          console.log('订单详情:', orderDetails);
        }
      } 
    };

    // 获取该用户的常用乘车人
    const getPassengerList = async () => {
      const url = 'http://localhost:5000/api/tickets/getPassenger';

      passengerList.value = [];

      try {
        const response = await axios.post(url, { userID: user_ID });
        if (response.data) {
          passengerList.value = response.data as Passenger[];
        } else {
          console.log('empty');
        }
      } catch (error) {
        console.error('Error fetching train data:', error);
      }
    };

    const createOrder = async (orderDetails: OrderDetails) => {
      const url = 'http://localhost:5000/api/tickets/createOrder';

      const type = orderDetails.ticketType === '学生票' ? 'student' : 'adult';

      try {
        const response = await axios.post(url, {
          userID: user_ID,
          trainID: receivedData.value.trainID,
          price: receivedData.value.price,
          passengerID: orderDetails.passengerID,
          ticketType: type
        });
        if (response.data) {
          window.alert('订单创建成功！');
        } else {
          window.alert('订单创建失败！');
        }
      } catch (error) {
        console.error('Error creating order:', error);
      }
    };

    onMounted(() => {
      getPassengerList();
    });

    return {
      user_ID,
      passengerList,
      checkedStatus,
      ticketTypes,
      handleCheckboxChange,
      handleTicketTypeChange,
      submitOrder,
      createOrder,
      getPassengerList,
    };
  }
});
</script>

<style scoped>
.BodyWrapper {
    width: 1200px;
    padding: 0 5px;
    margin-left: auto;
    margin-right: auto;
}

.passenger-list {
  border: 1px solid #1678be;
  border-radius: 5px 5px 0 0;
  -moz-border-radius: 5px 5px 0 0;
  -ms-border-radius: 5px 5px 0 0;
  -o-border-radius: 5px 5px 0 0;
  -webkit-border-radius: 5px 5px 0 0;
  background-position: 0 -400px
}

.passenger-list .passenger-list-hd {
  height: 32px;
  line-height: 30px;
  color: #c4ecff;
  padding-left: 20px;
  font-size: 16px;
  font-weight: 700;
  position: left;
  background-color: #4568f1;
}

.passenger-list .passenger-list-bd {
  background: #ffffff;
  border-top: 0
}

.passenger-item {
  border-bottom: 1px dashed #999;
  padding-bottom: 25px;
}

.passenger-item .passenger-info {
  height: 25px;
  position: relative;
  display: block;
}

.passenger-item .passenger-ticket {
    width: 100%;
    border: 1px solid #999;
    margin-top: 10px;
    background: #eef1f8;
}

.passenger-item .passenger-check-box {
    float: left;
    width: 110px;
    height: 20px;
    line-height: 20px;
    padding: 2px 0;
    overflow: hidden;
}

.passenger-item .passenger-check-box input[type="checkbox"] {
  vertical-align: -3px;
  margin-right: 4px;
}

tbody {
  display: table-row-group;
  vertical-align: middle;
  unicode-bidi: isolate;
  border-color: inherit;
}

tr {
  display: table-row;
  vertical-align: inherit;
  unicode-bidi: isolate;
  border-color: inherit;
}

.passenger-item .passenger-ticket th {
  height: 28px;
  line-height: 28px;
  text-align: center;
  padding-left: 5px;
  font-weight: 400;
  border-bottom: 1px solid #999;
  background-position: 0 -200px;
}

.passenger-item .passenger-ticket td {
  height: 30px;
  line-height: 30px;
  padding: 4px 0 4px 5px;
}

.layout-submitBtn {
    height: 30px;
    padding: 10px 0;
    text-align: center;
}

.btn {
  display: inline-block;
  font-size: 14px;
  color: #333;
  min-width: 80px;
  height: 30px;
  line-height: 30px;
  padding: 1px 1px;
  border: 1px solid #dedede;
  border-radius: 6px;
  background-color: #fff;
  text-align: center;
  white-space: nowrap;
  vertical-align: middle;
  cursor: pointer;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
  outline: none;
  position: relative;
  -webkit-transition: border-color ease-in-out 0.15s,color ease-in-out 0.15s,background ease-in-out 0.15s,-webkit-box-shadow ease-in-out 0.15s;
  transition: border-color ease-in-out 0.15s,color ease-in-out 0.15s,background ease-in-out 0.15s,-webkit-box-shadow ease-in-out 0.15s;
  transition: border-color ease-in-out 0.15s,box-shadow ease-in-out 0.15s,color ease-in-out 0.15s,background ease-in-out 0.15s;
  transition: border-color ease-in-out 0.15s,box-shadow ease-in-out 0.15s,color ease-in-out 0.15s,background ease-in-out 0.15s,-webkit-box-shadow ease-in-out 0.15s;
}

.btn:hover {
  color: #ff8000;
  border-color: #ff8000;
}

.btn.btn-primary {
  background: #ff8000;
  color: #fff;
  border-color: #ff8000;
}

.btn.btn-primary:hover {
  background: #ff6602;
  border-color: #ff6602;
}
</style>