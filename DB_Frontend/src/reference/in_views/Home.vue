<template>
  <!-- <body> -->
  <!-- 整个页面 -->
  <div id="layout">
    <!-- 包括上方搜索栏和导航页 -->
    <div class="header" role="banner">
      <!-- ::before -->
      <!-- 填充两侧，保证内容在中间 -->
      <div class="wrapper">
        <!-- 左侧logo部分 -->
        <div class="header-con">
          <h1 class="logo" role="banner">
            <!-- 链接跳转主页 -->
            <a href="#" style="background-color: white;">
              <img src="../img/logo.png" alt="logo" style="height:100%; ">
            </a>
          </h1>
          <!-- logo的右侧部分，包括搜索条和右侧菜单 -->
          <div class="header-right">
            <!-- 搜索条，包括搜索栏和搜索按钮-->
            <div class="header-search">
              <div class="search-bd">
                <!-- 提交表单(待添加) -->
                <input type="text" class="search-input" id="search-input" placeholder="搜索车票/餐饮/常旅客/相关章程">
              </div>
              <button class="search-btn"><img class="icon-search" src="../img/search.png" alt="serach"></button>

            </div>
            <!-- 右侧菜单 -->
            <ul class="header-menu">
              <li class="menu-line">|</li>
              <li class="menu-item menu-nav">
                <a href="#" class="menu-nav-hd" aria-expanded="true">
                  <div class="dropdown-arrow">
                  </div>我的星济铁路
                </a>

                <ul class="menu-dropdown">
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
      <div class="nav-box">
        <ul class="nav">
          <li id="shouye" class="nav-item"><a class="nav-hd" href="#">首页<div class="dropdown-arrow"></div>
              <!-- 下拉箭头 --></a>
            <ul class="nav-dropdown">
              <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
            </ul>
          </li>
          <li id="chepiao" class="nav-item"><a class="nav-hd" href="#">车票<div class="dropdown-arrow"></div>
            </a>
            <ul class="nav-dropdown">
              <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
            </ul>
          </li>
          <li id="tuangoufuwu" class="nav-item"><a class="nav-hd" href="#">团购服务<div class="dropdown-arrow">
              </div></a>
            <ul class="nav-dropdown">
              <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
            </ul>
          </li>
          <li id="zhanchefuwu" class="nav-item"><a class="nav-hd" href="#">站车服务<div class="dropdown-arrow">
              </div></a>
            <ul class="nav-dropdown">
              <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
            </ul>
          </li>
          <li id="shanglvfuwu" class="nav-item"><a class="nav-hd" href="#">商旅服务<div class="dropdown-arrow">
              </div></a>
            <ul class="nav-dropdown">
              <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
            </ul>
          </li>
          <li id="chuxingzhinan" class="nav-item"><a class="nav-hd" href="#">出行指南<div class="dropdown-arrow">
              </div></a>
            <ul class="nav-dropdown">
              <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
            </ul>
          </li>
          <li id="xinxichaxun" class="nav-item"><a class="nav-hd" href="#">信息查询<div class="dropdown-arrow">
              </div></a>
            <ul class="nav-dropdown">
              <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
              <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
            </ul>
          </li>
        </ul>
      </div>
    </div>
  </div>
  <!-- </body> -->
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { useRouter } from 'vue-router';

export default defineComponent({
  name: 'Home',
  setup() {
    const router = useRouter();

    const navigateToBooking = () => {
      router.push('/booking');
    };

    return {
      navigateToBooking,
    };
  },
});
</script>

<style scoped>
/* 默认所有样式首先都符合以下条件 */
html,
body,
div,
span,
object,
iframe,
h1,
h2,
h3,
h4,
h5,
h6,
p,
blockquote,
pre,
a,
abbr,
acronym,
address,
code,
del,
dfn,
em,
img,
q,
dl,
dt,
dd,
ol,
ul,
li,
fieldset,
form,
label,
legend,
table,
caption,
tbody,
tfoot,
thead,
tr,
th,
td {
  border: 0;
  list-style: none;
  margin: 0;
  padding: 0;
  text-decoration: none;
  color: black;
}

.header {
  background: #fff;
  position: relative;
  z-index: 2000;
}

.header .header-con {
  height: 80px;
}

.logo {
  float: left;
  margin: 15px 0 0 0;
  padding: 0;
}

.logo a {
  display: block;
  width: 200px;
  height: 50px;

}

.header-search {
  float: left;
  width: 390px;
  margin: 5px 0 5px 90px;
}

