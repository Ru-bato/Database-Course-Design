<template>
  <div class="BodyWrapper">
  <!-- 搜索框和车站大屏的容器 -->
    <StationSearch />
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import StationSearch from './StationSearch.vue';

export default defineComponent({
  name: 'BodyWrapper',
  components: {
    StationSearch
  }
});
</script>

<style scoped>
/* --------------- Wrapper Styles ---------------*/
.BodyWrapper {
    width: 1200px;
    padding: 0 5px;
    margin-left: auto;
    margin-right: auto;
}
</style>