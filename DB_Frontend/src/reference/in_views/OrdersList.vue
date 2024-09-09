<template>
  <div class="container">
    <HeaderComponent />
    <NavComponent />
    <OrdersList />
  </div>
</template>

<script lang="ts">
import OrdersList from '@/components/OrdersList.vue';
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';
export default {
  components: {
    OrdersList,
    NavComponent,
    HeaderComponent,
  }
};
</script>

<style scoped>
.container {
  min-width: 100vw;
}
</style>