.header .wrapper {
  width: 1200px;
  padding: 0 5px;
  margin-left: auto;
  margin-right: auto;
}

.header .header-con {
  height: 80px;
}

.header:before {
  content: "";
  position: absolute;
  top: 24px;
  right: 0;
  left: 50%;
  height: 40px;
  background: #f8f8f8;
  z-index: 1;
}

/* ----------------------搜索条-------------------------- */
.header-right {
  float: right;
  margin: 24px 0 0 0;
  width: 940px;
  height: 40px;
  background-image: url(../img/train.png);
  background-repeat: no-repeat;
  position: relative;
  z-index: 2000;
  box-sizing: border-box;
}

.header-right .header-search .search-bd {
  position: relative;
  width: 360px;
}

.header-right .header-search .search-input {
  width: 100%;
  float: left;
  border-radius: 0;
  height: 30px;
  line-height: 20px;
  border: 1px solid #EFEFEF;
  padding: 4px 10px;
  background-color: #fff;
  color: #333;
  outline: none;
  font-size: 14px;
  box-sizing: border-box;
}

.search-btn {
  padding: 0; /* 使用 padding 代替固定宽高 */
  width: auto; /* 使宽度自适应 */
  height: 30px; /* 保持高度一致 */
  border: none;
  background-color: #3b99fc;
  cursor: pointer;
  /* 鼠标指针形状 */
  transition: all 0.3s ease;
  /* 添加过渡效果 */
}

.search-btn:hover {
  background-color: #2676e3;
  /* 这里使用深蓝色的具体颜色值，例如：#00008B */
}

.search-btn .icon-search {
  width: 16px;
  height: 16px;
  vertical-align: middle; /* 确保图标垂直居中 */
}

/* ----------------------菜单栏-------------------------- */
.header-menu {
  float: right;
  padding-right: 10px;
  list-style: none;

  box-sizing: border-box;
}

.header-menu .menu-item {
  float: left;
  margin-left: 10px;
  height: 40px;
  line-height: 40px;
  font-size: 12px;
  position: relative;
  color: #acd1f9;
}

.header-menu .menu-item .menu-nav-hd:hover {
  color: blue;
  
}

.header-menu .menu-line {
  float: left;
  margin-left: 10px;
  height: 40px;
  line-height: 40px;
  font-size: 12px;
  position: relative;
  color: #acd1f9;
}

/*我的星济铁路下拉菜单*/
.menu-nav-hd .dropdown-arrow {
  float: left;
  position: relative;
  top: 50%;
  right: 10px;
  /* 调整箭头与文本的距离 */
  transform: translateY(-50%);
  width: 0;
  height: 0;
  border-left: 5px solid transparent;
  border-right: 5px solid transparent;
  border-top: 5px solid blue;
}


.header-menu:hover .menu-dropdown {
  display: block;
}

.menu-dropdown-item {
  padding: 10px;
  text-decoration: none;
  color: #3B99FC;
  display: block;
}

/* 初始状态下隐藏下拉菜单 */
.menu-dropdown {
  display: none;
  position: absolute;
  background-color: #fff;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

/*  ----------------------导航栏-------------------------- */
.nav-box {
  height: 40px;
  background: #3B99FC;
}

.nav {
  width: 1190px;
  margin-left: auto;
  margin-right: auto;
  position: relative;
  height: 40px;
  z-index: 1900;
}

.nav .nav-item .nav-hd {
  display: block;
  height: 40px;
  line-height: 40px;
  color: #fff;
  text-align: center;
}

.nav .nav-item {
  background-color: #3B99FC;
  float: left;
  width: 159px;
}

/* 鼠标移动上方深色反显 */
.nav .nav-item:hover {
  background-color: #2676e3;
}

/* 导航栏下拉菜单 */
.nav .nav-item .dropdown-arrow {
  float: right;
  position: relative;
  top: 50%;
  right: 10px;
  /* 调整箭头与文本的距离 */
  transform: translateY(-50%);
  width: 0;
  height: 0;
  border-left: 5px solid transparent;
  border-right: 5px solid transparent;
  border-top: 5px solid #fff;
  /* 箭头颜色和大小，与背景色相同 */
  cursor: pointer;
}

/* 定义弹出窗口大小 1272/8=159*/
.nav-item:hover .nav-dropdown {
  display: block;
  width: 159px;
}

.nav-dropdown-item {
  padding: 10px;
  text-decoration: none;
  color: #3B99FC;
  display: block;
}

/* 初始状态下隐藏下拉菜单 */
.nav-dropdown {
  display: none;
  position: absolute;
  background-color: #fff;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}
</style>