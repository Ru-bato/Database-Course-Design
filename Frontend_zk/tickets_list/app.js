document.addEventListener('DOMContentLoaded', () => {
    const searchButton = document.getElementById('searchButton');
    const ticketTableBody = document.querySelector('#ticketTable tbody');

    // 模拟车票数据
    const tickets = [
        {
            trainNumber: 'G101',
            departureTime: '08:00',
            arrivalTime: '12:00',
            duration: '4h',
            businessClass: '¥1200',
            firstClass: '¥800',
            secondClass: '¥500',
            other: '无座 ¥200'
        },
        {
            trainNumber: 'D202',
            departureTime: '09:00',
            arrivalTime: '13:30',
            duration: '4h 30m',
            businessClass: '¥1100',
            firstClass: '¥750',
            secondClass: '¥450',
            other: '无座 ¥180'
        },
        // 可以添加更多模拟数据
    ];

    // 点击搜索按钮时，插入车票信息
    searchButton.addEventListener('click', () => {
        // 清空之前的车票信息
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
    });
});
