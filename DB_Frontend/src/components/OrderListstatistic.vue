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

            <el-table :data="state.tableData" border style="width: 100%">
                <el-table-column prop="sales" label="销量" />
                <el-table-column prop="money" label="金额" />
                <el-table-column prop="wait" label="候补" />
            </el-table>
        </el-main>
    </el-container>
</template>

<script>

import { ref, reactive } from 'vue';
import axios from 'axios';

export default {
    setup() {
        const selectedOption = ref(null);
        const state = reactive({
            tableData: [],
            ticketsSum: '',
            salesSum: '',
            waitSum: '',
        });

        const sendData = async () => {
            if (selectedOption.value === null) {
                alert('请选择一个选项');
                return;
            }

            try {
                const response = await axios.post('http://localhost:5097/OrderList', {
                    TicketType: parseInt(selectedOption.value),
                });
                state.ticketsSum = response.data.ticketsSum;
                state.salesSum = response.data.salesSum;
                state.waitSum = response.data.waitSum;

                // 更新 tableData
                state.tableData = [{
                    sales: state.ticketsSum,
                    money: state.salesSum,
                    wait: state.waitSum,
                }];

            } catch (error) {
                console.error('发送数据时出错:', error);
                alert('发送数据时出错');
            }
        };

        return {
            selectedOption,
            state,
            sendData
        };
    }
};
</script>

<style>
/* 添加你自己的样式 */
</style>
