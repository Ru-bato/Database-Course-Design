<template>
    <div class="edit-passenger">
      <h2>编辑乘车人信息</h2>
      <button @click="showForm = true">添加乘车人</button>
      
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
              <button @click="deletePassenger(index)">删除</button>
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
  export default {
    name: 'EditPassenger',
    data() {
      return {
        passengers: [
          { name: '张三', idNumber: '123456789012345678' },
          { name: '李四', idNumber: '876543210987654321' },
        ],
        showForm: false,
        isEditing: false,
        currentEditIndex: null,
        form: {
          name: '',
          idNumber: '',
        },
      };
    },
    methods: {
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
      deletePassenger(index) {
        if (confirm('确定要删除这个乘车人吗？')) {
          this.passengers.splice(index, 1);
        }
      },
      savePassenger() {
        if (this.isEditing) {
          this.passengers.splice(this.currentEditIndex, 1, { ...this.form });
          alert('乘车人信息已更新！');
        } else {
          this.passengers.push({ ...this.form });
          alert('乘车人已添加！');
        }
        this.showForm = false;
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
  