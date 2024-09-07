<template>
    <!-- 整个页面 -->
    <div id="layout">
        <!-- 包括上方搜索栏和导航页 -->
        <div class="header" role="=banner">
            <!-- ::before -->
            <!-- 填充两侧，保证内容在中间 -->
            <div class="wrapper">
                <!-- 左侧logo部分 -->
                <div class="header-con">
                    <h1 class="logo" role="banner">
                        <!-- 链接跳转主页 -->
                        <a href="#">
                            <img src="../assets/logo.png" alt="logo" style="height:50px">
                        </a>
                    </h1>
                    <!-- logo的右侧部分，包括搜索条和右侧菜单 -->
                    <div class="header-right">
                        <!-- 搜索条，包括搜索栏和搜索按钮-->
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
        <!-- 页面内容 -->
        <div id="container">
            <!-- 商旅服务  餐饮·特产 -->
            <div class="food">
                <div class="food_i">
                    <div class="food_time">
                        <div>
                            <i class="iconfont icon-ScheduleConfig"></i>
                            <input name="" value="2024-09-08">
                        </div>
                    </div>
                    <div class="food_car">
                        <div>
                            <label>车次</label>
                            <input type="" name="" placeholder="请输入车次" />
                        </div>
                    </div>
                    <div class="food_from">
                        <div>
                            <label>乘车站</label>
                            <input type="" name="" placeholder="简码/汉字">
                        </div>
                    </div>
                    <div class="food_to">
                        <div>
                            <label>到达站</label>
                            <input type="" name="" placeholder="简码/汉字">
                        </div>
                    </div>
                    <div class="food_search">
                        <RouterLink to='/foodList'>搜索</RouterLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';

export default defineComponent({
    setup() {
        

		return {
            
        };
    }
});
</script>

<style scoped>
/* 引入全局默认样式  */
@import url("../assets/default_style.css");
/* 引入头部样式 */
@import url("../assets/header_style.css");
/* 引入餐饮样式 */
@import url("../assets/foodServer.css");
</style>