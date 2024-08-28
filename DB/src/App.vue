<template>
  <div id="layout">
    <HeaderComponent />
    <NavComponent />
    <MyTickets />
    <!-- 其他内容 -->
  </div>
</template>

<script>
import HeaderComponent from './components/HeaderComponent.vue';
import NavComponent from './components/NavComponent.vue';
import MyTickets from './components/MyTickets.vue';


export default {
  components: {
    HeaderComponent,
    NavComponent,
    MyTickets
  }
};
</script>

<style src="./src/assets/default_style.css"></style>
