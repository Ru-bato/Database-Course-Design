<template>
    <div class="container">
      <HeaderComponent />
      <NavComponent />
      <BuyTicket />
    </div>
  </template>
  
  <script lang="ts">
  import HeaderComponent from '@/components/HeaderComponent.vue';
  import NavComponent from '@/components/NavComponent.vue';
  import BuyTicket from '@/components/BuyTicket.vue';
  
  export default {
    components: {
      HeaderComponent,
      NavComponent,
      BuyTicket,
    }
  };
  </script>
  
  <style scoped>
  .container {
    min-width: 100vw;
    min-height: 100vh;
  }
  </style>