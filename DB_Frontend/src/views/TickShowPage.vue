<template>
    <div class="container">
      <HeaderComponent />
      <NavComponent />
      <TicketShow />
    </div>
  </template>
  
  <script lang="ts">
  import HeaderComponent from '@/components/HeaderComponent.vue';
  import NavComponent from '@/components/NavComponent.vue';
  import TicketShow from '@/components/TicketShow.vue';
  
  export default {
    components: {
      HeaderComponent,
      NavComponent,
      TicketShow,
    }
  };
  </script>
  
  <style scoped>
  .container {
    min-width: 100vw;
    min-height: 100vh;
  }
  </style>