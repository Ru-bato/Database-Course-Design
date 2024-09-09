<template>
  <div class="forgot-password-container">
    <div class="forgot-password-card">
      <h2 class="forgot-password-title">重置密码</h2>
      <form @submit.prevent="handlePasswordReset" class="forgot-password-form">
        <div class="form-group">
          <label for="new_password">新密码</label>
          <input type="password" id="new_password" v-model="resetForm.new_password" @input="validatePassword"
            placeholder="请输入新密码" required />
          <p v-if="resetForm.passwordValidationMessage" class="error-message">{{
            resetForm.passwordValidationMessage }}</p>
        </div>
        <div class="form-group">
          <label for="confirm_password">确认密码</label>
          <input type="password" id="confirm_password" v-model="resetForm.confirm_password" @input="checkPasswords"
            placeholder="请确认密码" required />
          <p v-if="resetForm.passwordError" class="error-message">{{ resetForm.passwordError }}</p>
        </div>
        <button type="submit" class="btn btn-primary">重置密码</button>
        <p v-if="resetForm.errorMessage" class="error-message">{{ resetForm.errorMessage }}</p>
        <div class="extra-options">
          <router-link :to="{ name: 'Login' }" class="btn">返回登录</router-link>
        </div>
      </form>
    </div>
  </div>
</template>

<!-- TODO: 路由守卫，不能直接跳到这里 -->
<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import axios from 'axios';
const router = useRouter();

const resetForm = ref({
  new_password: '',
  confirm_password: '',
  passwordValidationMessage: '',
  passwordError: '',
  errorMessage: '',
});

const handlePasswordReset = () => {
  if (resetForm.value.passwordError) {
    // 如果有密码错误提示，则不提交表单
    return;
  }
  axios.post('http://localhost:5000/api/login/reset_password', {
    User_ID: localStorage.getItem('ready_to_reset_User_ID'),
    New_Password: resetForm.value.new_password,
  })
    .then(response => {
      console.log(response.data);
      alert("密码重置成功");
      router.push({ name: 'Login' });
    })
    .catch(error => {
      if (error.response) {
        alert("重置密码出错");
      }
    });
};

const validatePassword = () => {
  const password = resetForm.value.new_password;
  const hasMinimumLength = password.length >= 10;
  const hasDigit = /\d/.test(password);
  const hasLowerCase = /[a-z]/.test(password);
  const hasUpperCase = /[A-Z]/.test(password);
  const hasSpecialCharacter = /[/!@#$%^&*_()]/.test(password);

  if (!hasMinimumLength) {
    resetForm.value.passwordValidationMessage = '密码长度至少为10个字符';
  } else if (!hasDigit) {
    resetForm.value.passwordValidationMessage = '密码必须包含至少一个数字';
  } else if (!hasLowerCase) {
    resetForm.value.passwordValidationMessage = '密码必须包含至少一个小写字母';
  } else if (!hasUpperCase) {
    resetForm.value.passwordValidationMessage = '密码必须包含至少一个大写字母';
  } else if (!hasSpecialCharacter) {
    resetForm.value.passwordValidationMessage = '密码必须包含至少一个特殊字符';
  } else {
    resetForm.value.passwordValidationMessage = '';
  }
};

const checkPasswords = () => {
  if (resetForm.value.new_password && resetForm.value.confirm_password) {
    if (resetForm.value.new_password !== resetForm.value.confirm_password) {
      resetForm.value.passwordError = '密码不匹配';
    } else {
      resetForm.value.passwordError = '';
    }
  }
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

.error-message {
  color: red;
}
</style>