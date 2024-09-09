<template>
  <div class="container">
      <HeaderComponent />
      <NavComponent />
      <FoodListComponent />
  </div>
</template>

<script lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';
import FoodListComponent from '../components/foodListComponent.vue';

export default {
  components: {
      HeaderComponent,
      NavComponent,
      FoodListComponent,
  }
};
</script>

<style scoped>
.container {
  min-width: 100vw;
  min-height: 100vh;
}
</style>