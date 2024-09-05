<template>
  <!-- <img alt="Vue logo" src="./assets/logo.png"> -->
  <Tickets_show msg="Welcome to Your Vue.js + TypeScript App"/>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import HelloWorld from './components/HelloWorld.vue';
import Tickets_show from './components/tickets_show.vue';
// import Tickets_show from './components/tickets_show.vue';

export default defineComponent({
  name: 'App',
  components: {
    Tickets_show
  }
});
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  /* margin-top: 60px; */
}
</style>
