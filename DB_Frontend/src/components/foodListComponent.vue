<template>
    <!-- 整个页面 -->
    <div id="layout">
        <div id="container">
            <div class="food-grid">
                <div v-for="item in foodList" :key="item.id" class="food-item">
                    <img :src="item.image" alt="Food Image" class="food-image" />
                    <div class="food-details">
                        <label>{{ item.name }}</label>
                        <div class="quantity-control">
                            <button @click="changeQuantity(item.id, -1)">-</button>
                            <input type="number" :value="quantities[item.id]" readonly class="quantity-input" />
                            <button @click="changeQuantity(item.id, 1)">+</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- 将按钮移出容器以固定在底部 -->
        <button @click="submitQuantities" class="submit-button">确认</button>
    </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import axios from 'axios';
import { useRouter } from 'vue-router';

const router = useRouter();

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
        const router = useRouter();

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
            { id: 1, name: '孜然烤肉饭', image: '/images/001.jpg' },
            { id: 2, name: '红烧排骨套餐', image: '/images/002.jpg' },
            { id: 3, name: '四喜丸子套餐', image: '/images/003.jpg' },
            { id: 4, name: '盐水鸭饭', image: '/images/004.jpg' },
            { id: 5, name: '鱼香肉丝饭', image: '/images/005.jpg' },
            { id: 6, name: '炒牛肉饭', image: '/images/006.jpg' },
            { id: 7, name: '宫保鸡丁套餐', image: '/images/007.jpg' },
            { id: 8, name: '梅菜烧肉', image: '/images/008.jpg' },
            { id: 9, name: '西蓝花炒肉', image: '/images/009.jpg' }
        ];

        const fetchFood = async () => {
            await new Promise(resolve => setTimeout(resolve, 500));
            foodList.value = mockData;
            foodList.value.forEach(item => quantities.value[item.id] = 0);  // 初始化份数
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
            alert('您已购买成功')
            router.push({ name: 'MyFood' });
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