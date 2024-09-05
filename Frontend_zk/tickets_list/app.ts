interface Ticket {
    trainNumber: string;
    departureTime: string;
    arrivalTime: string;
    duration: string;
    businessClass: string;
    firstClass: string;
    secondClass: string;
    other: string;
}

// 假设这是从后端获取的数据
const fetchTickets = async (startStation: string, endStation: string, date: string): Promise<Ticket[]> => {
    // 模拟后端请求
    return [
        {
            trainNumber: "G104",
            departureTime: "06:27",
            arrivalTime: "13:12",
            duration: "06:45",
            businessClass: "13",
            firstClass: "--",
            secondClass: "候补",
            other: "--"
        },
        {
            trainNumber: "G102",
            departureTime: "06:37",
            arrivalTime: "12:38",
            duration: "06:01",
            businessClass: "10",
            firstClass: "--",
            secondClass: "11",
            other: "--"
        }
        // 更多数据...
    ];
};

const displayTickets = (tickets: Ticket[]) => {
    const ticketTableBody = document.getElementById('ticketTable')!.getElementsByTagName('tbody')[0];
    ticketTableBody.innerHTML = ""; // 清除现有行

    tickets.forEach(ticket => {
        const row = ticketTableBody.insertRow();
        row.insertCell(0).innerText = ticket.trainNumber;
        row.insertCell(1).innerText = ticket.departureTime;
        row.insertCell(2).innerText = ticket.arrivalTime;
        row.insertCell(3).innerText = ticket.duration;
        row.insertCell(4).innerText = ticket.businessClass;
        row.insertCell(5).innerText = ticket.firstClass;
        row.insertCell(6).innerText = ticket.secondClass;
        row.insertCell(7).innerText = ticket.other;

        const bookCell = row.insertCell(8);
        const bookButton = document.createElement('button');
        bookButton.innerText = "Book";
        bookCell.appendChild(bookButton);
    });
};

document.getElementById('searchButton')!.addEventListener('click', async () => {
    const startStation = (document.getElementById('startStation') as HTMLInputElement).value;
    const endStation = (document.getElementById('endStation') as HTMLInputElement).value;
    const date = (document.getElementById('date') as HTMLInputElement).value;

    const tickets = await fetchTickets(startStation, endStation, date);
    displayTickets(tickets);
});

document.addEventListener("DOMContentLoaded", async () => {
    const tickets = await fetchTickets("默认起点", "默认终点", "默认日期");
    displayTickets(tickets);
});
