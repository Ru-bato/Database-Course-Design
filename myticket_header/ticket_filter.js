document.getElementById('filter-btn').addEventListener('click', function() {
    const startDate = document.getElementById('start-date').value;
    const endDate = document.getElementById('end-date').value;
    const isStudent = document.getElementById('is-student').value;
    
    const tickets = document.querySelectorAll('.ticket-item');
    
    tickets.forEach(ticket => {
        const ticketDate = ticket.getAttribute('data-date');
        const ticketStudent = ticket.getAttribute('data-student');
        
        const dateMatch = (!startDate || !endDate) || (ticketDate >= startDate && ticketDate <= endDate);
        const studentMatch = isStudent === 'all' || ticketStudent === isStudent;
        
        if (dateMatch && studentMatch) {
            ticket.style.display = 'block';
        } else {
            ticket.style.display = 'none';
        }
    });
});
