<template>
  <div class="container">
    <HeaderComponent />
    <NavComponent />
    <PaidOrder />
  </div>
</template>

<script lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';
import PaidOrder from '@/components/PaidOrder.vue';

export default {
  components: {
    HeaderComponent,
    NavComponent,
    PaidOrder
  }
};
</script>

<style scoped>
.container {
  min-width: 100vw;
}
</style>