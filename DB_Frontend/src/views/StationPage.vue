<template>
    <div class="container">
        <HeaderComponent />
        <NavComponent />
        <BodyWrapper />
    </div>
</template>

<script lang="ts">
import HeaderComponent from '@/components/HeaderComponent.vue';
import BodyWrapper from '@/components/BodyWrapper.vue';
import NavComponent from '@/components/NavComponent.vue';

export default {
    components: {
        HeaderComponent,
        NavComponent,
        BodyWrapper,
    }
};
</script>

<style scoped>
.container {
    min-width: 100vw;
    min-height: 100vh;
}
</style>