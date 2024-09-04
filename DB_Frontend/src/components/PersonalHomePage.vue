<template>
  <div class="home-page">
    <h2>欢迎来到铁路售票系统个人主页</h2>
    <p v-if="user">
      你好，{{ user.username }}！你的手机号是 {{ user.phoneNumber }}。
    </p>
    <p v-else>
      请登录 <a href="/login">登录</a>
    </p>
    <p>在这里，您可以管理您的个人信息、编辑乘车人信息，以及进行管理员操作。</p>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import axios from 'axios';

interface User {
  username: string;
  phoneNumber: string;
}

export default defineComponent({
  name: 'HomePage',
  setup() {
    const user = ref<User | null>(null);

    const fetchUserInfo = async () => {
      try {
        const response = await axios.get<User>('http://localhost:5000/api/User/GetCurrentUserInfo');
        user.value = response.data;
      } catch (error) {
        console.error("获取用户信息失败：", error);
      }
    };

    onMounted(() => {
      fetchUserInfo();
    });

    return {
      user,
    };
  },
});
</script>

<style scoped>
.home-page {
  background-color: white;
  padding: 20px;
  border-radius: 8px;
}
</style>
