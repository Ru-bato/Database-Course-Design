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
        <tr v-for="(passenger, index) in passengers" :key="index">
          <td>{{ passenger.name }}</td>
          <td>{{ passenger.idNumber }}</td>
          <td>
            <button @click="editPassenger(index)">编辑</button>
            <button @click="deletePassenger(passenger.id)">删除</button>
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
            <input type="text" id="name" v-model="form.name" required />
          </div>
          <div class="form-group">
            <label for="idNumber">身份证号:</label>
            <input type="text" id="idNumber" v-model="form.idNumber" required />
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

<script>
import axios from 'axios';

export default {
name: 'EditPassenger',
data() {
  return {
    passengers: [],
    showForm: false,
    isEditing: false,
    currentEditIndex: null,
    form: {
      name: '',
      idNumber: '',
    },
  };
},
created() {
  this.loadPassengers();
},
methods: {
  async loadPassengers() {
    try {
      const userId = localStorage.getItem('User_ID');
      const response = await axios.get(`http://localhost:5000/api/Passenger/GetPassengersByUserId/${userId}`);
      this.passengers = response.data;
    } catch (error) {
      console.error('获取乘车人信息时出错:', error);
    }
  },
  addPassenger() {
    this.isEditing = false;
    this.form = { name: '', idNumber: '' };
    this.showForm = true;
  },
  editPassenger(index) {
    this.isEditing = true;
    this.currentEditIndex = index;
    this.form = { ...this.passengers[index] };
    this.showForm = true;
  },
  async deletePassenger(id) {
    if (confirm('确定要删除这个乘车人吗？')) {
      try {
        await axios.delete(`http://localhost:5000/api/Passenger/DeletePassenger/${id}`);
        alert('乘车人已删除！');
        this.loadPassengers(); // 刷新乘车人列表
      } catch (error) {
        console.error('删除乘车人时出错:', error);
        alert('删除失败，请稍后重试。');
      }
    }
  },
  async savePassenger() {
    const userId = localStorage.getItem('User_ID');
    const passengerData = {
      ...this.form,
      User_id: userId
    };

    try {
      if (this.isEditing) {
        await axios.put('http://localhost:5000/api/Passenger/UpdatePassenger', passengerData);
        alert('乘车人信息已更新！');
      } else {
        await axios.post('http://localhost:5000/api/Passenger/CreatePassenger', passengerData);
        alert('乘车人已添加！');
      }
      this.showForm = false;
      this.loadPassengers(); // 刷新乘车人列表
    } catch (error) {
      console.error('保存乘车人信息时出错:', error);
      alert('保存失败，请稍后重试。');
    }

    this.form = { name: '', idNumber: '' };
    this.isEditing = false;
    this.currentEditIndex = null;
  },
  cancelForm() {
    this.showForm = false;
    this.form = { name: '', idNumber: '' };
    this.isEditing = false;
    this.currentEditIndex = null;
  },
},
};
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
  