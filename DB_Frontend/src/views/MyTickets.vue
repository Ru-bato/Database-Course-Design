<template>
  <div class="container">
    <HeaderComponent />
    <NavComponent />
    <MyTickets /> 
  </div>
</template>

<script lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';
import MyTickets from '../components/MyTickets.vue';

export default {
  components: {
    HeaderComponent,
    NavComponent,
    MyTickets,
  }
};
</script>

<style scoped>
.container {
  min-width: 100vw;
}
</style>