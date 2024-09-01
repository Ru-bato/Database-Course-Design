<template>
  <div class="container">
    <HeaderComponent />
    <NavComponent />
    <WaitOrder />
  </div>
</template>

<script lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';
import WaitOrder from '@/components/WaitOrder.vue';

export default {
  components: {
    HeaderComponent,
    NavComponent,
    WaitOrder
  }
};
</script>

<style scoped>
.container {
  min-width: 100vw;
}
</style>