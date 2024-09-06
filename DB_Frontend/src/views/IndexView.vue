<template>
    <div>
        <!-- 页面头部 -->
        <div class="header">
            <!-- <iframe src="../header/index_main.html" width="100%" frameborder="0"></iframe> -->
        </div>

        <!-- 轮播图以及搜索框 -->
        <div class="section-1">
            <!-- 轮播图容器 -->
            <div class="slides-container">
                <!-- 图像 -->
                <div class="slides-list">
                    <img src='@/assets/slide1.jpg' alt="slide1">
                    <img src='@/assets/slide2.jpg' alt="slide2">
                    <img src='@/assets/slide3.jpg' alt="slide3">
                </div>
                <!-- 下方按钮 -->
                <ul class="circles-list">
                    <li class="circle active" data-n="0"></li>
                    <li class="circle" data-n="1"></li>
                    <li class="circle" data-n="2"></li>
                </ul>
            </div>
            <!-- 搜索框 -->
            <div class="search-container">
                <div class="search-list">
                    <div class="search-item">
                        <label>始发站</label>
                        <div class="input-container">
                            <i class="icon ion-log-in"></i>
                            <input type="text" id="from" placeholder="选择出发站点" required>
                            <span class =err id="fromErr">始发站不能为空</span>
                        </div>
                    </div>
                    <div class="search-item">
                        <label>终点站</label>
                        <div class="input-container">
                            <i class="icon ion-log-out"></i>
                            <input type="text" id="to" placeholder="选择到达站点" required>
                            <span class =err id="toErr">终点站不能为空</span>
                        </div>
                    </div>
                    <div class="search-item">
                        <label>出发日期</label>
                        <div class="input-container">
                            <i class="icon ion-android-calendar"></i>
                            <input type="text" id="datepicker" placeholder="选择出发时间">
                        </div>
                    </div>
                    <div class="search-item">
                        <div class="check-item">
                            <label>学生</label>
                            <input type="checkbox" id="student">
                        </div>
                        <div class="check-item">
                            <label>中转</label>
                            <input type="checkbox" id="round">
                        </div>
                    </div>
                    <div class="submit-container">
                        <button id="submit">查询车票<span></span></button>
                    </div>
                </div>
            </div>
        </div>

        <!-- 下拉选择框 -->
        <div class="dropdown-container">
            <div class="city-chose">
                <ul class="header">
                    <li data-n="0" class="chose active">A~E</li>
                    <li data-n="1" class="chose">F~J</li>
                    <li data-n="2" class="chose">K~O</li>
                    <li data-n="3" class="chose">P~T</li>
                    <li data-n="4" class="chose">U~Z</li>
                </ul>
                <ul class="body" id="chose-body">
                </ul>
            </div>
            <div class="city-search">
                <ul class="body" id="search-body">
                </ul>
            </div>
        </div>

        <!-- 页面尾部 -->
        <!-- <div class="footer">
            尾部
        </div> -->
    </div>
</template>

