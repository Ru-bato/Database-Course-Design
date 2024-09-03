<template>
  <div class="forgot-password-container">
    <div class="forgot-password-card">
      <h2 class="forgot-password-title">忘记密码</h2>
      <form @submit.prevent="handleIdentityVerification" class="forgot-password-form">
        <div class="form-group">
          <label for="telephone">手机号</label>
          <input type="tel" id="telephone" v-model="resetForm.Phone_Number" placeholder="请输入注册手机号" required />
        </div>
        <div class="form-group">
          <label for="ID_Number">身份证号</label>
          <input type="text" id="ID_Number" v-model="resetForm.ID_Number" placeholder="请输入身份证号" required />
        </div>
        <button type="submit" class="btn btn-primary">身份验证</button>
        <p v-if="resetForm.errorMessage" class="error-message">{{ resetForm.errorMessage }}</p>
        <div class="extra-options">
          <router-link :to="{ name: 'Login' }" class="btn">返回登录</router-link>
        </div>
      </form>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import axios from 'axios';

const router = useRouter();

const resetForm = ref({
  Phone_Number: '',
  ID_Number: '',
  errorMessage: '',
});

const handleIdentityVerification = () => {
  axios.post('http://localhost:5000/api/login/forgot_verify', {
    Phone_Number: resetForm.value.Phone_Number,
    ID_Number: resetForm.value.ID_Number
  }).then(response => {
    console.log(response.data);
    alert("验证成功");
    localStorage.setItem('ready_to_reset_User_ID', response.data.data.user_ID);
    router.push({ name: 'ResetPassword' });
  }).catch(error => {
    console.log(error);
    if (error.response) {
      switch (error.response.status) {
          case 401:
            resetForm.value.errorMessage = '身份信息不匹配，请重新输入';
            break;
          default:
            resetForm.value.errorMessage = '身份信息验证页面出错';
        }
    }
  });
};
</script>

<style scoped>
/* 与登录界面相同的样式 */
.forgot-password-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 100vw;
  background: linear-gradient(135deg, #4A90E2, #50B3FF);
  /* 蓝色渐变背景 */
}

.forgot-password-card {
  background-color: white;
  padding: 40px;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  width: 350px;
  text-align: center;
}

.forgot-password-title {
  margin-bottom: 30px;
  font-size: 24px;
  color: #333;
}

.forgot-password-form {
  display: flex;
  flex-direction: column;
  gap: 15px;
}

.form-group {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}

.form-group label {
  margin-bottom: 5px;
  font-size: 14px;
  color: #666;
}

.form-group input {
  width: 100%;
  padding: 10px;
  border: 1px solid #ddd;
  border-radius: 5px;
  font-size: 14px;
  transition: border-color 0.3s;
}

.form-group input:focus {
  border-color: #4A90E2;
  /* 聚焦时的蓝色边框 */
  outline: none;
}

.btn {
  padding: 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 16px;
  transition: background-color 0.3s;
}

.btn-primary {
  background-color: #4A90E2;
  /* 蓝色按钮 */
  color: white;
}

.btn-primary:hover {
  background-color: #357ABD;
  /* 悬停时更深的蓝色 */
}

.extra-options {
  display: flex;
  justify-content: center;
  margin-top: 20px;
}

.extra-options a {
  font-size: 14px;
  color: #4A90E2;
  /* 蓝色链接 */
  text-decoration: none;
  transition: color 0.3s;
}

.extra-options a:hover {
  color: #357ABD;
  /* 悬停时更深的蓝色 */
}

.error-message{
  color: red;
}
</style>