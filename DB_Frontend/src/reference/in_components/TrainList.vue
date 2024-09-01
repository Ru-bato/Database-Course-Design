<template>
    <div>
      <h2>Available Trains</h2>
      <p>可以这样跳转</p>
      <ul>
        <li v-for="ticket in tickets" :key="ticket.id">{{ ticket.destination }}</li>
      </ul>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue';
  import { useStore } from 'vuex';
  import { computed } from 'vue';
  
  export default defineComponent({
    name: 'TrainList',
    setup() {
      const store = useStore();
      const tickets = computed(() => store.state.tickets);
  
      return {
        tickets,
      };
    },
  });
  </script>
  