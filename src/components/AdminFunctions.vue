<template>
    <div class="admin-functions">
      <h2>管理员功能</h2>
      <button @click="manageUsers">用户管理</button>
      <button @click="viewReports">查看报告</button>
      <!-- 你可以根据需要添加更多管理员功能 -->
      
      <!-- 示例弹窗 -->
      <div v-if="showModal" class="mymodal">
        <div class="modal-content">
          <span class="myclose" @click="closeModal">&times;</span>
          <p>{{ modalContent }}</p>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: 'AdminFunctions',
    data() {
      return {
        showModal: false,
        modalContent: '',
      };
    },
    methods: {
      manageUsers() {
        this.modalContent = '用户管理功能尚未实现。';
        this.showModal = true;
      },
      viewReports() {
        this.modalContent = '查看报告功能尚未实现。';
        this.showModal = true;
      },
      closeModal() {
        this.showModal = false;
        this.modalContent = '';
      },
    },
  };
  </script>
  
  <style scoped>
  .admin-functions {
    background-color: white;
    padding: 20px;
    border-radius: 8px;
  }
  
  button {
    padding: 10px 15px;
    margin: 5px;
    background-color: #28a745;
    border: none;
    color: white;
    border-radius: 4px;
    cursor: pointer;
  }
  
  button:hover {
    background-color: #218838;
  }
  
  .mymodal {
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
  
  .modal-content {
    background-color: white;
    padding: 20px;
    border-radius: 8px;
    width: 300px;
    position: relative;
  }
  
  .myclose {
    position: absolute;
    top: 10px;
    right: 15px;
    font-size: 20px;
    cursor: pointer;
  }
  </style>
  