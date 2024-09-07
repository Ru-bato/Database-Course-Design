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
        <div id="container">
        <div class="food-grid">
            <div v-for="item in foodList" :key="item.id" class="food-item">
                <img :src="item.image" alt="Food Image" class="food-image"/>
                <div class="food-details">
                    <label>{{ item.name }}</label>
                    <div class="quantity-control">
                        <input type="number" :value="quantities[item.id]" readonly class="quantity-input"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import axios from 'axios';

interface FoodItem {
    id: number;
    name: string;
    photo: string;
    quantity: number;
}

export default defineComponent({
    setup() {
        const foodList = ref<any[]>([]);
        const quantities = ref<{ [key: number]: number }>({});

        interface FoodItem {
    id: number;
    name: string;
    photo: string; // 本地图片路径
    quantity: number;
}
         // 从后端获取数据
         const FetchFood = async () => {
            try {
                const response = await axios.get('http://localhost:5000/api/FoodServer');
                console.log(response.data);

                // 确保 response.data 是 FoodItem 对象数组
                if (Array.isArray(response.data) && response.data.every(item => typeof item.name === 'string' && typeof item.photo === 'string')) {
                    foodList.value = response.data;
                } else {
                    console.error('Unexpected data format:', response.data);
                }
            } catch (error) {
                console.error('Error fetching food:', error);
            }
        };
        const mockData = [
            { id: 1, name: '孜然烤肉饭' ,image:'/images/001.jpg'},
            { id: 4, name: '盐水鸭饭' ,image:'/images/004.jpg'},
        ];

        const fetchFood = async () => {
            await new Promise(resolve => setTimeout(resolve, 500));
            foodList.value = mockData;
            foodList.value.forEach(item => quantities.value[item.id] = 1);  // 初始化份数
        };

        onMounted(() => {
            fetchFood();
        });

        const changeQuantity = (id: number, change: number) => {
            const newQuantity = (quantities.value[id] || 0) + change;
            if (newQuantity >= 0 && newQuantity <= 99) {
                quantities.value[id] = newQuantity;
            }
        };

        const submitQuantities = () => {
            console.log('Submitted quantities:', quantities.value);
        };

        return {
            foodList,
            quantities,
            changeQuantity,
            submitQuantities
        }
    }
});
</script>

<style scoped>
/* 引入全局默认样式  */
@import url("../assets/default_style.css");
/* 引入头部样式 */
@import url("../assets/header_style.css");
/* 引入餐饮样式 */
@import url("../assets/foodList.css");
</style>