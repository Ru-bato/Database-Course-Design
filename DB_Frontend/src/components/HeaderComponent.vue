<script lang="ts" setup>
import { ref, reactive, watch, onMounted } from 'vue';
import router from '@/router';
import axios from 'axios';

// 定义响应式状态
const activeDropdown = ref<string | null>(null);
const searchQuery = ref('');
const suggestions = ref<string[]>([]);
const questions = ref<string[]>([]);
const answers = ref<string[]>([]);
const dialogVisible = ref(false);
const answer = ref('');
const isLoggedIn = ref<boolean>(false);
const username = ref<string>('');
interface User {
  username: string;
  phone_Number: string;
}


// 监视器（watcher）
watch(searchQuery, (newQuery) => {
  if (newQuery) {
    fetchSuggestions(newQuery);
  } else {
    suggestions.value = [];
    questions.value = [];
    answers.value = [];
  }
});


// 挂载后检查用户登录状态
onMounted(() => {
  const userId = localStorage.getItem('User_ID');
  if (userId) {
    isLoggedIn.value = true;
    fetchUserInfo(userId);
  }
});

// 方法
const toggleDropdown = (menu: string) => {
  activeDropdown.value = activeDropdown.value === menu ? null : menu;
};
const user = ref<User | null>(null);
const fetchUserInfo = async (userId:string) => {
  try {
    // 发送 POST 请求，传递用户 ID 参数
    const response = await axios.post<User>('http://localhost:5000/api/User/GetCurrentUserInfo', null, {
      params: {
        id: userId
      }
    });

    // 将响应的数据保存到 user 变量中
    user.value = response.data;
    console.log(user.value)
;  } catch (error) {
    console.error('获取用户信息失败：', error);
  }
};

const showAnswer = () => {
  // 暂存并跳转页面
  localStorage.setItem('searchQuery', searchQuery.value);
  router.push({ name: 'TicketsQuestions' });
};

const fetchSuggestions = async (query: string) => {
  try {
    const request = { QuestionSearch: query };
    const response = await axios.post('http://localhost:5000/Question', request, {
      headers: {
        'Content-Type': 'application/json',
      },
    });
    suggestions.value = response.data.questions;
    questions.value = response.data.questions;
    answers.value = response.data.answers;
  } catch (error) {
    console.error('Error fetching suggestions:', error);
  }
};

const selectSuggestion = (suggestion: string) => {
  searchQuery.value = suggestion;
  suggestions.value = []; // 选择后清空联想词
};

const getQuestionBackend = async () => {
  try {
    const response = await axios.get('http://localhost:5000/Question');
    processQuestions(response.data); // 处理数据并填充数组
    console.log('response', response.data);
  } catch (error) {
    console.error('Error fetching data:', error);
  }
};

const getCombinedArray = (index: number) => {
  // 检查索引是否在有效范围内
  if (index < 0 || index >= questions.value.length || index >= answers.value.length) {
    return []; // 返回空数组表示无效索引
  }

  // 获取问题和答案数组
  const qList = questions.value[index];
  const aList = answers.value[index];

  // 如果 questions 或 answers 为 null 或 undefined，则返回空数组
  if (!Array.isArray(qList) || !Array.isArray(aList)) {
    return [];
  }

  // 确保 answers 数组的长度与 questions 数组匹配
  return qList.map((question, i) => ({
    question: question,
    answer: aList[i] || '', // 确保不会超出范围
  }));
};
// 挂载后检查用户登录状态
onMounted(() => {
  const userId = localStorage.getItem('User_ID');
  if (userId) {
    isLoggedIn.value = true;
    username.value = localStorage.getItem('Username') || ''; // 假设用户名存储在localStorage中
  }
});
</script>

<template>
  <div class="header" role="banner">
    <div class="wrapper">
      <div class="header-con">
        <h1 class="logo" role="banner">
          <a href="/" class="href-style">
            <img src="../assets/logo.png" alt="logo" style="height:50px">
          </a>
        </h1>
        <div class="header-right">
          <div class="header-search">
            <div class="search-bd">
              <input type="text" class="search-input" id="search-input" v-model="searchQuery"
                placeholder="搜索车票/餐饮/常旅客/相关章程">

              <div v-if="searchQuery && suggestions.length > 1" class="suggestions">
                <div v-for="suggestion in suggestions" :key="suggestion" @click="selectSuggestion(suggestion)">
                  {{ suggestion }}
                </div>
              </div>
            </div>
            <button class="search-btn" @click="showAnswer"><img class="icon-search" src="../assets/search.png"
                alt="search"></button>
          </div>
          <ul class="header-menu">
            <li class="menu-line">|</li>
            <li class="menu-item menu-nav">
              <a href="#" class="menu-nav-hd" @click="toggleDropdown('myRail')">
                <!-- <div class="dropdown-arrow"></div> -->
                我的星济铁路
              </a>
              <!-- <ul class="menu-dropdown" v-show="activeDropdown === 'myRail'">
                <li><a class="menu-dropdown-item" href="#">子菜单项 1</a></li>
                <li><a class="menu-dropdown-item" href="#">子菜单项 2</a></li>
                <li><a class="menu-dropdown-item" href="#">子菜单项 3</a></li>
              </ul> -->
            </li>
            <li class="menu-line">|</li>
            <li id="header-login" class="menu-item menu-log">
              <template v-if="isLoggedIn">
                <span>你好, {{ user?.username }}</span>
              </template>
              <template v-else>
                <a href="#" class="menu-nav-hd">登录</a>
                <a href="#" class="menu-nav-hd">注册</a>
              </template>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>



<style scoped>
@import "../assets/header_style.css";

.href-style {
  background-color: transparent;
}

.suggestions {
  border: 1px solid #ccc;
  border-top: none;
  max-height: 200px;
  overflow-y: auto;
  background: white;
  width: 100%;
  z-index: 1000;
  margin-top: 5px;
  /* 调整联想框与搜索栏的间距 */
}

.suggestions div {
  padding: 10px;
  cursor: pointer;
}

.suggestions div:hover {
  background-color: #f0f0f0;
}
</style>
