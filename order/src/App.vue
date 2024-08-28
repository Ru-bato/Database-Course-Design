<template>
  <div id="layout">
    <HeaderComponent />
    <NavComponent />
    <OrdersList /> 
    <!-- 其他内容 -->
  </div>
</template>

<script>
import HeaderComponent from './components/HeaderComponent.vue';
import NavComponent from './components/NavComponent.vue';
import OrdersList from './components/OrdersList.vue';

export default {
  components: {
    HeaderComponent,
    NavComponent,
    OrdersList,
  }
};
</script>

<style src="./src/assets/default_style.css"></style>
