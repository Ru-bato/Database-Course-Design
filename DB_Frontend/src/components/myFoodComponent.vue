<template>
    <!-- 整个页面 -->
    <div id="layout">
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