<script>
    import axio from 'axios';
    import pinyin from 'pinyin';
    import flatpickr from "flatpickr";
    import "flatpickr/dist/l10n/zh";
    import "flatpickr/dist/flatpickr.css";

    // 管理轮播图
    class slideManager {
        // 构造函数
        constructor(container, interval = 3000) {
            var _a;
            this.container = container;
            this.interval = interval;
            this.index = 0;
            this.slides_list = container.querySelector('.slides-list');
            this.img_num = (this.slides_list.querySelectorAll('img')).length;
            this.circles = container.querySelectorAll('.circle');
            this.width = container.clientWidth;
            let first_slide_clone = (_a = this.slides_list.firstElementChild) === null || _a === void 0 ? void 0 : _a.cloneNode();
            this.slides_list.appendChild(first_slide_clone);
            this.start();
        }

        // 自动切换幻灯片
        changeSlide_auto() {
            // 更换幻灯片
            this.index = (this.index + 1) % this.img_num;
            //最后一张特殊处理
            if (this.index === 0) {
                this.slides_list.style.left = -1 * this.img_num * this.width + "px";
                setTimeout(() => {
                    this.slides_list.style.transition = 'none';
                    this.slides_list.style.left = '0px';
                }, 500);
            }
            else {
                this.slides_list.style.transition = '0.5s ease-in-out';
                this.slides_list.style.left = -1 * this.index * this.width + "px";
            }
            // 设置下方按钮
            this.setCricles();
        }

        // 手动切换幻灯片
        changeSlide_click(n) {
            this.index = n;
            this.slides_list.style.left = -1 * this.index * this.width + "px";
            this.setCricles();
        }

        // 设置圆点的高亮
        setCricles() {
            for (let i = 0; i < this.circles.length; i++) {
                if (i === this.index) {
                    this.circles[i].classList.add('active');
                }
                else {
                    this.circles[i].classList.remove('active');
                }
            }
        }

        // 开始放映
        start() {
            this.circles.forEach(circle => {
                const n = Number(circle.getAttribute('data-n'));
                circle.addEventListener('click', () => this.changeSlide_click(n));
            });
            window.setInterval(() => this.changeSlide_auto(), this.interval);
        }
    }

    // 管理搜索框
    class searchManager {
        // 构造函数
        constructor(container,router) {
            this.container = container;
            this.now_input = -1; // 当前输入框
            // 获取元素
            let search_list = container.querySelector('.search-list');
            this.input_from = search_list.querySelector('#from');
            this.input_to = search_list.querySelector('#to');
            this.input_time = search_list.querySelector('#datepicker');
            this.chk_student = search_list.querySelector('#student');
            this.chk_round = search_list.querySelector('#round');
            this.submit_btn = search_list.querySelector('#submit');
            this.err_from = search_list.querySelector('#fromErr');
            this.err_to = search_list.querySelector('#toErr');
            this.router = router;
            this.addEventListener();
        }

        // 设置输入
        setInput(city_name) {
            if (this.now_input === 0) {
                this.input_from.value = city_name;
            }
            else if (this.now_input === 1) {
                this.input_to.value = city_name;
            }
        }

        // 显示错误提示
        showErr(err) {
            if (err === 'from') {
                this.err_from.style.display = 'inline';
            }
            else if (err === 'to') {
                this.err_to.style.display = 'inline';
            }
        }

        // 隐藏错误提示
        hideErr(err) {
            if (err === 'from') {
                this.err_from.style.display = 'none';
            }
            else if (err === 'to') {
                this.err_to.style.display = 'none';
            }
        }

        // 跳转页面
        redirectToPage() {
            if (!(this.input_from.value.trim() && this.input_to.value.trim())) {
                if (!this.input_from.value.trim()) {
                    this.showErr('from');
                }
                if (!this.input_to.value.trim()) {
                    this.showErr('to');
                }
            }
            else {
                const from = this.input_from.value;
                const to = this.input_to.value;
                const time = this.input_time.value;
                const ifStudent = this.chk_student.checked;
                const ifRound = this.chk_round.checked;
                this.router.push({
                    name:'StationPage',
                    query: {
                        from: from,
                        to: to,
                        time: time,
                        ifStudent: ifStudent,
                        ifRound: ifRound
                    }
                });
            }
        }

        // 添加事件监听器
        addEventListener() {
            this.input_from.addEventListener('click', (event) => {
                if (!this.input_from.value.trim()) {
                    this.now_input = 0;
                    const input_container = this.container.querySelector('.input-container');
                    this.dropdown_manager.moveTo(input_container);
                    this.dropdown_manager.showChose();
                }
                event.stopPropagation();
            });
            this.input_from.addEventListener('input', (event) => {
                this.now_input = 0;
                const input_container = this.container.querySelector('.input-container');
                this.dropdown_manager.moveTo(input_container);
                this.dropdown_manager.hideChose();
                this.dropdown_manager.showSearch();
                this.dropdown_manager.searchCity(this.input_from.value);
                event.stopPropagation();
            });
            this.input_to.addEventListener('click', (event) => {
                if (!this.input_to.value.trim()) {
                    this.now_input = 1;
                    const input_container = this.container.querySelectorAll('.input-container')[1];
                    this.dropdown_manager.moveTo(input_container);
                    this.dropdown_manager.showChose();
                }
                event.stopPropagation();
            });
            this.input_to.addEventListener('input', (event) => {
                this.now_input = 1;
                const input_container = this.container.querySelectorAll('.input-container')[1];
                this.dropdown_manager.moveTo(input_container);
                this.dropdown_manager.hideChose();
                this.dropdown_manager.showSearch();
                this.dropdown_manager.searchCity(this.input_to.value);
                event.stopPropagation();
            });
            this.submit_btn.addEventListener('click', () => this.redirectToPage());
            document.addEventListener('click', () => {
                this.dropdown_manager.hideChose();
                this.dropdown_manager.hideSearch();
            });
        }
    }

    // 管理下拉框
    class dropdownManager {
        constructor(container) {
            this.container = container;
            this.index = 0; // 当前所选项
            this.citys = []; // 城市结点数组
            //将城市名转为拼音
            this.convertToPinYin = (city) => {
                const pinyinArray = pinyin(city, { style: pinyin.STYLE_NORMAL, heteronym: false });
                return pinyinArray.map((arr) => arr[0]).join('');
            };
            this.city_chose = container.querySelector('.city-chose');
            this.choses = this.city_chose.querySelectorAll('.chose');
            this.chose_body = this.city_chose.querySelector('#chose-body');
            this.citys = Array.from({ length: 6 }, () => []);
            this.city_search = container.querySelector('.city-search');
            this.search_body = container.querySelector('#search-body');
            this.getCitys();
            this.addEventListener();
            this.setDayPicker();
        }

        // 设置选择下拉框可见
        showChose() {
            this.city_chose.style.display = 'block';
        }

        // 设置选择下拉框不可见
        hideChose() {
            if (this.city_chose.style.display != 'none') {
                this.city_chose.style.display = 'none';
            }
        }

        // 设置搜索下拉框可见
        showSearch() {
            this.city_search.style.display = 'block';
        }

        // 设置搜索下拉框不可见
        hideSearch() {
            if (this.city_search.style.display != 'none') {
                this.city_search.style.display = 'none';
            }
        }

        // 移动下拉框的位置
        moveTo(input) {
            const rect = input.getBoundingClientRect();
            this.container.style.top = `${rect.bottom + window.scrollY}px`; // 距离上方的距离
            this.container.style.left = `${rect.left + window.scrollX}px`; // 距离左方的距离
        }

        // 设置当前所选项的高亮
        setChoses() {
            for (let i = 0; i < this.choses.length; i++) {
                if (i === this.index) {
                    this.choses[i].classList.add('active');
                }
                else {
                    this.choses[i].classList.remove('active');
                }
            }
        }

        // 更改当前所选项
        changeChose(n) {
            this.index = n;
            this.setChoses();
            this.setCitys_chose();
            this.showChose();
        }

        // 获取城市列表
        getCitys() {
            axio.get('http://localhost:5000/api/stations')
                .then((response) => {
                // 获取所有城市
                const cities = response.data;
                // 将城市名转为拼音
                const citiesWithPinyin = cities.map(city => ({ name: city, pinyin: this.convertToPinYin(city) }));
                // 按拼音排序
                citiesWithPinyin.sort((a, b) => a.pinyin.localeCompare(b.pinyin));
                // 分组
                citiesWithPinyin.forEach(({ name, pinyin }) => {
                    const city = document.createElement('li');
                    city.textContent = name;
                    city.classList.add('city');
                    city.addEventListener('click', () => {
                        this.search_manager.setInput(city.textContent);
                        this.hideChose();
                    });
                    const firstLetter = pinyin[0].toUpperCase();
                    if ('A' <= firstLetter && firstLetter <= 'E') {
                        this.citys[0].push(city);
                    }
                    else if ('F' <= firstLetter && firstLetter <= 'J') {
                        this.citys[1].push(city);
                    }
                    else if ('K' <= firstLetter && firstLetter <= 'O') {
                        this.citys[2].push(city);
                    }
                    else if ('P' <= firstLetter && firstLetter <= 'T') {
                        this.citys[3].push(city);
                    }
                    else if ('U' <= firstLetter && firstLetter <= 'Z') {
                        this.citys[4].push(city);
                    }
                });
                this.setCitys_chose();
            })
                .catch((error) => {
                console.error('Error:', error);
            });
        }

        // 设置城市列表
        setCitys_chose() {
            this.chose_body.innerHTML = "";
            this.citys[this.index].forEach(city => {
                this.chose_body.appendChild(city);
            });
        }

        // 搜索城市
        searchCity(search) {
            axio.post('http://localhost:5000/api/stations', { query: search })
                .then(response => {
                this.search_body.innerHTML = '';
                if (response.data) {
                    const cities = response.data;
                    this.setCitys_search(cities);
                }
                else {
                    console.log('empty');
                }
            })
                .catch(error => {
                console.error('Error:', error);
            });
        }

        // 设置城市列表
        setCitys_search(cities) {
            cities.forEach(city => {
                const li = document.createElement('li');
                li.textContent = city;
                li.addEventListener('click', () => {
                    this.search_manager.setInput(li.textContent);
                    this.hideSearch();
                });
                this.search_body.appendChild(li);
            });
        }

        // 设置日历
        setDayPicker() {
            const today = new Date(); // 今天日期
            const nextMonth = new Date(today); // 下个月日期
            nextMonth.setMonth(today.getMonth() + 1);
            flatpickr("#datepicker", {
                enableTime: false, // 仅显示日期，不显示时间
                dateFormat: "Y-m-d", // 设置日期格式
                defaultDate: today, // 默认日期为今天
                minDate: today, // 最小选择日期
                maxDate: nextMonth, // 最大选择日期
                locale: "zh" // 设置中文
            });
        }

        // 添加事件监听器
        addEventListener() {
            this.container.addEventListener('click', (event) => event.stopPropagation());
            this.choses.forEach(chose => {
                const n = Number(chose.getAttribute('data-n'));
                chose.addEventListener('click', () => this.changeChose(n));
            });
        }
    }

    export default {
        methods:{
            init() {
                const slide_container = document.querySelector('.slides-container');
                if (slide_container) {
                    new slideManager(slide_container);
                }
                const search_container = document.querySelector('.search-container');
                if (search_container) {
                    const dropdown_container = document.querySelector('.dropdown-container');
                    if (dropdown_container) {
                        const dropdown_manager = new dropdownManager(dropdown_container);
                        const search_manager = new searchManager(search_container,this.$router);
                        dropdown_manager.search_manager = search_manager;
                        search_manager.dropdown_manager = dropdown_manager;
                    }
                }
            },
            test() {
                console.log('test');
                axio.post('http://localhost:5000/tickets/search',{
                    DepartureStation:'北京北',
                    ArrivalStation:'南京'
                })
                .then(response=>{
                    console.log(response.data);
                })
                .catch(error => {
                    console.error('Error:', error);
                });
            }
        },
        mounted(){
            this.init();
            console.log('init');
            this.test();
        }
    }
