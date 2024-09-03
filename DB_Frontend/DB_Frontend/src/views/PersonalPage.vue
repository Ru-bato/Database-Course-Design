<template>
  <div id="app" class="myapp-container">
    <div class="mymain">
      <MySidebar @menu-selected="currentMenu = $event" />
      <div class="mycontent">
        <component :is="currentMenu" />
      </div>
    </div>
  </div>
</template>

<script>
import MySidebar from '../components/PersonalSidebar.vue';
import HomePage from '../components/PersonalHomePage.vue';
import EditInfo from '../components/PersonalEditInfo.vue';
import EditPassenger from '../components/PersonalEditPassenger.vue';
import AdminFunctions from '../components/PersonalAdminFunctions.vue';

export default {
  name: 'App',
  components: {
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

/* 确保整个页面布局填充 */
.myapp-container {
  display: flex;
  flex-direction: row; /* 水平布局：侧边栏在左，内容在右 */
  height: 100vh;
  width: 100vw;
  overflow: hidden;
}

/* 主体部分：侧边栏在左，内容在右 */
.mymain {
  display: flex;
  flex-direction: row; /* 水平布局：侧边栏在左，内容部分在右 */
  flex: 1;
  width: 200%;
}

.mycontent {
  flex-grow: 1;
  padding: 20px;
  background-color: #f0f2f5;
  overflow-y: auto;
  min-width: 0;
}
</style>
