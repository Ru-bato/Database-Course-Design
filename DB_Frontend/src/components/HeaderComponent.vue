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
                <div class="dropdown-arrow"></div>我的星济铁路
              </a>
              <ul class="menu-dropdown" v-show="activeDropdown === 'myRail'">
                <li><a class="menu-dropdown-item" href="#">子菜单项 1</a></li>
                <li><a class="menu-dropdown-item" href="#">子菜单项 2</a></li>
                <li><a class="menu-dropdown-item" href="#">子菜单项 3</a></li>
              </ul>
            </li>
            <li class="menu-line">|</li>
            <li id="header-login" class="menu-item menu-log">
              <a href="#" class="menu-nav-hd">登录</a>
              <a href="#" class="menu-nav-hd">注册</a>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import router from '@/router';
import axios from 'axios';

export default {
  data() {
    return {
      activeDropdown: null,
      searchQuery: '',
      suggestions: [],
      questions: [],
      answers: [],
      dialogVisible: false,
      answer: '',
    };
  },
  watch: {
    searchQuery(newQuery) {
      if (newQuery) {
        this.fetchSuggestions(newQuery);
      } else {
        this.suggestions = [];
        this.questions = [];
        this.answers = [];
      }
    }
  },
  methods: {
    toggleDropdown(menu) {
      this.activeDropdown = this.activeDropdown === menu ? null : menu;
    },
    showAnswer() {
      // 暂存并跳转页面
      localStorage.setItem('searchQuery', this.searchQuery);
      router.push({name: 'TicketsQuestions'});
    },
    async fetchSuggestions(query) {
      try {
        const request = { QuestionSearch: query };
        const response = await axios.post('http://localhost:5000/Question', request, {
          headers: {
            'Content-Type': 'application/json'
          }
        });
        this.suggestions = response.data.questions;
        this.questions = response.data.questions;
        this.answers = response.data.answers;
      } catch (error) {
        console.error('Error fetching suggestions:', error);
      }
    },
    selectSuggestion(suggestion) {
      this.searchQuery = suggestion;
      this.suggestions = []; // 选择后清空联想词
    },
    async getQuestionBackend() {
      try {
        const response = await axios.get('http://localhost:5000/Question');
        this.processQuestions(response.data);  // 处理数据并填充数组
        console.log("response", response.data);
        console.log("this.textArray", this.textArray);
      } catch (error) {
        console.error('Error fetching data:', error);
      }

    },
    getCombinedArray(index) {
      // 检查索引是否在有效范围内
      if (index < 0 || index >= this.textArray.length || index >= this.answerArray.length) {
        return []; // 返回空数组表示无效索引
      }

      // 获取问题和答案数组
      const questions = this.textArray[index];
      const answers = this.answerArray[index];

      // 如果 questions 或 answers 为 null 或 undefined，则返回空数组
      if (!Array.isArray(questions) || !Array.isArray(answers)) {
        return [];
      }

      // 确保 answers 数组的长度与 questions 数组匹配
      return questions.map((question, i) => ({
        question: question,
        answer: answers[i] || ''  // 确保不会超出范围
      }));
    },

  }
};
</script>

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
