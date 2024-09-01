<template>
  <div class="login-container">
    <div class="login-box">
      <h2>登录</h2>
      <el-form :model="form" ref="formRef" status-icon>
        <el-form-item prop="phonenumber">
          <el-input v-model="form.username" placeholder="手机号" prefix-icon="el-icon-user"></el-input>
        </el-form-item>
        <el-form-item prop="password">
          <el-input v-model="form.password" placeholder="密码" prefix-icon="el-icon-lock" type="password"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="handleLogin">登录</el-button>
        </el-form-item>
        <div class="links">
          <el-button @click="showRegister">注册</el-button>
          <el-button @click="showForgotPassword">忘记密码</el-button>
        </div>
      </el-form>
    </div>

    <el-dialog title="注册" :visible.sync="showRegisterForm">
      <el-form :model="registerForm" ref="registerFormRef" status-icon>
        <el-form-item prop="username">
          <el-input v-model="registerForm.username" placeholder="用户名" prefix-icon="el-icon-user"></el-input>
        </el-form-item>
        <el-form-item prop="password">
          <el-input v-model="registerForm.password" placeholder="密码" prefix-icon="el-icon-lock"
            type="password"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="handleRegister">注册</el-button>
        </el-form-item>
      </el-form>
    </el-dialog>

    <el-dialog title="忘记密码" :visible.sync="showForgotPasswordForm">
      <el-form :model="forgotPasswordForm" ref="forgotPasswordFormRef" status-icon>
        <el-form-item prop="email">
          <el-input v-model="forgotPasswordForm.email" placeholder="输入注册邮箱" prefix-icon="el-icon-message"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="handleForgotPassword">提交</el-button>
        </el-form-item>
      </el-form>
    </el-dialog>
  </div>
</template>

<script lang="ts" setup>
import { onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { ref } from 'vue';
import { ElForm, ElFormItem, ElInput, ElButton, ElDialog } from 'element-plus';

const router = useRouter();

onMounted(() => {
  const expireTime = localStorage.getItem('expireTime');
  if (expireTime) {
    const currentTime = new Date().getTime();
    if (currentTime <= parseInt(expireTime)) {
      // 用户已登录且登录未过期，重定向到主页
      router.push('/homepage');
    }
  }
});

interface LoginForm {
  username: string;
  password: string;
}

interface RegisterForm {
  username: string;
  password: string;
}

interface ForgotPasswordForm {
  email: string;
}

const form = ref<LoginForm>({ username: '', password: '' });
const registerForm = ref<RegisterForm>({ username: '', password: '' });
const forgotPasswordForm = ref<ForgotPasswordForm>({ email: '' });

const formRef = ref<InstanceType<typeof ElForm>>();
const registerFormRef = ref<InstanceType<typeof ElForm>>();
const forgotPasswordFormRef = ref<InstanceType<typeof ElForm>>();

const showRegisterForm = ref(false);
const showForgotPasswordForm = ref(false);

const handleLogin = () => {
  // 状态存入localStorage
  const currentTime = new Date().getTime();
  const expireTime = currentTime + 30 * 60 * 1000; // 30分钟后过期

  localStorage.setItem('loginTime', currentTime.toString());
  localStorage.setItem('expireTime', expireTime.toString());
  
  // 处理登录

};

const handleRegister = () => {
  // 注册逻辑
};

const handleForgotPassword = () => {
  // 忘记密码逻辑
};

const showRegister = () => {
  showRegisterForm.value = true;
};

const showForgotPassword = () => {
  showForgotPasswordForm.value = true;
};
</script>

<style scoped>
.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background: linear-gradient(to right, #6a11cb, #2575fc);
  animation: gradient 10s ease infinite;
}

.login-box {
  background: #fff;
  padding: 2rem;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
  width: 100%;
  max-width: 400px;
  text-align: center;
  position: relative;
  overflow: hidden;
}

.login-box h2 {
  margin-bottom: 1.5rem;
  font-size: 24px;
  color: #333;
}

.login-box .links {
  margin-top: 1rem;
  display: flex;
  justify-content: space-between;
}

@keyframes gradient {
  0% {
    background: linear-gradient(to right, #6a11cb, #2575fc);
  }

  50% {
    background: linear-gradient(to right, #ff6e7f, #bfe9ff);
  }

  100% {
    background: linear-gradient(to right, #6a11cb, #2575fc);
  }
}
</style>