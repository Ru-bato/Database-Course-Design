<template>
  <div class="home-page">
    <h2>欢迎来到铁路售票系统个人主页</h2>
    <p v-if="user">
      你好，{{ user.Username }}！你的手机号是 {{ user.Phone_Number }}。
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

// 定义响应的数据类型
type UserInfo = {
  Username: string;
  Phone_Number: string;
};

const user = ref<UserInfo | null>(null);

export default defineComponent({
  name: 'HomePage',
  setup() {
    // 异步获取用户信息的函数
    const fetchUserInfo = async () => {
      try {
        // 从 localStorage 获取用户ID
        const userId = localStorage.getItem('User_ID');

        // 如果用户ID存在
        if (userId) {
          // 使用 axios 发送 GET 请求
          const response = await axios.get(`http://localhost:5000/api/User/GetCurrentUserInfo/${userId}`);

          // 更新响应数据
          user.value = response.data.data; // 注意：response.data.data 是根据后端返回的数据结构而定
        } else {
          console.error("User ID is not found in localStorage.");
        }
      } catch (error) {
        console.error("获取用户信息失败：", error);
      }
    };
    onMounted(() => {
      if (!localStorage.getItem('User_ID')) {
        user.value = null;
      }
      else {
        fetchUserInfo();
      };
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
