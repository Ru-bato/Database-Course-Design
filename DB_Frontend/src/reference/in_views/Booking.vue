<template>
    <div>
      <h1>Book Your Tickets</h1>
      <TrainList />
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue';
  import TrainList from '../components/TrainList.vue';
  
  export default defineComponent({
    name: 'Booking',
    components: {
      TrainList,
    },
  });
  </script>
  