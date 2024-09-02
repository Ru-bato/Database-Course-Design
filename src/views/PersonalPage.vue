<template>
  <div id="app" class="myapp-container">
    <MyHeader />
    <div class="mymain">
      <MySidebar @menu-selected="currentMenu = $event" />
      <div class="mycontent">
        <component :is="currentMenu" />
      </div>
    </div>
  </div>
</template>

<script>
import MyHeader from '../components/MyHeader.vue';
import MySidebar from '../components/Sidebar.vue';
import HomePage from '../components/HomePage.vue';
import EditInfo from '../components/EditInfo.vue';
import EditPassenger from '../components/EditPassenger.vue';
import AdminFunctions from '../components/AdminFunctions.vue';

export default {
  name: 'App',
  components: {
    MyHeader,
    MySidebar,
    HomePage,
    EditInfo,
    EditPassenger,
    AdminFunctions,
  },
  data() {
    return {
      currentMenu: 'HomePage', // 默认显示主页
    };
  },
};
</script>

<style scoped>
/* 重置样式，确保页面元素按照预期显示 */
.myapp-container, .mymain, .mycontent {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

/* 确保页眉在顶部显示 */
.myapp-container {
  display: flex;
  flex-direction: column; /* 垂直布局：页眉在上方，mymain 在下方 */
  height: 100vh;
  width: 100vw;
  overflow: hidden;
}

/* 确保页眉占满整个宽度 */
.myapp-container > * {
  width: 100%; /* 子元素宽度设置为100% */
}

/* 主体部分：侧边栏在左，内容在右 */
.mymain {
  display: flex;
  flex-direction: row; /* 水平布局：侧边栏在左，内容部分在右 */
  flex: 1;
  width: 100%;
  overflow: hidden;
}

.mycontent {
  flex-grow: 1;
  padding: 20px;
  background-color: #f0f2f5;
  overflow-y: auto;
  min-width: 0;
}
</style>
