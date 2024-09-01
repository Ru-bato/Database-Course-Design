<template>
  <div class="container">
    <HeaderComponent />
    <NavComponent />
    <UnpaidOrder />
  </div>
</template>

<script lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';
import UnpaidOrder from '@/components/UnpaidOrder.vue';

export default {
  components: {
    HeaderComponent,
    NavComponent,
    UnpaidOrder
  }
};
</script>

<style scoped>
.container {
  min-width: 100vw;
}
</style>