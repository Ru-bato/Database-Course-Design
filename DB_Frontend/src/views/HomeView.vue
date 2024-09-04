<script setup lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue'
import OrdersList from '@/components/OrdersList.vue';
</script>

<template>
    <div class="container">
        <HeaderComponent />
        <NavComponent />
    </div>
    
</template>

<style scoped>
.container {
  min-width: 100vw;
}
</style>