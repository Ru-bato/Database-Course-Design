<template>
  <div class="admin-functions">
    <h2>管理员功能</h2>
    <button @click="showUserManagement">用户管理</button>
    <button @click="showOrderManagement">订单管理</button>
    <!-- 你可以根据需要添加更多管理员功能 -->

    <!-- 用户管理弹窗 -->
    <div v-if="showUserModal" class="mymodal">
      <div class="modal-content">
        <span class="myclose" @click="closeUserModal">&times;</span>
        <UserManagement />
      </div>
    </div>

    <!-- 订单管理弹窗 -->
    <div v-if="showOrderModal" class="mymodal">
      <div class="modal-content">
        <span class="myclose" @click="closeOrderModal">&times;</span>
        <OrderManagement />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import UserManagement from './AdminUserManagement.vue';
import OrderManagement from './AdminOrderManagement.vue';

export default defineComponent({
  name: 'AdminFunctions',
  components: {
    UserManagement,
    OrderManagement
  },
  setup() {
    const showUserModal = ref<boolean>(false);
    const showOrderModal = ref<boolean>(false);

    const showUserManagement = () => {
      showUserModal.value = true;
    };

    const closeUserModal = () => {
      showUserModal.value = false;
    };

    const showOrderManagement = () => {
      showOrderModal.value = true;
    };

    const closeOrderModal = () => {
      showOrderModal.value = false;
    };

    return {
      showUserModal,
      showOrderModal,
      showUserManagement,
      closeUserModal,
      showOrderManagement,
      closeOrderModal
    };
  }
});
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
  width: 80%;
  max-width: 800px;
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
