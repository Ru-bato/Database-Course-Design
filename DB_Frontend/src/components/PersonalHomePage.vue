<template>
  <div class="home-page">
    <h2>欢迎来到铁路售票系统个人主页</h2>
    <p v-if="user">
      你好，{{ user.username }}！你的手机号是 {{ user.phone_Number }}。
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
  phone_Number: string;
}

export default defineComponent({
  name: 'HomePage',
  setup() {
    const user = ref<User | null>(null);

    const userId = localStorage.getItem('User_ID');
    // 异步获取用户信息
    const fetchUserInfo = async () => {
      try {
        // 发送 POST 请求，传递用户 ID 参数
        const response = await axios.post<User>('http://localhost:5000/api/User/GetCurrentUserInfo', null, {
          params: {
            id: userId
          }
        });
        
        // 将响应的数据保存到 user 变量中
        user.value = response.data;
        console.log(response.data)
      } catch (error) {
        console.error('获取用户信息失败：', error);
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
