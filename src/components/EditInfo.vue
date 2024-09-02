<template>
    <div class="edit-info">
      <h2>修改个人信息</h2>
      <form @submit.prevent="submitForm">
        <div class="form-group">
          <label for="name">姓名:</label>
          <input type="text" id="name" v-model="form.name" required />
        </div>
        <div class="form-group">
          <label for="email">邮箱:</label>
          <input type="email" id="email" v-model="form.email" required />
        </div>
        <div class="form-group">
          <label for="phone">电话:</label>
          <input type="tel" id="phone" v-model="form.phone" required />
        </div>
        <button type="submit">保存</button>
      </form>
    </div>
  </template>
  
  <script>
  export default {
    name: 'EditInfo',
    data() {
      return {
        form: {
          name: '',
          email: '',
          phone: '',
        },
      };
    },
    methods: {
      submitForm() {
        // 在这里处理表单提交逻辑，如调用 API 更新用户信息
        alert('个人信息已更新！');
        console.log(this.form);
      },
    },
  };
  </script>
  
  <style scoped>
  .edit-info {
    background-color: white;
    padding: 20px;
    border-radius: 8px;
  }
  
  .form-group {
    margin-bottom: 15px;
  }
  
  label {
    display: block;
    margin-bottom: 5px;
    font-weight: bold;
  }
  
  input {
    width: 100%;
    padding: 8px;
    border: 1px solid #ccc;
    border-radius: 4px;
  }
  
  button {
    padding: 10px 15px;
    background-color: #007bff;
    border: none;
    color: white;
    border-radius: 4px;
    cursor: pointer;
  }
  
  button:hover {
    background-color: #0056b3;
  }
  </style>
  