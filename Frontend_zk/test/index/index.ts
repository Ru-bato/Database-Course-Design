// 管理轮播图
class slideManager {
    private slides_list: HTMLElement;       // 幻灯片列表
    private img_num: number;                // 图片数量
    private index: number = 0;              // 当前幻灯片
    private circles: NodeListOf<Element>;   // 下方按钮列表
    private width: number;                  // 容器宽度

    // 构造函数
    constructor(private container: HTMLElement,private interval: number =3000){
        // container：包含轮播图片以及点击按钮的div
        // interval：自动转换时间间隔
        this.slides_list = container.querySelector('.slides-list') as HTMLElement;
        this.img_num = (this.slides_list.querySelectorAll('img')).length;
        this.circles =container.querySelectorAll('.circle');
        this.width = container.clientWidth;
        let first_slide_clone: Node = this.slides_list.firstElementChild?.cloneNode() as Node;
        this.slides_list.appendChild(first_slide_clone);

        this.start();
    }

    // 自动切换幻灯片
    private changeSlide_auto(): void {
        // 更换幻灯片
        this.index = (this.index + 1) % this.img_num;

        //最后一张特殊处理
        if(this.index === 0){
            this.slides_list.style.left = -1 * this.img_num * this.width + "px";
            setTimeout(()=>{
                this.slides_list.style.transition = 'none';
                this.slides_list.style.left = '0px';
            },500);
        }
        else {
            this.slides_list.style.transition = '0.5s ease-in-out';
            this.slides_list.style.left = -1 * this.index * this.width + "px";
        }

        // 设置下方按钮
        this.setCricles();
    }

    // 手动切换幻灯片
    private changeSlide_click(n: number) {
        this.index = n;
        this.slides_list.style.left = -1 * this.index * this.width + "px";

        this.setCricles();
    }

    // 设置圆点的高亮
    private setCricles():void {
        for(let i=0;i<this.circles.length;i++){
            if(i===this.index) {
                this.circles[i].classList.add('active');
            }
            else{
                this.circles[i].classList.remove('active');
            }
        }
    }

    // 开始放映
    public start(): void {
        this.circles.forEach(circle => {
            const n = Number(circle.getAttribute('data-n'));
            circle.addEventListener('click',()=>this.changeSlide_click(n));
        })
        window.setInterval(() => this.changeSlide_auto(),this.interval);
    }
}

// 管理搜索框
class searchManager {
    public dropdown_manager!:dropdownManager;   // 下拉框管理器
    private input_from:HTMLInputElement;        // 始发站输入框
    private input_to:HTMLInputElement;          // 终点站输入框
    private input_time:HTMLInputElement;        // 时间输入框
    private now_input:number=-1;                // 当前输入框
    private chk_student:HTMLInputElement;       // 学生复选框
    private chk_round:HTMLInputElement;         // 往返复选框
    private submit_btn:HTMLButtonElement;       // 提交按钮

    // 构造函数
    constructor(private container:HTMLElement){
        // 获取元素
        let search_list:HTMLElement = container.querySelector('.search-list') as HTMLElement;
        this.input_from = search_list.querySelector('#from') as HTMLInputElement;
        this.input_to = search_list.querySelector('#to') as HTMLInputElement;
        this.input_time = search_list.querySelector('#time') as HTMLInputElement;
        this.chk_student = search_list.querySelector('#student') as HTMLInputElement;
        this.chk_round = search_list.querySelector('#round') as HTMLInputElement;
        this.submit_btn = search_list.querySelector('#submit') as HTMLButtonElement;

        this.addEventListener();
    }

    // 设置输入
    public setInput(city_name:string){
        if(this.now_input===0){
            this.input_from.value=city_name;
        }
        else if(this.now_input===1){
            this.input_to.value=city_name;
        }
    }

    // 跳转页面
    private redirectToPage(){
        const from:string = '上海';
        const to:string='北京';
        const url:string = '../tickets_show/tickets_list.html?from=from&to=to';
        window.location.href = url;
    }

