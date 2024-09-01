<template>
  <div class="header" role="banner">
    <div class="wrapper">
      <div class="header-con">
        <h1 class="logo" role="banner">
          <a href="#">
            <img src="@/assets/logo.png" alt="logo" style="height:50px">
          </a>
        </h1>
        <div class="header-right">
          <div class="header-search">
            <div class="search-bd">
              <input type="text" class="search-input" id="search-input" placeholder="搜索车票/餐饮/常旅客/相关章程">
            </div>
            <button class="search-btn">
              <img class="icon-search" src="@/assets/search.png" alt="search">
            </button>
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
export default {
  data() {
    return {
      activeDropdown: null
    };
  },
  methods: {
    toggleDropdown(menu) {
      this.activeDropdown = this.activeDropdown === menu ? null : menu;
    }
  }
};
</script>

<style scoped>
@import "../assets/header_style.css";
</style>
