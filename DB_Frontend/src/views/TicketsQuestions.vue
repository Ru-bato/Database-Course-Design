<template>
    <!-- 整个页面 -->
    <div id="layout">
        <!-- 包括上方搜索栏和导航页 -->
        <div class="header" role="=banner">
            <!-- ::before -->
            <!-- 填充两侧，保证内容在中间 -->
            <div class="wrapper">
                <!-- 左侧logo部分 -->
                <div class="header-con">
                    <h1 class="logo" role="banner">
                        <!-- 链接跳转主页 -->
                        <a href="#">
                            <img src="@/img/logo.png" alt="logo" style="height:50px">
                        </a>
                    </h1>
                    <!-- logo的右侧部分，包括搜索条和右侧菜单 -->
                    <div class="header-right">
                        <!-- 搜索条，包括搜索栏和搜索按钮-->
                        <div class="header-search">
                            <div class="search-bd">
                                <input type="text" class="search-input" id="search-input" v-model="searchQuery"
                                    placeholder="搜索车票/餐饮/常旅客/相关章程">

                                <div v-if="searchQuery && suggestions.length > 1" class="suggestions">
                                    <div v-for="suggestion in suggestions" :key="suggestion"
                                        @click="selectSuggestion(suggestion)">
                                        {{ suggestion }}
                                    </div>
                                </div>
                            </div>
                            <button class="search-btn" @click="showAnswer"><img class="icon-search"
                                    src="@/img/search.png" alt="search"></button>
                        </div>
                        <!-- 右侧菜单 -->
                        <ul class="header-menu">
                            <li class="menu-line">|</li>
                            <li class="menu-item menu-nav">
                                <a href="#" class="menu-nav-hd" aria-expanded="true">
                                    <div class="dropdown-arrow">
                                    </div>我的星济铁路
                                </a>

                                <ul class="menu-dropdown">
                                    <li><a class="menu-dropdown-item" href="#">子菜单项 1</a></li>
                                    <li><a class="menu-dropdown-item" href="#">子菜单项 2</a></li>
                                    <li><a class="menu-dropdown-item" href="#">子菜单项 3</a></li>
                                </ul>
                            </li>
                            <li class="menu-line">|</li>
                            <li id="header-login" class="menu-item menu-log">
                                <a href="#" class="menu-nav-hd">登录</a>
                                <a href="#" class="menu-nav-hd">注册</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="nav-box">
                <ul class="nav">
                    <li id="shouye" class="nav-item"><a class="nav-hd" href="#">首页<div class="dropdown-arrow"></div>
                            <!-- 下拉箭头 --></a>
                        <ul class="nav-dropdown">
                            <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
                        </ul>
                    </li>
                    <li id="chepiao" class="nav-item"><a class="nav-hd" href="#">车票<div class="dropdown-arrow"></div>
                        </a>
                        <ul class="nav-dropdown">
                            <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
                        </ul>
                    </li>
                    <li id="tuangoufuwu" class="nav-item"><a class="nav-hd" href="#">团购服务<div class="dropdown-arrow">
                            </div></a>
                        <ul class="nav-dropdown">
                            <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
                        </ul>
                    </li>
                    <li id="zhanchefuwu" class="nav-item"><a class="nav-hd" href="#">站车服务<div class="dropdown-arrow">
                            </div></a>
                        <ul class="nav-dropdown">
                            <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
                        </ul>
                    </li>
                    <li id="shanglvfuwu" class="nav-item"><a class="nav-hd" href="#">商旅服务<div class="dropdown-arrow">
                            </div></a>
                        <ul class="nav-dropdown">
                            <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
                        </ul>
                    </li>
                    <li id="chuxingzhinan" class="nav-item"><a class="nav-hd" href="#">出行指南<div class="dropdown-arrow">
                            </div></a>
                        <ul class="nav-dropdown">
                            <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
                        </ul>
                    </li>
                    <li id="xinxichaxun" class="nav-item"><a class="nav-hd" href="#">信息查询<div class="dropdown-arrow">
                            </div></a>
                        <ul class="nav-dropdown">
                            <li><a class="nav-dropdown-item" href="#">子菜单项 1</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 2</a></li>
                            <li><a class="nav-dropdown-item" href="#">子菜单项 3</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
        <!-- 页面内容 -->
        <div id="container">
            <div id="menu">
                <h2>常见问题</h2>
                <!-- 1.车票 -->
                <div class="menu-header" @click="toggleMenu('ticket-menu', 'ticket-info', 'subtitle-1')">车票</div>
                <div id="ticket-menu" class="sub-menu">
                    <ul>
                        <li><span class="subtitle-1 active"
                                @click="changeSubtitleInfo($event, 'subtitle-1', 'ticket-info'); toggleSubtitle($event, 'subtitle-1');">车票种类</span>
                        </li>
                        <li><span class="subtitle-1"
                                @click="changeSubtitleInfo($event, 'subtitle-1', 'real-name-info'); toggleSubtitle($event, 'subtitle-1');">实名制车票</span>
                        </li>
                        <li><span class="subtitle-1"
                                @click="changeSubtitleInfo($event, 'subtitle-1', 'expense-claim-info'); toggleSubtitle($event, 'subtitle-1');">报销凭证</span>
                        </li>
                    </ul>
                </div>
                <!-- 2.购票 -->
                <div class="menu-header" @click="toggleMenu('purchase-menu', 'purchase-process-info', 'subtitle-2')">购票
                </div>
                <div id="purchase-menu" class="sub-menu">
                    <ul>
                        <li><span class="subtitle-2 "
                                @click="changeSubtitleInfo($event, 'subtitle-2', 'purchase-process-info'); toggleSubtitle($event, 'subtitle-2')">购票流程</span>
                        </li>
                        <li><span class="subtitle-2 "
                                @click="changeSubtitleInfo($event, 'subtitle-2', 'concession-ticket-info'); toggleSubtitle($event, 'subtitle-2')">优惠票</span>
                        </li>
                    </ul>
                </div>
                <div class="menu-header" @click="toggleMenu('other-menu')">其他问题</div>
                <div id="other-menu" class="sub-menu">
                    <ul>
                        <li><a href="#">退票</a></li>
                        <li><a href="#">改签</a></li>
                    </ul>
                </div>
            </div>
            <!-- 右侧解答 -->
            <div id="content">
                <h2>问题解答</h2>

                <!-- 车票种类信息 -->
                <div id="ticket-info">
                    <!-- <div class="question" @click="toggleAnswer(1, 'answer1')">1.什么是连城车票？</div>
                    <div id="answer1-1" class="answer">联程车票是指旅客出发地到达目的地的旅程中，包含多个乘车段的车票...</div>

                    <div class="question" @click="toggleAnswer(2, 'answer1')">2. 去哪里可以购买车票？</div>
                    <div id="answer1-2" class="answer">车票可以通过官方购票网站、手机应用程序或线下售票点购买...</div>

                    <div class="question" @click="toggleAnswer(3, 'answer1')">3. 如何购买优惠（惠）车票？</div>
                    <div id="answer1-3" class="answer">优惠车票通常在特定时间段提供，旅客可以通过官网或第三方平台查看...</div>

                    <div class="question" @click="toggleAnswer(4, 'answer1')">4. 车票有效期是如何规定的？</div>
                    <div id="answer1-4" class="answer">车票的有效期由发票的日期和规定的有效时间决定，通常是...</div>

                    <div class="question" @click="toggleAnswer(5, 'answer1')">5. 为什么有“硬卧代硬座”、“软卧代软座”、“卧代二等座”车票？</div>
                    <div id="answer1-5" class="answer">不同类型的车票是为了满足不同旅客的需求，提供多样化的选择...</div>

                    <div class="question" @click="toggleAnswer(6, 'answer1')">6. 什么是中铁银通卡？</div>
                    <div id="answer1-6" class="answer">中铁银通卡是中国国家铁路集团有限公司推出的一种便捷购票卡...</div>

                    <div class="question" @click="toggleAnswer(7, 'answer1')">7. 什么是广深铁路牡丹信用卡？</div>
                    <div id="answer1-7" class="answer">广深铁路牡丹信用卡是广深铁路公司推出的一种专用信用卡，享受多项优惠...</div> -->
                    <!-- 遍历 textArray 中的每个问题 -->

                    <div v-for="(item, index) in getCombinedArray(1)" :key="index" class="question-answer">
                        <div class="question" @click="toggleAnswer(index + 1, `answer1`)">
                            {{ index + 1 }}. {{ item.question }}
                        </div>
                        <div :id="`answer1-${index + 1}`" class="answer">
                            {{ item.answer }}
                        </div>
                    </div>

                </div>

                <!-- 实名制车票信息 -->
                <div id="real-name-info" style="display: none;">
                    <!-- <div class="question" @click="toggleAnswer(1, 'answer2')">什么是实名制车票？</div>
                    <div id="answer2-1" class="answer">1.实名制车票是指车票上注明了旅客的真实姓名、身份证号码、联系方式等信息，旅客在购票时需提供真实有效的身份证件。</div> -->
                    <div v-for="(item, index) in getCombinedArray(2)" :key="index" class="question-answer">
                        <div class="question" @click="toggleAnswer(index + 1, `answer2`)">
                            {{ index + 1 }}. {{ item.question }}
                        </div>
                        <div :id="`answer2-${index + 1}`" class="answer">
                            {{ item.answer }}
                        </div>
                    </div>
                </div>
                <!-- 报销凭证信息 -->
                <div id="expense-claim-info" style="display: none;">
                    <!-- <div class="question" @click="toggleAnswer(1, 'answer3')">什么是报销凭证？</div>
                    <div id="answer3-1" class="answer">1.报销凭证是指旅客购买车票后，需提供旅行社开具的报销凭证，凭此证明购买车票的合法性。</div> -->
                    <div v-for="(item, index) in getCombinedArray(3)" :key="index" class="question-answer">
                        <div class="question" @click="toggleAnswer(index + 1, `answer3`)">
                            {{ index + 1 }}. {{ item.question }}
                        </div>
                        <div :id="`answer3-${index + 1}`" class="answer">
                            {{ item.answer }}
                        </div>
                    </div>
                </div>

                <!-- 购票流程信息 -->
                <div id="purchase-process-info" style="display: none;">
                    <!-- <div class="question" @click="toggleAnswer(1, 'answer4')">1. 购票前准备工作有哪些？</div>
                    <div id="answer4-1" class="answer">1. 购票前，请确保车票已到账，并妥善保管好您的车票。2. 请确保车票上注明了您的真实姓名、身份证号码、联系方式等信息。3.
                        请确保车票未被盗抢或损坏。4. 请确保车票未过期。</div> -->
                    <div v-for="(item, index) in getCombinedArray(4)" :key="index" class="question-answer">
                        <div class="question" @click="toggleAnswer(index + 1, `answer4`)">
                            {{ index + 1 }}. {{ item.question }}
                        </div>
                        <div :id="`answer4-${index + 1}`" class="answer">
                            {{ item.answer }}
                        </div>
                    </div>
                </div>

                <!-- 优惠票信息 -->
                <div id="concession-ticket-info" style="display: none;">
                    <div v-for="(item, index) in getCombinedArray(5)" :key="index" class="question-answer">
                        <div class="question" @click="toggleAnswer(index + 1, `answer5`)">
                            {{ index + 1 }}. {{ item.question }}
                        </div>
                        <div :id="`answer5-${index + 1}`" class="answer">
                            {{ item.answer }}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- 弹窗组件 -->
    <el-dialog v-model="dialogVisible" title="搜索结果">
        <p><strong>问题:</strong> {{ searchQuery }}</p>
        <p><strong>答案:</strong> {{ answer }}</p>
    </el-dialog>
