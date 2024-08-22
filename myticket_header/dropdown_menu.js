document.querySelectorAll('.nav-item, .menu-nav-hd').forEach(function (item) {
    var link = item.querySelector('.nav-hd, .menu-nav-hd');
    var dropdown = item.querySelector('.nav-dropdown, .menu-dropdown');

    link.addEventListener('click', function (e) {
        e.preventDefault();
        dropdown.style.display = dropdown.style.display === 'block' ? 'none' : 'block';
    });
});
