<template>
  <div class="edit-info">
    <h2>修改个人信息</h2>
    <form @submit.prevent="submitForm">
      <div class="form-group">
        <label for="name">姓名:</label>
        <input type="text" id="name" v-model="form.username" placeholder="留空表示不修改" />
      </div>
      <div class="form-group">
        <label for="password">密码:</label>
        <input type="password" id="password" v-model="form.password" placeholder="留空表示不修改" />
      </div>
      <div class="form-group">
        <label for="idNumber">身份证号:</label>
        <input type="text" id="idNumber" v-model="form.idNumber" placeholder="留空表示不修改" />
      </div>
      <div class="form-group">
        <label for="isStudent">是否为学生:</label>
        <select id="isStudent" v-model="form.isStudent">
          <option :value="true">是</option>
          <option :value="false">否</option>
        </select>
      </div>
      <div class="form-group">
        <label for="phone">电话:</label>
        <input type="tel" id="phone" v-model="form.phoneNumber" placeholder="留空表示不修改" />
      </div>
      <div class="form-group">
        <label for="ridingInterval">乘车区间:</label>
        <input type="text" id="ridingInterval" v-model="form.ridingInterval" placeholder="留空表示不修改" />
      </div>
      <button type="submit">保存</button>
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import axios from 'axios';

interface UserForm {
  username: string;
  password: string;
  idNumber: string;
  isStudent: boolean;
  phoneNumber: string;
  ridingInterval: string;
}

export default defineComponent({
  name: 'EditInfo',
  setup() {
    const form = ref<UserForm>({
      username: '',
      password: '',
      idNumber: '',
      isStudent: true,
      phoneNumber: '',
      ridingInterval: '',
    });

    const submitForm = async () => {
      const userId = localStorage.getItem('User_ID');

      if (!userId) {
        alert('用户ID未找到，请重新登录。');
        return;
      }

      try {
        // 组织数据
        const userData = {
          User_id: userId,
          Username: form.value.username || undefined,  // 如果为空则不修改
          Password: form.value.password || undefined,
          Id_number: form.value.idNumber || undefined,
          Is_student: form.value.isStudent,
          Status: true, // 默认设置为 true 或根据需求设置
          Phone_number: form.value.phoneNumber || undefined,
          Riding_interval: form.value.ridingInterval || undefined,
        };

        // 调用 API 更新用户信息
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
});
</script>

<style scoped>
.edit-info {
  background-color: #f9f9f9;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

h2 {
  margin-bottom: 20px;
  color: #333;
}

.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
  color: #555;
}

input, select {
  width: 100%;
  padding: 10px;
  border: 1px solid #ddd;
  border-radius: 4px;
  box-sizing: border-box;
}

button {
  padding: 10px 15px;
  background-color: #007bff;
  border: none;
  color: white;
  border-radius: 4px;
  cursor: pointer;
  font-size: 16px;
}

button:hover {
  background-color: #0056b3;
}
</style>
