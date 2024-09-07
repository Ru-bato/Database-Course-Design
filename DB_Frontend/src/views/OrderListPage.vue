<template>
    <div class="container">
        <HeaderComponent />
        <NavComponent />
        <OrderListstatistic />
    </div>
</template>

<script lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import NavComponent from '@/components/NavComponent.vue';
import OrderListstatistic from '@/components/OrderListstatistic.vue';

export default {
    components: {
        HeaderComponent,
        NavComponent,
        OrderListstatistic,
    }
};
</script>

<style scoped>
.container {
    min-width: 100vw;
}
</style>