</script>

<style>
@import url("https://cdn.staticfile.net/ionicons/2.0.1/css/ionicons.min.css");

ul {
    list-style: none;
}
.section-1 {
    position:relative;
    height:600px;
    width:100%;
    background-color:#FFFFFF
}
.dropdown-container {
    position:relative;
    background-color:#FFFFFF
}
.footer {
    height:80px;
    width:100%;
    background-color:#B0B0B0
}

/* ---------------------------轮播图背景--------------------------- */
.section-1 .slides-container {
    overflow: hidden;
    position: absolute;
    width: 100%;
    height: 100%;
}
.section-1 .slides-container .slides-list {
    display: flex;
    position: relative;
    left: 0px;
    width: 100%;
    height: 100%;
    transition: 0.5s ease-in-out;
}
.section-1 .slides-container .slides-list img {
    min-width: 100%;
    cursor: pointer;
}
.section-1 .slides-container .circles-list {
    display: flex;
    position: absolute;
    bottom: 20px;
    left: 50%;
    transform: translate(-50%,0);
    width: 120px;
    height: 20px;
}
.section-1 .slides-container .circles-list .circle {
    margin: 0 5px;
    width: 20px;
    height: 20px;
    background-color: #ECF0F1;
    border-radius: 50%;
} 
.section-1 .slides-container .circles-list .circle.active {
    background-color: #B0B0B0;
}

