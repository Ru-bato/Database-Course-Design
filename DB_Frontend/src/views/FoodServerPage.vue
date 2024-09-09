<template>
  <div class="container">
      <HeaderComponent />
      <NavComponent />
      <foodServerComponent />
  </div>
</template>

<script lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';
import foodServerComponent from '@/components/foodServerComponent.vue';

export default {
  components: {
      HeaderComponent,
      NavComponent,
      foodServerComponent,
  }
};
</script>

<style scoped>
.container {
  min-width: 100vw;
  min-height: 100vh;
}
</style>