<template>
    <el-container>
        <el-header>
            <h1>选择票种</h1>
        </el-header>
        <el-main>
            <el-radio-group v-model="selectedOption">
                <el-radio label="1">成人</el-radio>
                <el-radio label="2">学生</el-radio>
            </el-radio-group>
            <el-button type="primary" @click="sendData">提交</el-button>
        </el-main>
    </el-container>
</template>

<script>
import { ref } from 'vue';
import axios from 'axios';
import { ElRadioGroup, ElRadio, ElButton, ElContainer, ElHeader, ElMain } from 'element-plus';

// 注册 Element Plus 组件
export default {
    name: 'App',
    components: {
        ElRadioGroup,
        ElRadio,
        ElButton,
        ElContainer,
        ElHeader,
        ElMain
    },
    setup() {
        const selectedOption = ref(null);

        const sendData = async () => {
            if (selectedOption.value === null) {
                alert('请选择一个选项');
                return;
            }

            try {
                const response = await axios.post('http://localhost:5097/OrderList', {
                    TicketType: parseInt(selectedOption.value)
                });
                alert(`总票数: ${response.data}`);
            } catch (error) {
                console.error('发送数据时出错:', error);
                alert('发送数据时出错');
            }
        };

        return {
            selectedOption,
            sendData
        };
    }
};
</script>

<style>
/* 添加你自己的样式 */
</style>
