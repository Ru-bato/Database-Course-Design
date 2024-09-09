<template>
  <div id="app" class="myapp-container">
    <div class="mymain">
      <HeaderComponent />
      <NavComponent />
      <div class="main-body">
        <MySidebar @menu-selected="onMenuSelected" />
        <div class="mycontent">
          <component :is="currentMenu" />
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import MySidebar from '../components/PersonalSidebar.vue';
import HomePage from '../components/PersonalHomePage.vue';
import EditInfo from '../components/PersonalEditInfo.vue';
import EditPassenger from '../components/PersonalEditPassenger.vue';
import AdminFunctions from '../components/PersonalAdminFunctions.vue';
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';

export default defineComponent({
  name: 'App',
  components: {
    HeaderComponent,
    NavComponent,
    MySidebar,
    HomePage,
    EditInfo,
    EditPassenger,
    AdminFunctions,
  },
  setup() {
    const currentMenu = ref<string>('HomePage'); // 默认显示主页

    const onMenuSelected = (menu: string) => {
      currentMenu.value = menu;
    };

    return {
      currentMenu,
      onMenuSelected,
    };
  },
});
</script>

<style scoped>
.myapp-container, .mymain, .mycontent {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  min-width: 100vw;
}

/* 调整为垂直布局 */
.myapp-container {
  display: flex;
  flex-direction: column; /* 垂直布局：HeaderComponent在上，内容在下 */
  height: 100vh;
  width: 100vw;
  overflow: hidden;
}

/* 主体部分：确保Header在上方，侧边栏和内容部分在下方 */
.mymain {
  display: flex;
  flex-direction: column; /* Header在上，main-body部分在下 */
  flex: 1;
}

.main-body {
  display: flex;
  flex-direction: row; /* 保持侧边栏在左，内容部分在右 */
  flex: 1;
  width: 100%;
}

.mycontent {
  flex-grow: 1;
  padding: 20px;
  background-color: #f0f2f5;
  overflow-y: auto;
  min-width: 0;
}
</style>
