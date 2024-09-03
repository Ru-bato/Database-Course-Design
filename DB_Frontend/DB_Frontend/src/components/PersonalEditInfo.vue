<template>
  <div class="edit-info">
    <h2>修改个人信息</h2>
    <form @submit.prevent="submitForm">
      <div class="form-group">
        <label for="name">姓名:</label>
        <input type="text" id="name" v-model="form.name" placeholder="留空表示不修改" />
      </div>
      <div class="form-group">
        <label for="phone">电话:</label>
        <input type="tel" id="phone" v-model="form.phone" placeholder="留空表示不修改" />
      </div>
      <div class="form-group">
        <label for="password">密码:</label>
        <input type="password" id="password" v-model="form.password" placeholder="留空表示不修改" />
      </div>
      <button type="submit">保存</button>
    </form>
  </div>
</template>

<script lang="ts">
import { ref } from 'vue';
import axios from 'axios';

export default {
  name: 'EditInfo',
  setup() {
    const form = ref({
      name: '',
      phone: '',
      password: '',
    });

    const submitForm = async () => {
      const userId = localStorage.getItem('User_ID');

      try {
        const userData = {
          User_id: userId,
          Username: form.value.name || undefined,  // 如果为空则不修改
          Phone_number: form.value.phone || undefined,
          Password: form.value.password || undefined,
        };

        const response = await axios.put('http://localhost:5000/api/User/UpdateUser', userData);

        if (response.status === 200) {
          alert('个人信息已更新！');
        } else {
          alert('更新失败，请稍后重试。');
        }
      } catch (error) {
        console.error('更新个人信息时出错:', error);
        alert('更新失败，请稍后重试。');
      }
    };

    return {
      form,
      submitForm,
    };
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
