<template>
    <div>
      <h1>Welcome to 12306 Railway Ticket System</h1>
      <button @click="navigateToBooking">Book Tickets</button>
      <RouterLink to="/login" >Login</RouterLink>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue';
  import { useRouter } from 'vue-router';
  
  export default defineComponent({
    name: 'Home',
    setup() {
      const router = useRouter();
  
      const navigateToBooking = () => {
        router.push('/booking');
      };
  
      return {
        navigateToBooking,
      };
    },
  });
  </script>
  