    // 添加事件监听器
    private addEventListener(){
        this.input_from.addEventListener('click',(event)=>{
            this.now_input = 0;
            this.dropdown_manager.showChose();
            const input_container:HTMLElement = this.container.querySelector('.input-container') as HTMLElement;
            this.dropdown_manager.moveTo(input_container);
            event.stopPropagation();
        });

        this.input_to.addEventListener('click',(event)=>{
            this.now_input = 1;
            this.dropdown_manager.showChose();
            const input_container:HTMLElement = this.container.querySelectorAll('.input-container')[1] as HTMLElement;
            this.dropdown_manager.moveTo(input_container);
            event.stopPropagation();
        });

        this.submit_btn.addEventListener('click',()=>this.redirectToPage());

        document.addEventListener('click', () =>{
            this.dropdown_manager.hideChose();
        });
    }
}

// 管理下拉框
class dropdownManager {
    public search_manager!: searchManager; // 搜索框管理
    private city_chose: HTMLElement;        // 城市选择
    private choses:NodeListOf<Element>;     // 选择列表
    private index:number =0;                // 当前所选项
    private city_body:HTMLUListElement;     // 城市容器
    private citys:HTMLLIElement[][]=[];     // 城市结点数组
    private city_names:string[][]=[];       // 城市名字数组
    private city_search: HTMLElement;       // 城市搜索


    constructor(private container:HTMLElement){
        this.city_chose = container.querySelector('.city-chose') as HTMLElement;
        this.choses = this.city_chose.querySelectorAll('.chose');
        this.city_body = this.city_chose.querySelector('.body') as HTMLUListElement;
        this.city_search = container.querySelector('.city-search') as HTMLElement;

        this.getCitys();
        this.addEventListener();
        this.setCitys();
    }

    // 设置下拉框可见
    public showChose() {
        this.city_chose.style.display = 'block';
    }

    // 设置下拉框不可见
    public hideChose() {
        if(this.city_chose.style.display!='none'){
            this.city_chose.style.display = 'none';
        }
    }

    // 移动下拉框的位置
    public moveTo(input:HTMLElement) {
        const rect = input.getBoundingClientRect();

        this.container.style.top =  `${rect.bottom + window.scrollY}px`; // 距离上方的距离
        this.container.style.left = `${rect.left + window.scrollX}px`; // 距离左方的距离
    }

    // 设置当前所选项的高亮
    private setChoses(){
        for(let i=0;i<this.choses.length;i++){
            if(i===this.index){
                this.choses[i].classList.add('active');
            }
            else{
                this.choses[i].classList.remove('active');
            }
        }
    }

    // 更改当前所选项
    private changeChose(n:number){
        this.index=n;
        this.setChoses();
        this.setCitys();
        this.showChose();
    }

    // 获取城市列表
    private getCitys(){
        this.city_names=[['北京','上海'],['昂昂溪','北京北'],['风水村','福州'],['昆明'],['坡底下'],['武汉']];
        let num = 0;
        this.city_names.forEach(subarry=>{
            let temp:HTMLLIElement[]=[]; 
            subarry.forEach(city_name =>{
                const city = document.createElement('li');
                city.textContent = city_name;
                city.classList.add('city');
                temp.push(city);
            });
            this.citys.push(temp);
        });
    }

    // 设置城市列表
    private setCitys(){
        this.city_body.innerHTML="";
        this.citys[this.index].forEach(city => {
            this.city_body.appendChild(city);
        });
    }

    // 添加事件监听器
    private addEventListener(){
        this.container.addEventListener('click',(event) =>event.stopPropagation());

        this.choses.forEach(chose => {
            const n = Number(chose.getAttribute('data-n'));
            chose.addEventListener('click',()=>this.changeChose(n));
        })

        this.citys.forEach(subarry=>{
            subarry.forEach(city=>{
                city.addEventListener('click',()=>{
                    this.search_manager.setInput(city.textContent as string);
                    this.hideChose();
                });
            });
        });
    }
}

function init(): void {
    const slide_container = document.querySelector('.slides-container') as HTMLElement;
    if (slide_container) {
        new slideManager(slide_container);
    }

    const search_container = document.querySelector('.search-container') as HTMLElement;
    if(search_container) {
        const dropdown_container = document.querySelector('.dropdown-container') as HTMLElement;
        if(dropdown_container){
            const dropdown_manager = new dropdownManager(dropdown_container);
            const search_manager = new searchManager(search_container);
            dropdown_manager.search_manager = search_manager;
            search_manager.dropdown_manager = dropdown_manager;
        }
        
    }
}

document.addEventListener('DOMContentLoaded', init);