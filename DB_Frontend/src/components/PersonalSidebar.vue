<template>
  <aside class="sidebar">
    <ul>
      <li :class="{ active: current === 'HomePage' }" @click="selectMenu('HomePage')">主页</li>
      <li :class="{ active: current === 'EditInfo' }" @click="selectMenu('EditInfo')">修改信息</li>
      <li :class="{ active: current === 'EditPassenger' }" @click="selectMenu('EditPassenger')">编辑乘车人</li>
      <!-- 只有当 userID === '8' 时才显示管理员功能 -->
      <li v-if="userID === '8'" :class="{ active: current === 'AdminFunctions' }" @click="selectMenu('AdminFunctions')">管理员功能</li>
    </ul>
  </aside>
</template>

<script lang="ts">
import { defineComponent, ref, computed } from 'vue';

export default defineComponent({
  name: 'MySidebar',
  setup(_, { emit }) {
    const current = ref<string>('HomePage');

    const selectMenu = (menu: string) => {
      current.value = menu;
      emit('menu-selected', menu);
    };

    // 通过 computed 来确保 userID 在组件生命周期内始终保持最新状态
    const userID = computed(() => localStorage.getItem('User_ID'));

    return {
      current,
      userID,
      selectMenu,
    };
  },
});
</script>

<style scoped>
.sidebar {
  width: 200px;
  background-color: #343a40;
  color: white;
  padding: 20px;
  box-sizing: border-box;
}

.sidebar ul {
  list-style-type: none;
  padding: 0;
  margin: 0;
}

.sidebar li {
  padding: 10px;
  cursor: pointer;
  border-radius: 4px;
  margin-bottom: 5px;
}

.sidebar li:hover,
.sidebar li.active {
  background-color: #495057;
}
</style>
