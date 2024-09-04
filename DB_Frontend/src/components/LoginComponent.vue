<template>
  <div class="login-container">
    <div class="login-card">
      <h2 class="login-title">星济铁路系统登录</h2>
      <form @submit.prevent="login" class="login-form">
        <div class="form-group">
          <label for="userTel">手机号</label>
          <input type="text" id="user_Tel" v-model="userTel" placeholder="请输入手机号" required />
        </div>
        <div class="form-group">
          <label for="password">密码</label>
          <input type="password" id="password" v-model="password" placeholder="请输入密码" required />
        </div>
        <button type="submit" class="btn btn-primary">登录</button>
        <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>
        <div class="extra-options">
          <router-link :to="{ name: 'Register' }" class="btn">注册</router-link>
          <router-link :to="{ name: 'VerifyIdentity' }" class="btn">忘记密码</router-link>
        </div>
      </form>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import axios from 'axios';
import { useRouter } from 'vue-router';

const userTel = ref('');
const password = ref('');
const errorMessage = ref('');
const router = useRouter();

const login = () => {
  axios.post('http://localhost:5000/api/login/login', {
    Phone_Number: userTel.value,
    Password: password.value
  })
    .then(response => {
      // 登陆成功
      console.log(response.data);
      const userId = response.data.data.user_ID;
      if (userId) {
        alert(userId);
        localStorage.setItem('User_ID', userId);
        console.log('登陆成功');
        router.push('/'); // 重定向到首页
      }
    })
    .catch(error => {
      // 错误处理
      if (error.response) {
        switch (error.response.status) {
          case 401:
            errorMessage.value = '用户名或密码错误';
            break;
          default:
            errorMessage.value = '登录页面出错';
        }
      }
    });
};
</script>

<style scoped>
/* 整体容器样式 */
.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 100vw;
  /* background: linear-gradient(135deg, #74ebd5, #acb6e5); */
  background: linear-gradient(135deg, #3c89e1, #7bc4fc);
  /* 蓝色渐变背景 */
  /* overflow: hidden !important; */
}

/* 登录卡片样式 */
.login-card {
  background-color: white;
  padding: 40px;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  width: 350px;
  text-align: center;
}

/* 标题样式 */
.login-title {
  margin-bottom: 30px;
  font-size: 24px;
  color: #333;
}

/* 表单样式 */
.login-form {
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
  /* border-color: #74ebd5; */
  border-color: #4A90E2;
  /* 聚焦时的蓝色边框 */
  outline: none;
}

/* 按钮样式 */
.btn {
  padding: 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 16px;
  transition: background-color 0.3s;
}

.btn-primary {
  /* background-color: #74ebd5; */
  background-color: #4A90E2;
  /* 蓝色按钮 */
  color: white;
}

.btn-primary:hover {
  /* background-color: #5cc6b4; */
  background-color: #357ABD;
  /* 悬停时更深的蓝色 */
}

/* 额外选项样式 */
.extra-options {
  display: flex;
  justify-content: space-between;
  margin-top: 20px;
}

.extra-options a {
  font-size: 14px;
  /* color: #74ebd5; */
  color: #4A90E2;
  /* 蓝色链接 */
  text-decoration: none;
  transition: color 0.3s;
}

.extra-options a:hover {
  /* color: #5cc6b4; */
  color: #357ABD;
  /* 悬停时更深的蓝色 */
}

.error-message{
  color: red;
}
</style>
