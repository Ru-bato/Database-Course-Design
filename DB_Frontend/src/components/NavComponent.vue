<template>
  <div class="nav-box">
    <ul class="nav">
      <li v-for="(item, index) in navItems" :key="index" class="nav-item">
        <router-link
          v-if="item.route"
          :to="item.route"
          class="nav-hd"
        >{{ item.name }}</router-link>
        <!-- <a href="#" class="nav-hd">
          {{ item.name }} -->
          <!-- <div class="dropdown-arrow"></div> -->
        <!-- </a> -->
        <ul class="nav-dropdown">
          <li v-for="(subItem, subIndex) in item.subMenu" :key="subIndex">
            <a class="nav-dropdown-item" href="#">{{ subItem }}</a>
          </li>
        </ul>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      navItems: [
        // { name: "酒店" ,route: ""},
        // { name: "机票" ,route,},
        { name: "首页" ,route:{name:'Index'}},
        { name: "车站大屏",route:{name:'StationPage'} },
        // { name: "站车服务" },
        { name: "已购车票",route:{name:'PaidOrder'} },
        { name: "候补车票",route:{name:'WaitOrder'} },
        { name: "待支付车票",route:{name:'UnpaidOrder'} },
        { name: "个人主页", route:{name:'PersonalPage'} },
        { name: "常见问题",route:{name:'TicketsQuestions'} },
      ]
    };
  }
};
</script>

<style scoped>
.nav-box {
  height: 40px;
  background: #3B99FC;
}

.nav {
  width: 1190px;
  margin-left: auto;
  margin-right: auto;
  position: relative;
  height: 40px;
  z-index: 1900;
}

.nav .nav-item .nav-hd {
  display: block;
  height: 40px;
  line-height: 40px;
  color: #fff;
  text-align: center;
}

.nav .nav-item {
  background-color: #3B99FC;
  float: left;
  width: 159px;
  position: relative;
}

.nav .nav-item:hover {
  background-color: #2676e3;
}

.nav .nav-item .dropdown-arrow {
  float: right;
  position: relative;
  top: 50%;
  right: 10px;
  transform: translateY(-50%);
  width: 0;
  height: 0;
  border-left: 5px solid transparent;
  border-right: 5px solid transparent;
  border-top: 5px solid #fff;
  cursor: pointer;
}

li.nav-item::marker {
  content: none;
}

.nav-item:hover .nav-dropdown {
  display: block;
  width: 159px;
}

.nav-dropdown-item {
  padding: 10px;
  text-decoration: none;
  color: #3B99FC;
  display: block;
}

.nav-dropdown {
  display: none;
  position: absolute;
  background-color: #fff;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  left: 0;
  top: 100%;
  z-index: 2000;
}
</style>