/* ---------------------------搜索框--------------------------- */
.section-1 .search-container {
    position: absolute;
    top: 100px;
    left: 100px;
    width: 400px;
    height: 350px;
    background-color: #FFFFFF ;
}
.section-1 .search-container .search-list {
    display: flex;
    flex-direction: column;
    gap: 10px;
    position: relative;
    top: 0px;
    left: 0px;
    width: 100%;
    height: 100%;
    background-color:#d8e4e88b;
}
.section-1 .search-container .search-list .search-item {
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;
    top: 10px;
    left: 0px;
    width: 100%;
    height: 18%;
    background-color: #d8e4e88b ;
    box-shadow: 0 0 5px rgba(70, 70, 40, .255);
}
.section-1 .search-container .search-list .search-item label {
    margin-right: 10px;
    width: 20%;
    text-align: right;
}
.section-1 .search-container .search-list .search-item .input-container {
    height: 40%;
    width: 55%;
    background-color:#FFFFFF;
    border:1px solid rgb(74, 73, 73);
    outline: 0;
    font-size: 16px;
    opacity: 0.8;
    position: relative;
    display: flex;
    align-items: center;
}
.section-1 .search-container .search-list .search-item .input-container i{
    position: relative;
    left: 5px;
    width: 25px;
    height:auto;
}
.section-1 .search-container .search-list .search-item .input-container input {
    border: none;
    outline: none;
}
.section-1 .search-container .search-list .search-item .input-container .err {
    position: absolute;
    right: -120px;
    top: -3px;
    padding: 5px 10px;
    background-color: red;
    color: white;
    font-size: 0.875em;
    border-radius: 4px;
    display: none;
}
.section-1 .search-container .search-list .search-item .check-item {
    width:50%;
    display: flex;
    align-items: center;
    justify-content: center;
}
.section-1 .search-container .search-list .search-item .check-item input[type='checkbox'] { 
    height: 20px;
    width: 20px;
}
.section-1 .search-container .submit-container {
    width: 100%;
    height: 18%;
    margin-top: 15px;
    margin: 10px auto;
    background-color: transparent;
    position: relative;
}
.section-1 .search-container .submit-container button {
    display: inline-block;
    height: 35px;
    width: 100px;
    border-radius: 12px;
    background-color: #dbe1b18b;
    position: absolute;
    top:50%;
    left:50%;
    transform: translate(-50%,-50%);
    border: none;
    outline: none;
    cursor: pointer;
    box-shadow: 0 10px 10px rgba(0, 0, 0,.3);
}

