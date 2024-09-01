<template>
  <div class="container">
    <HeaderComponent />
    <NavComponent />
    <TrainManagement />
  </div>
</template>

<script lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';
import TrainManagement from '@/components/TrainManagement.vue';

export default {
  components: {
    HeaderComponent,
    NavComponent,
    TrainManagement,
  }
};
</script>

<style scoped>
.container {
  min-width: 100vw;
}
</style>