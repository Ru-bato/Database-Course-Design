<template>
  <div class="nav-box">
    <ul class="nav">
      <li v-for="(item, index) in navItems" :key="index" class="nav-item">
        <a href="#" class="nav-hd">
          {{ item.name }}
          <div class="dropdown-arrow"></div>
        </a>
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
        { name: "首页", subMenu: ["子菜单项 1", "子菜单项 2", "子菜单项 3"] },
        { name: "车票", subMenu: ["子菜单项 1", "子菜单项 2", "子菜单项 3"] },
        { name: "团购服务", subMenu: ["子菜单项 1", "子菜单项 2", "子菜单项 3"] },
        { name: "站车服务", subMenu: ["子菜单项 1", "子菜单项 2", "子菜单项 3"] },
        { name: "商旅服务", subMenu: ["子菜单项 1", "子菜单项 2", "子菜单项 3"] },
        { name: "出行指南", subMenu: ["子菜单项 1", "子菜单项 2", "子菜单项 3"] },
        { name: "信息查询", subMenu: ["子菜单项 1", "子菜单项 2", "子菜单项 3"] }
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
