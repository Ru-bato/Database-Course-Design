<template>
  <div class="register-container">
    <div class="register-card">
      <h2 class="register-title">用户注册</h2>
      <form @submit.prevent="handleRegister" class="register-form">
        <div class="form-group">
          <label for="userTel">手机号</label>
          <input type="text" id="userTel" v-model="registerForm.userTel" placeholder="请输入手机号" required />
        </div>
        <div class="form-group">
          <label for="username">姓名</label>
          <input type="text" id="username" v-model="registerForm.username" placeholder="请输入用户名" required />
        </div>
        <div class="form-group">
          <label for="id-number">身份证号</label>
          <input type="text" id="id-number" v-model="registerForm.id_number" placeholder="请输入身份证号" required />
        </div>
        <div class="form-group">
          <label for="password">密码</label>
          <input type="password" id="password" v-model="registerForm.password" @input="validatePassword" placeholder="请输入密码" required />
          <p v-if="registerForm.passwordValidationMessage" class="error-message">{{ registerForm.passwordValidationMessage }}</p>
        </div>
        <div class="form-group">
          <label for="confirm-password">确认密码</label>
          <input type="password" id="confirm-password" v-model="registerForm.confirmPassword" placeholder="请确认密码"
          @input="checkPasswords" required />
          <p v-if="registerForm.passwordError" class="error-message">{{ registerForm.passwordError }}</p>
        </div>
        <p v-if="registerForm.errorMessage" class="error-message">{{ registerForm.errorMessage }}</p>
        <button type="submit" class="btn btn-primary" :disabled="!!registerForm.passwordError">注册</button>
        <div class="extra-options">
          <router-link :to="{ name: 'Login' }" class="btn">已有账号，返回登录</router-link>
        </div>
      </form>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';
import { useRouter } from 'vue-router';
import axios from 'axios';

const router = useRouter();

const registerForm = ref({
  username: '',
  userTel: '',
  id_number: '',
  password: '',
  confirmPassword: '',
  passwordValidationMessage: '',
  passwordError: '',
  errorMessage: '',
});

const handleRegister = () => {
  if (registerForm.value.passwordError) {
    // 如果有密码错误提示，则不提交表单
    return;
  }

  axios.post('http://localhost:5000/api/register', {
    Username: registerForm.value.username,
    Password: registerForm.value.password,
    Phone_Number: registerForm.value.userTel,
    ID_Number: registerForm.value.id_number,
  })
    .then(response => {
      // 注册成功
      console.log(response.data);
      router.push('/'); // 注册成功后跳转到主页 Todo: 注册成功应该与登录成功有同样的鉴权标识
    })
    .catch(error => {
      // Todo: 错误处理还需完善
      if (error.response) {
        console.log(error)
        switch (error.response.status) {
          case 400:
          registerForm.value.errorMessage = '注册失败，请检查输入的内容';
            break;
          case 409:
          registerForm.value.errorMessage = '手机号已被注册';
            break;
          default:
          registerForm.value.errorMessage = '注册页面出错';
        }
      }
    });
};

const validatePassword = () => {
  const password = registerForm.value.password;
  const hasMinimumLength = password.length >= 10;
  const hasDigit = /\d/.test(password);
  const hasLowerCase = /[a-z]/.test(password);
  const hasUpperCase = /[A-Z]/.test(password);
  const hasSpecialCharacter = /[/!@#$%^&*_()]/.test(password);

  if (!hasMinimumLength) {
    registerForm.value.passwordValidationMessage = '密码长度至少为10个字符';
  } else if (!hasDigit) {
    registerForm.value.passwordValidationMessage = '密码必须包含至少一个数字';
  } else if (!hasLowerCase) {
    registerForm.value.passwordValidationMessage = '密码必须包含至少一个小写字母';
  } else if (!hasUpperCase) {
    registerForm.value.passwordValidationMessage = '密码必须包含至少一个大写字母';
  } else if (!hasSpecialCharacter) {
    registerForm.value.passwordValidationMessage = '密码必须包含至少一个特殊字符';
  } else {
    registerForm.value.passwordValidationMessage = '';
  }
};

const checkPasswords = () => {
  if (registerForm.value.password && registerForm.value.confirmPassword) {
    if (registerForm.value.password !== registerForm.value.confirmPassword) {
      registerForm.value.passwordError = '密码不匹配';
    } else {
      registerForm.value.passwordError = '';
    }
  }
};
</script>

<style scoped>
/* 与登录界面相同的样式 */
.register-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 100vw;
  background: linear-gradient(135deg, #4A90E2, #50B3FF);
  /* 蓝色渐变背景 */
}

.register-card {
  background-color: white;
  padding: 40px;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  width: 350px;
  text-align: center;
}

.register-title {
  margin-bottom: 30px;
  font-size: 24px;
  color: #333;
}

.register-form {
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
