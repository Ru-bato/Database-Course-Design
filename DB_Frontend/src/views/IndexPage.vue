<template>
    <div class="container">
      <HeaderComponent />
      <NavComponent />
      <IndexView />
    </div>
  </template>
  
  <script lang="ts">
  import IndexView from '@/views/IndexView.vue';
  import HeaderComponent from '@/components/HeaderComponent.vue';
  import NavComponent from '@/components/NavComponent.vue';
  export default {
    components: {
      IndexView,
      NavComponent,
      HeaderComponent,
    }
  };
  </script>
  
  <style scoped>
  .container {
    min-height: 100vh;
    min-width: 100vw;
  }
  </style>
  