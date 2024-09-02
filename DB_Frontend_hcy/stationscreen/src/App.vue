<template>
  <AppHeader />
  <BodyWrapper />
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import AppHeader from './components/AppHeader.vue';
import BodyWrapper from './components/BodyWrapper.vue';

export default defineComponent({
  name: 'App',
  components: {
    AppHeader,
    BodyWrapper
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
}
</style>
