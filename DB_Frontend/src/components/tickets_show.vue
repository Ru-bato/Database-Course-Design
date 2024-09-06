<template>
        <!--  车票列表显示 -->
        <div id="app">
            <!-- 一级标题，铁路车票展示 -->
            <h1>铁路车票列表</h1>

            <label for="startStation">出 发 城 市</label>
            <input list="startChoices" id="startStation" placeholder="请选择始发站">
            

         <datalist class="datalist" id="startChoices">
            <option v-for="city in departureCities" :key="city" :value="city"/>
                <!-- 更多城市 -->
                <option value="北京" />
                <option value="上海" />
                <option value="广州" />
                <option value="深圳" />
                <option value="杭州" />
                <option value="天津" />
                <option value="武汉" />
                <option value="长沙" />
                <option value="南昌" />
                <option value="福州" />
                <option value="香港" />
                <option value="澳门" />
                <option value="昆明" />

         </datalist>


            <label for="endStation">终 点 城 市</label>
            <input list="endChoices" id="endStation" placeholder="请选择终点站">
            
            <datalist class="datalist" id="endChoices">
                <option v-for="city in arrivalCities" :key="city" :value="city"/>
                <option value="北京" />
                <option value="上海" />
                <option value="广州" />
                <option value="深圳" />
                <option value="杭州" />
                <option value="哈尔滨" />
                <option value="贵阳" />
                <option value="成都" />
                <option value="重庆" />
                <option value="拉萨" />
                <option value="西安" />
                <option value="兰州" />
                <option value="银川" />
                <option value="西宁" />
                <option value="乌鲁木齐" />
               
                
            </datalist>
            
            
            

            
            

            <label for="date">出 发 日 期</label>
            <input type="date" id="date">
            <button id="searchButton" @click="fetchTickets">搜 索</button>
            <table id="ticketTable">
                <thead>
                    <tr>
                        <!-- <th>车 次</th>
                        <th>出 发 车 站</th>
                        <th>到 达 车 站</th>
                        <th>出 发 时 间</th>
                        <th>到 达 时 间</th>
                        <th>历 时</th>
                        <th>票 价</th>
                        <th>剩 余 票 数</th>
                        <th>预 定</th> -->

                        <th @click="sortTable('trainId')">车 次 <span v-if="sortColumn === 'trainId'"
                                :class="{ 'sort-asc': sortOrder === 'asc', 'sort-desc': sortOrder === 'desc' }"></span>
                        </th>
                        <th @click="sortTable('departureStation')">出 发 车 站 <span
                                v-if="sortColumn === 'departureStation'"
                                :class="{ 'sort-asc': sortOrder === 'asc', 'sort-desc': sortOrder === 'desc' }"></span>
                        </th>
                        <th @click="sortTable('arrivalStation')">到 达 车 站 <span v-if="sortColumn === 'arrivalStation'"
                                :class="{ 'sort-asc': sortOrder === 'asc', 'sort-desc': sortOrder === 'desc' }"></span>
                        </th>
                        <th @click="sortTable('departureTime')">出 发 时 间 <span v-if="sortColumn === 'departureTime'"
                                :class="{ 'sort-asc': sortOrder === 'asc', 'sort-desc': sortOrder === 'desc' }"></span>
                        </th>
                        <th @click="sortTable('arrivalTime')">到 达 时 间 <span v-if="sortColumn === 'arrivalTime'"
                                :class="{ 'sort-asc': sortOrder === 'asc', 'sort-desc': sortOrder === 'desc' }"></span>
                        </th>
                        <th @click="sortTable('duration')">历 时 <span v-if="sortColumn === 'duration'"
                                :class="{ 'sort-asc': sortOrder === 'asc', 'sort-desc': sortOrder === 'desc' }"></span>
                        </th>
                        <th @click="sortTable('Price')">票 价 <span v-if="sortColumn === 'Price'"
                                :class="{ 'sort-asc': sortOrder === 'asc', 'sort-desc': sortOrder === 'desc' }"></span>
                        </th>
                        <th @click="sortTable('remaining_tickets')">剩 余 票 数 <span
                                v-if="sortColumn === 'remaining_tickets'"
                                :class="{ 'sort-asc': sortOrder === 'asc', 'sort-desc': sortOrder === 'desc' }"></span>
                        </th>
                        <th>预 定</th>

                    </tr>
                </thead>
                <tbody>
                    <!-- Ticket rows will be inserted here dynamically -->
                     
                </tbody>
            </table>
        </div>
        <!-- 车票列表显示结束 -->
    


</template>

<script lang="ts">
import axios from 'axios';
import { defineAsyncComponent, defineComponent, ref, onMounted} from 'vue';


const baseUrl = 'http://localhost:5193/api/ticket';

const searchButton = document.getElementById('searchButton');
interface Ticket {
    trainId: string;
    departureStation: string;
    arrivalStation: string;
    departureTime: string;
    arrivalTime: string;
    duration: string;
    Price: number;
    ticketsNum: number;
}
interface TicketMiddle {
    trainId: string;
    departureStation: string;
    arrivalStation: string;
    departureTime: string;
    arrivalTime: string;
    duration: string;
    Price: number;
    ticketsNum: number;
}


