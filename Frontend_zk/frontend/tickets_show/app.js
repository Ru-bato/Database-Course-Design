import axios from 'axios'; 

function test() {
    // 解析查询字符串
    const queryString = window.location.search;

    // 创建 URLSearchParams 对象
    const urlParams = new URLSearchParams(queryString);

    // 获取参数值
    const from = urlParams.get('from');
    const to = urlParams.get('to');

    // 打印参数值（或用于其他逻辑）
    console.log('from:', from);
    console.log('to:', to);

    return { from, to };
}

document.addEventListener('DOMContentLoaded', () => {
    const searchButton = document.getElementById('searchButton');
    const ticketTableBody = document.querySelector('#ticketTable tbody');

    const { from, to } = test();

    const baseUrl = 'http://localhost:5193/api/tickets';

    async function fetchTickets() {
        try {
            console.log('Sending request to backend with parameters:', {
                startStation: from,
                endStation: to,
                departureDate: new Date().toISOString().split('T')[0]
            });

            const response = await axios.get(baseUrl, {
                params: {
                    startStation: from,
                    endStation: to,
                    departureDate: new Date().toISOString().split('T')[0] // 当前日期或其他逻辑
                }
            });

            const tickets = response.data;
            console.log('API response:', tickets);


            ticketTableBody.innerHTML = '';

            // 插入新车票信息
            tickets.forEach(ticket => {
                const row = document.createElement('tr');

                row.innerHTML = `
                <td>${ticket.trainNumber}</td>
                <td>${ticket.departureTime}</td>
                <td>${ticket.arrivalTime}</td>
                <td>${ticket.duration}</td>
                <td>${ticket.businessClass}</td>
                <td>${ticket.firstClass}</td>
                <td>${ticket.secondClass}</td>
                <td>${ticket.other}</td>
                <td><button>Book</button></td>
            `;

                ticketTableBody.appendChild(row);
            });
        } 
        catch (error) {
            console.error('Error fetching tickets:', error);
            alert('An error occurred while fetching tickets.');
        }
    }

        fetchTickets();

        // 点击搜索按钮时，也可以重新进行搜索
        searchButton.addEventListener('click', () => {
            fetchTickets();
        });
});
