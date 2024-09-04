<template>
  <div class="edit-passenger">
    <h2>编辑乘车人信息</h2>
    <button @click="addPassenger">添加乘车人</button>
    
    <table>
      <thead>
        <tr>
          <th>姓名</th>
          <th>身份证号</th>
          <th>操作</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(passenger, index) in passengers" :key="passenger.passenger_id">
          <td>{{ passenger.Passenger_name }}</td>
          <td>{{ passenger.Id_number }}</td>
          <td>
            <button @click="editPassenger(index)">编辑</button>
            <button @click="deletePassenger(passenger.passenger_id)">删除</button>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- 添加/编辑表单 -->
    <div v-if="showForm" class="form-modal">
      <div class="form-container">
        <h3>{{ isEditing ? '编辑乘车人' : '添加乘车人' }}</h3>
        <form @submit.prevent="savePassenger">
          <div class="form-group">
            <label for="name">姓名:</label>
            <input type="text" id="name" v-model="form.Passenger_name" required />
          </div>
          <div class="form-group">
            <label for="idNumber">身份证号:</label>
            <input type="text" id="idNumber" v-model="form.Id_number" required />
          </div>
          <div class="form-actions">
            <button type="submit">{{ isEditing ? '保存' : '添加' }}</button>
            <button type="button" @click="cancelForm">取消</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import axios from 'axios';

interface Passenger {
  passenger_id: string;
  User_id: string;
  Passenger_name: string;
  Id_number: string;
}

interface Form {
  Passenger_name: string;
  Id_number: string;
}

export default defineComponent({
  name: 'EditPassenger',
  setup() {
    const passengers = ref<Passenger[]>([]);
    const showForm = ref<boolean>(false);
    const isEditing = ref<boolean>(false);
    const currentEditIndex = ref<number | null>(null);
    const form = ref<Form>({
      Passenger_name: '',
      Id_number: '',
    });

    const loadPassengers = async () => {
      try {
        const userId = localStorage.getItem('User_ID');
        if (!userId) {
          alert('用户ID未找到，请重新登录。');
          return;
        }

        const response = await axios.get<Passenger[]>(`http://localhost:5000/api/Passenger/GetPassengersByUserId/${userId}`);
        passengers.value = response.data;
      } catch (error) {
        console.error('获取乘车人信息时出错:', error);
      }
    };

    const addPassenger = () => {
      isEditing.value = false;
      form.value = { Passenger_name: '', Id_number: '' };
      showForm.value = true;
    };

    const editPassenger = (index: number) => {
      isEditing.value = true;
      currentEditIndex.value = index;
      form.value = { ...passengers.value[index] };
      showForm.value = true;
    };

    const deletePassenger = async (id: string) => {
      if (confirm('确定要删除这个乘车人吗？')) {
        try {
          await axios.delete(`http://localhost:5000/api/Passenger/DeletePassenger/${id}`);
          alert('乘车人已删除！');
          loadPassengers(); // 刷新乘车人列表
        } catch (error) {
          console.error('删除乘车人时出错:', error);
          alert('删除失败，请稍后重试。');
        }
      }
    };

    const savePassenger = async () => {
      const userId = localStorage.getItem('User_ID');
      if (!userId) {
        alert('用户ID未找到，请重新登录。');
        return;
      }

      const passengerData: Passenger = {
        passenger_id: isEditing.value && currentEditIndex.value !== null
          ? passengers.value[currentEditIndex.value].passenger_id
          : userId,  // 新增时 passenger_id 为User_id
        User_id: userId,
        Passenger_name: form.value.Passenger_name,
        Id_number: form.value.Id_number,
      };

      try {
        if (isEditing.value) {
          await axios.put('http://localhost:5000/api/Passenger/UpdatePassenger', passengerData);
          alert('乘车人信息已更新！');
        } else {
          await axios.post('http://localhost:5000/api/Passenger/CreatePassenger', passengerData);
          alert('乘车人已添加！');
        }
        showForm.value = false;
        loadPassengers(); // 刷新乘车人列表
      } catch (error) {
        console.error('保存乘车人信息时出错:', error);
        alert('保存失败，请稍后重试。');
      }

      form.value = { Passenger_name: '', Id_number: '' };
      isEditing.value = false;
      currentEditIndex.value = null;
    };

    const cancelForm = () => {
      showForm.value = false;
      form.value = { Passenger_name: '', Id_number: '' };
      isEditing.value = false;
      currentEditIndex.value = null;
    };

    // 加载乘车人信息
    loadPassengers();

    return {
      passengers,
      showForm,
      isEditing,
      form,
      addPassenger,
      editPassenger,
      deletePassenger,
      savePassenger,
      cancelForm,
    };
  },
});
</script>

<style scoped>
.edit-passenger {
  background-color: white;
  padding: 20px;
  border-radius: 8px;
}

button {
  padding: 8px 12px;
  margin: 5px;
  background-color: #007bff;
  border: none;
  color: white;
  border-radius: 4px;
  cursor: pointer;
}

button:hover {
  background-color: #0056b3;
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 15px;
}

th, td {
  border: 1px solid #ccc;
  padding: 10px;
  text-align: left;
}

.form-modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

.form-container {
  background-color: white;
  padding: 20px;
  border-radius: 8px;
  width: 300px;
}

.form-group {
  margin-bottom: 15px;
}

.form-actions {
  display: flex;
  justify-content: flex-end;
}

.form-actions button {
  margin-left: 10px;
}
</style>
