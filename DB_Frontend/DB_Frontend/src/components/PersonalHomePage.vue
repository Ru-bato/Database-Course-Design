<template>
  <div class="home-page">
    <h2>欢迎来到铁路售票系统个人主页</h2>
    <p v-if="user">
      你好，{{ user.username }}！你的手机号是 {{ user.phoneNumber }}。
    </p>
    <p v-else>
      请<a href="/login">登录</a>
    </p>
    <p>在这里，您可以管理您的个人信息、编辑乘车人信息，以及进行管理员操作。</p>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'HomePage',
  data() {
    return {
      user: null, // 存储当前登录用户的信息
    };
  },
  created() {
    this.fetchUserInfo();
  },
  methods: {
    fetchUserInfo() {
      // 调用后端API获取当前登录用户信息
      axios.get('http://localhost:5000/api/User/GetCurrentUserInfo')
        .then(response => {
          this.user = response.data;
        })
        .catch(error => {
          console.error("获取用户信息失败：", error);
        });
    },
  },
};
</script>

<style scoped>
.home-page {
  background-color: white;
  padding: 20px;
  border-radius: 8px;
}
</style>

  