</template>

<script>
import axios from 'axios';

export default {
    name: 'RealTimeSearch',
    data() {
        return {
            oldIdName: "", // 如 ticket-info
            oldSubtitleName: "",// 如 subtitle-1
            textArray: [],  // 存储 QuestionText 的二维数组
            answerArray: [], // 存储 QuestionAnswer 的二维数组
            searchQuery: '',
            suggestions: [],
            questions: [],
            answers: [],
            dialogVisible: false,
            answer: '',
        };
    },
    watch: {
        searchQuery(newQuery) {
            if (newQuery) {
                this.fetchSuggestions(newQuery);
            } else {
                this.suggestions = [];
                this.questions = [];
                this.answers = [];
            }
        }
    },
    methods: {
        showAnswer() {
            // 这里可以根据 searchQuery 从 questions 和 answers 数组中获取对应的答案
            const questionIndex = this.questions.indexOf(this.searchQuery);
            if (questionIndex !== -1) {
                this.answer = this.answers[questionIndex];
            } else {
                this.answer = '未找到答案';
            }
            this.dialogVisible = true;
        },
        async fetchSuggestions(query) {
            try {
                const request = { QuestionSearch: query };
                const response = await axios.post('http://localhost:5000/Question', request, {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });
                this.suggestions = response.data.questions;
                this.questions = response.data.questions;
                this.answers = response.data.answers;
            } catch (error) {
                console.error('Error fetching suggestions:', error);
            }
        },
        selectSuggestion(suggestion) {
            this.searchQuery = suggestion;
            this.suggestions = []; // 选择后清空联想词
        },


        toggleAnswer(index, name) {
            const answer = document.getElementById(`${name}-` + index);
            answer.style.display = (answer.style.display === "block") ? "none" : "block";
        },
        toggleMenu(menuId, defaultIdName, defaultSubtitleName) {
            const menu = document.getElementById(menuId);
            menu.style.display = (menu.style.display === "block") ? "none" : "block";
            if (this.oldIdName === "" && this.oldSubtitleName === "") {
                this.oldIdName = defaultIdName;
                this.oldSubtitleName = defaultSubtitleName;
            }

        },
        toggleSubtitle(event, name) {
            const subtitle = event.target;
            const currentSubtitle = document.querySelector(`.${name}.active`);
            if (currentSubtitle) {
                currentSubtitle.classList.remove('active');
            }
            subtitle.classList.toggle('active');
        },
        changeSubtitleInfo(event, name, idName) {
            const subtitle = event.target;
            const currentSubtitle = document.querySelector(`.${name}.active`);
            if (currentSubtitle === subtitle) {
                this.oldIdName = idName;
                this.oldSubtitleName = name;
                return;
            } else {
                document.getElementById(this.oldIdName).style.display = "none";
                document.getElementById(idName).style.display = "block";
                const lastSubtitle = document.querySelector(`.${this.oldSubtitleName}.active`);
                lastSubtitle.classList.toggle('active');
                this.oldIdName = idName;
                this.oldSubtitleName = name;
            }
        },
        setupNavItems() {
            const navItems = document.querySelectorAll('.nav-item, .menu-nav-hd');
            navItems.forEach(item => {
                const link = item.querySelector('.nav-hd, .menu-nav-hd');
                const dropdown = item.querySelector('.nav-dropdown, .menu-dropdown');

                // 确保 link 和 dropdown 不为 null
                if (link && dropdown) {
                    link.addEventListener('click', (e) => {
                        e.preventDefault();
                        dropdown.style.display = (dropdown.style.display === 'block') ? 'none' : 'block';
                    });
                } else {
                    console.warn('Link or dropdown not found:', { link, dropdown });
                }
            });
        },
        async getQuestionBackend() {
            try {
                const response = await axios.get('http://localhost:5000/Question');
                this.processQuestions(response.data);  // 处理数据并填充数组
                console.log("response", response.data);
                console.log("this.textArray", this.textArray);
            } catch (error) {
                console.error('Error fetching data:', error);
            }

        },
        processQuestions(data) {
            // 获取最大 questionType 以初始化数组
            const maxType = Math.max(...data.map(q => q.questionType));
            this.textArray = Array.from({ length: maxType + 1 }, () => []);
            this.answerArray = Array.from({ length: maxType + 1 }, () => []);

            // 遍历数据并填充二维数组
            data.forEach(question => {
                const type = question.questionType;
                if (this.textArray[type]) {
                    this.textArray[type].push(question.questionText);
                } else {
                    this.textArray[type] = [question.questionText];
                }

                if (this.answerArray[type]) {
                    this.answerArray[type].push(question.questionAnswer);
                } else {
                    this.answerArray[type] = [question.questionAnswer];
                }
            });
        },
        getCombinedArray(index) {
            // 检查索引是否在有效范围内
            if (index < 0 || index >= this.textArray.length || index >= this.answerArray.length) {
                return []; // 返回空数组表示无效索引
            }

            // 获取问题和答案数组
            const questions = this.textArray[index];
            const answers = this.answerArray[index];

            // 如果 questions 或 answers 为 null 或 undefined，则返回空数组
            if (!Array.isArray(questions) || !Array.isArray(answers)) {
                return [];
            }

            // 确保 answers 数组的长度与 questions 数组匹配
            return questions.map((question, i) => ({
                question: question,
                answer: answers[i] || ''  // 确保不会超出范围
            }));
        },

    },
    async mounted() {
        await this.getQuestionBackend();  // 确保在组件挂载时获取数据
        this.setupNavItems(); // 初始化导航项
        this.toggleMenu('ticket-menu', 'ticket-info', 'subtitle-1'); // 打开时默认显示车票信息
    },
};
</script>

<style scoped>
/* 引入全局默认样式  */
@import url("../assets/default_style.css");
/* 引入头部样式 */
@import url("../assets/header_style.css");
/* 引入指南样式 */
@import url("../assets/guide_style.css");


#layout{
    min-width: 100vw;
    height: 100vh;
}

.suggestions {
    border: 1px solid #ccc;
    border-top: none;
    max-height: 200px;
    overflow-y: auto;
    background: white;
    width: 100%;
    z-index: 1000;
    margin-top: 5px;
    /* 调整联想框与搜索栏的间距 */
}

.suggestions div {
    padding: 10px;
    cursor: pointer;
}

.suggestions div:hover {
    background-color: #f0f0f0;
}
</style>