/* ---------------------------下拉框--------------------------- */
.dropdown-container {
    position: absolute;
}
.dropdown-container .city-chose {
    display: none;
    position:absolute;
    width:400px;
    height: 300px;
    border: none;
    background-color: white;
}
.dropdown-container .city-chose .header {
    width: 100%;
    height: 10%;
    background-color:#a3c8eb;
    display: grid;
    grid-template-columns: repeat(5, 1fr);
    gap: 7px;
    padding: 0;
    margin: 0;
    color: #655c5c;
}
.dropdown-container .city-chose .header .chose {
    padding: 5px 10px;
    background-color:transparent;
    border: none;
    cursor: pointer;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 13px;
}
.dropdown-container .city-chose .header .chose.active {
    font-weight:bold;
}
.dropdown-container .city-chose .header .chose:hover {
    color:rgb(232, 66, 6);
}
.dropdown-container .city-chose .body {
    width: 100%;
    height: 90%;
    display: grid;
    grid-template-columns: repeat(5, 1fr);
    grid-auto-rows: 30px;
    gap: 7px;
    padding: 0px;
    margin: 0px;
    color: #655c5c;
}
.dropdown-container .city-chose .body .city {
    padding: 5px 10px;
    background-color:transparent;
    border: none;
    cursor: pointer;
    text-align: center;
    font-size: 13px;
}
.dropdown-container .city-chose .body .city.active {
    font-weight:bold;
}
.dropdown-container .city-chose .body .city:hover {
    color:rgb(232, 66, 6);
}
.dropdown-container .city-search {
    display: none;
    position:absolute;
    width:220px;
    height: 270px;
    flex-direction: column;
    border: 1px solid rgb(163, 152, 152);
    background-color: white;
}
.dropdown-container .city-search .body {
    padding: 0;
    margin: 0;
    max-height:270px;
    overflow-y: auto;
    background-color: white;
}
.dropdown-container .city-search .body li{
    height:40px;
    margin: 5px;
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: #d8e4e88b;
}
.dropdown-container .city-search .body li:hover{
    background-color:rgb(126, 205, 242);
}
</style>