<template>
    <!-- 整个页面 -->
    <div id="layout">
        <!-- 包括上方搜索栏和导航页 -->
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