export default defineComponent({

    name:'TicketShow',
    data(){
            return {
                tickets: [] as Ticket[],
                sortColumn:'',
                sortOrder:'asc',
                departureCities:[] as string[],
                arrivalCities:[] as string[]

            };
        },
          
    methods: {
        
        async fetchTickets(): Promise<void> {
            if(document.getElementById('departureStation')&&document.getElementById('arrivalStation')){
            const from = document.getElementById('departureStation').value;
            const to = document.getElementById('arrivalStation').value;
            
            try {
                console.log('Sending request to backend with parameters:', {
                    startStation: from,
                    endStation: to,
                    departureDate: new Date().toISOString().split('T')[0]
                });

                const response = await axios.post(baseUrl, {
                        departureStation: from,
                        arrivalStation: to,
                        departureDate: new Date().toISOString().split('T')[0] // 当前日期或其他逻辑
                    
                });

                this.tickets = response.data;
                
        
                console.log('Tickets data:', this.tickets); 
                // console.log('API response:', tickets);
                this.sortTickets();

                const ticketTableBody = document.querySelector('#ticketTable tbody');
                // console.log('Ticket Table Body:', ticketTableBody); // 确保表格主体已被正确选中
                if (ticketTableBody) {
                    ticketTableBody.innerHTML = '';

                    // 插入新车票信息
                    this.tickets.forEach((ticket: Ticket) => {
                        const row = document.createElement('tr');

                        row.innerHTML = `
                <td>${ticket.trainId}</td>
                <td>${ticket.departureStation}</td>
                <td>${ticket.arrivalStation}</td>
                <td>${ticket.departureTime}</td>
                <td>${ticket.arrivalTime}</td>
                <td>${ticket.duration}</td>
                <td>${ticket.Price}</td>
                <td>${ticket.ticketsNum}</td>

                <td><button>Book</button></td>
            `;

                        ticketTableBody.appendChild(row);
                    });
                }
                else {
                    console.error('TicketTableBody is null');
                }
            }
            catch (error) {
                console.error('Error fetching tickets:', error);
                alert('An error occurred while fetching tickets.');
            }}
        },

        async fetchCities() {
            try {
                const response = await axios.get('http://localhost:5193/api/stations');
                const cities = response.data;
                cities.sort((a: string, b: string) => a.localeCompare(b));
                this.departureCities = cities;
                this.arrivalCities = cities; // 根据需要，你可以对不同的城市列表做不同处理
            } catch (error) {
                console.error('Failed to fetch cities', error);
            }
        },

        sortTable(column:string):void {
            if (this.sortColumn === column) {
                this.sortOrder = this.sortOrder === 'asc' ? 'desc' : 'asc';
            } else {
                this.sortColumn = column;
                this.sortOrder = 'asc';
            }

            this.sortTickets(); // 进行排序
        },

        sortTickets():void {
            if (!this.sortColumn) return;

            this.tickets.sort((a: Ticket, b: Ticket) => {
                const valueA = a[this.sortColumn as keyof Ticket];
                const valueB = b[this.sortColumn as keyof Ticket];

                if (this.sortColumn === 'Price' || this.sortColumn === 'remaining_tickets') {
                    const numA = Number(valueA);
                    const numB = Number(valueB);
                    return this.sortOrder === 'asc' ? numA - numB : numB - numA;
                }

                if (this.sortColumn === 'departureTime' || this.sortColumn === 'arrivalTime') {
                    return this.sortOrder === 'asc'
                        ? new Date(valueA as string).getTime() - new Date(valueB as string).getTime()
                        : new Date(valueB as string).getTime() - new Date(valueA as string).getTime();
                }

                return this.sortOrder === 'asc'
                    ? (valueA as string).localeCompare(valueB as string)
                    : (valueB as string).localeCompare(valueA as string);
            });
        }

    },

    mounted() {
        this.fetchTickets();
        // 点击搜索按钮时，也可以重新进行搜索
        if (searchButton) {
            searchButton.addEventListener('click', () => {
                this.fetchTickets();
            });
        }


    }

});
</script>

<style>


/* 车票列表 */
body {
    

    margin: 0;
    padding: 0;
    width: 100%;
    height: 100%;
    text-align: center;
    vertical-align: middle;

}

#app {

    margin: 0 auto;
    height: auto;
    width: 90%;
    background: none;
    padding: 20px;
    max-width: 1200px;
    box-shadow: none;
    overflow: visible;
    font-weight: bold;
    text-align: center;
    vertical-align: middle;


    /* margin-top: 500px;
    height: 600px;
    text-align: justify;
    background: #fff;
    padding: 20px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    overflow: auto;
    max-height: calc(100vh-600px);
    background-color: transparent;
    overflow-y: auto;
    font-weight: bold;
    margin: 0 auto;
    position: relative;
    width: 1200px; */
}

table {
    position: relative;
    width: 100%;
    height: 100%;
    max-width: 1200px;
    border-collapse: collapse;
    margin-top: 120px;
    text-align: center;
    vertical-align: middle;
}


th,
td {
    border: 1px solid #ddd;
    padding: 14px;
    text-align: center;
    vertical-align: middle;
    min-width: 90px;
}

th {
    background-color: #007bff;
    color: white;
    text-align: center;
    vertical-align: middle;

}

input {
    margin: 5px;
    padding: 8px;
    border: 1px solid #ccc;
    border-radius: 4px;
}

button {
    padding: 8px 16px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

button:hover {
    background-color: #0056b3;
}

.sort-asc::after {
    content: '▲';
    font-size: 12px;
    margin-left: 5px;
}

.sort-desc::after {
    content: '▼';
    font-size: 12px;
    margin-left: 5px;
}

</style>

