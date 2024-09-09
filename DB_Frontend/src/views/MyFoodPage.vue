<template>
  <div class="container">
      <HeaderComponent />
      <NavComponent />
      <myFoodComponent />
  </div>
</template>

<script lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';
import myFoodComponent from '@/components/myFoodComponent.vue';

export default {
  components: {
      HeaderComponent,
      NavComponent,
      myFoodComponent,
  }
};
</script>

<style scoped>
.container {
  min-width: 100vw;
  min-height: 100vh;
}
</style>