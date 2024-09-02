<template>
  <aside class="sidebar">
    <ul>
      <li :class="{ active: current === 'HomePage' }" @click="selectMenu('HomePage')">主页</li>
      <li :class="{ active: current === 'EditInfo' }" @click="selectMenu('EditInfo')">修改信息</li>
      <li :class="{ active: current === 'EditPassenger' }" @click="selectMenu('EditPassenger')">编辑乘车人</li>
      <li :class="{ active: current === 'AdminFunctions' }" @click="selectMenu('AdminFunctions')">管理员功能</li>
    </ul>
  </aside>
</template>

<script>
export default {
  name: 'MySidebar',
  data() {
    return {
      current: 'HomePage',
    };
  },
  methods: {
    selectMenu(menu) {
      this.current = menu;
      this.$emit('menu-selected', menu);
    },
  },
};
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
