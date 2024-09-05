"use strict";
// 管理轮播图
class slideManager {
    // 构造函数
    constructor(container, interval = 3000) {
        var _a;
        this.container = container;
        this.interval = interval;
        this.index = 0; // 当前幻灯片
        // container：包含轮播图片以及点击按钮的div
        // interval：自动转换时间间隔
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
    constructor(container) {
        this.container = container;
        this.now_input = -1; // 当前输入框
        // 获取元素
        let search_list = container.querySelector('.search-list');
        this.input_from = search_list.querySelector('#from');
        this.input_to = search_list.querySelector('#to');
        this.input_time = search_list.querySelector('#time');
        this.chk_student = search_list.querySelector('#student');
        this.chk_round = search_list.querySelector('#round');
        this.submit_btn = search_list.querySelector('#submit');
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
    // 跳转页面
    redirectToPage() {
        const from = '上海';
        const to = '北京';
        const url = `../tickets_show/tickets_list.html?from=from&to=to`;
        window.location.href = url;
    }
    // 添加事件监听器
    addEventListener() {
        this.input_from.addEventListener('click', (event) => {
            this.now_input = 0;
            this.dropdown_manager.showChose();
            const input_container = this.container.querySelector('.input-container');
            this.dropdown_manager.moveTo(input_container);
            event.stopPropagation();
        });
        this.input_to.addEventListener('click', (event) => {
            this.now_input = 1;
            this.dropdown_manager.showChose();
            const input_container = this.container.querySelectorAll('.input-container')[1];
            this.dropdown_manager.moveTo(input_container);
            event.stopPropagation();
        });
        this.submit_btn.addEventListener('click', () => this.redirectToPage());
        document.addEventListener('click', () => {
            this.dropdown_manager.hideChose();
        });
    }
}
// 管理下拉框
class dropdownManager {
    constructor(container) {
        this.container = container;
        this.index = 0; // 当前所选项
        this.citys = []; // 城市结点数组
        this.city_names = []; // 城市名字数组
        this.city_chose = container.querySelector('.city-chose');
        this.choses = this.city_chose.querySelectorAll('.chose');
        this.city_body = this.city_chose.querySelector('.body');
        this.city_search = container.querySelector('.city-search');
        this.getCitys();
        this.addEventListener();
        this.setCitys();
    }
    // 设置下拉框可见
    showChose() {
        this.city_chose.style.display = 'block';
    }
    // 设置下拉框不可见
    hideChose() {
        if (this.city_chose.style.display != 'none') {
            this.city_chose.style.display = 'none';
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
        this.setCitys();
        this.showChose();
    }
    // 获取城市列表
    getCitys() {
        this.city_names = [['北京', '上海'], ['昂昂溪', '北京北'], ['风水村', '福州'], ['昆明'], ['坡底下'], ['武汉']];
        let num = 0;
        this.city_names.forEach(subarry => {
            let temp = [];
            subarry.forEach(city_name => {
                const city = document.createElement('li');
                city.textContent = city_name;
                city.classList.add('city');
                temp.push(city);
            });
            this.citys.push(temp);
        });
    }
    // 设置城市列表
    setCitys() {
        this.city_body.innerHTML = "";
        this.citys[this.index].forEach(city => {
            this.city_body.appendChild(city);
        });
    }
    // 添加事件监听器
    addEventListener() {
        this.container.addEventListener('click', (event) => event.stopPropagation());
        this.choses.forEach(chose => {
            const n = Number(chose.getAttribute('data-n'));
            chose.addEventListener('click', () => this.changeChose(n));
        });
        this.citys.forEach(subarry => {
            subarry.forEach(city => {
                city.addEventListener('click', () => {
                    this.search_manager.setInput(city.textContent);
                    this.hideChose();
                });
            });
        });
    }
}
function init() {
    const slide_container = document.querySelector('.slides-container');
    if (slide_container) {
        new slideManager(slide_container);
    }
    const search_container = document.querySelector('.search-container');
    if (search_container) {
        const dropdown_container = document.querySelector('.dropdown-container');
        if (dropdown_container) {
            const dropdown_manager = new dropdownManager(dropdown_container);
            const search_manager = new searchManager(search_container);
            dropdown_manager.search_manager = search_manager;
            search_manager.dropdown_manager = dropdown_manager;
        }
    }
}
document.addEventListener('DOMContentLoaded', init);
