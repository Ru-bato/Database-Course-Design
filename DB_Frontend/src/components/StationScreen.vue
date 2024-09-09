<template>  
  <div class="train-show-box">  
    <!-- 车次展示 -->  
    <div class="train-result-box">  
      <div class="train-result-hd">  
        <!-- 表头 -->  
        <div class="train-result-titlist titlist-controller">  
          <div class="train-number">车次</div>  
          <div class="train-station">{{ tableTitle.stationType }}</div>  
          <div class="train-time">  
            {{ tableTitle.timeType }}  
            <span class="btn-sort">  
              <i  
                class="sort-top"  
                :class="{ active: isAscActive }"  
                attr-code="trainTime"  
                @click="toggleSort(true)"  
              ></i>  
              <i  
                class="sort-down"  
                :class="{ active: !isAscActive }"  
                attr-code="trainTime"  
                @click="toggleSort(false)"  
              ></i>  
            </span>  
          </div>  
          <div class="train-check">{{ tableTitle.checkType }}</div>  
          <div class="train-status">状态</div>  
        </div>  
      </div>  

      <div class="train-list-bd">  
        <!-- 车次列表 -->  
        <div v-if="paginatedTrainList.length > 0">  
          <div v-for="train in paginatedTrainList" :key="train.number" class="train-result-item">  
            <div class="train-number">  
              <div class="train-number-info">{{ train.number }}</div>  
            </div>  
            <div class="train-station">  
              <div class="train-station-info">{{ train.station }}</div>  
            </div>  
            <div class="train-time">  
              <div class="train-time-info">{{ train._time }}</div>  
            </div>  
            <div class="train-check">  
              <div class="train-check-info">{{ train.check }}</div>  
            </div>  
            <div class="train-status">  
              <div :class="`train-status-info ${getStatusClass(train.status)}`">  
                {{ train.status }}  
              </div>  
            </div>  
          </div>  
        </div>  

        <div v-else class="no-train" id="no_filter_train">  
          <!-- 无结果页面 -->  
          <p class="no-train-text">没有查询到符合条件的车次！</p>  
        </div>  
      </div>  
    </div>   
  </div>  

  <!-- 分页组件 -->  
  <div class="pagination">  
    <button @click="prevPage" class="btn" :disabled="currentPage === 1">上一页</button>  
    <span>第 {{ currentPage }} 页 / 共 {{ totalPages }} 页</span>  
    <button @click="nextPage" class="btn" :disabled="currentPage === totalPages">下一页</button>  
  </div> 
</template>  

<script lang="ts">  
import { defineComponent, ref, computed } from 'vue';  
import type { Train } from './StationSearch.vue';  

export default defineComponent({  
  props: {  
    tableTitle: { type: Object, required: true },  
    trainList: { type: Array as () => Train[], required: true },  
    sortTrainsAsc: { type: Function, required: true },  
    sortTrainsDesc: { type: Function, required: true },  
  },  
  setup(props) {  
    const isAscActive = ref(true); // 默认为升序  
    const currentPage = ref(1);  
    const itemsPerPage = 5; // 每页显示的车次数量  

    const totalPages = computed(() => {  
      return Math.ceil(props.trainList.length / itemsPerPage);  
    });  

    const paginatedTrainList = computed(() => {  
      const start = (currentPage.value - 1) * itemsPerPage;  
      return props.trainList.slice(start, start + itemsPerPage);  
    });  

    const toggleSort = (isAsc: boolean) => {  
      isAscActive.value = isAsc; // 更新排序状态  
      if (isAsc) {  
        props.sortTrainsAsc();  
      } else {  
        props.sortTrainsDesc();  
      }  
    };  

    const nextPage = () => {  
      if (currentPage.value < totalPages.value) {  
        currentPage.value++;  
      }  
    };  

    const prevPage = () => {  
      if (currentPage.value > 1) {  
        currentPage.value--;  
      }  
    };  

    const getStatusClass = (status: string) => {  
      return status === '停止检票' ? 'train-status-info-red' :  
             status === '正在检票' ? 'train-status-info-green' :  
             status === '正在候车' ? 'train-status-info-gray' :  
             status === '正点' ? 'train-status-info-green' :  
             status === '晚点' ? 'train-status-info-red' : '';  
    };  

    return {  
      isAscActive,  
      toggleSort,  
      currentPage,  
      totalPages,  
      paginatedTrainList,  
      nextPage,  
      prevPage,  
      getStatusClass,  
    };  
  }  
});  
</script>  

<style scoped>
/* --------------- Show Box Styles ---------------*/

.train-show-box {
  width: 1200px;
  background: #FFF;
  border: 1px solid #dedede;
  margin-top: 10px;
  min-height: 300px;
}

.train-show-box:before,
.train-show-box:after {
  content: "";
  display: table;
}

.train-show-box:after {
  clear: both;
  overflow: hidden;
}

.train-result-box .train-number {
  float: left;
  width: 200px;
  padding-left: 80px;
}

.train-result-box .train-station {
  float: left;
  width: 200px;
  text-align: center;
}

.train-result-box .train-time {
  float: left;
  width: 200px;
  text-align: center;
}

.train-result-box .train-check {
  float: left;
  width: 200px;
  text-align: center;
}

.train-result-box .train-status {
  float: left;
  width: 200px;
  text-align: center;
}

.train-result-hd {
  height: 40px;
  background: #F8F8F8;
  line-height: 40px;
  overflow: hidden;
  color: #666;
}

.train-result-titlist {
  height: 40px;
  line-height: 40px;
  overflow: hidden;
  color: #666;
}

.btn {
  margin-right: 6px;
  margin-left: 6px;
  position: relative;
}

.btn-sort {
  display: inline-block;
  width: 8px;
  height: 10px;
  margin-left: 6px;
  position: relative;
}

.btn-sort .sort-top {
  position: absolute;
  top: 0;
  left: 0;
  display: inline-block;
  width: 0;
  height: 0;
  line-height: 0;
  font-size: 0;
  overflow: hidden;
  border-width: 4px;
  cursor: pointer;
  border-style: dashed dashed solid dashed;
  border-color: transparent transparent #999 transparent;
  border-top: none;
}

.btn-sort .sort-top.active {
  display: inline-block;
  width: 0;
  height: 0;
  line-height: 0;
  font-size: 0;
  overflow: hidden;
  border-width: 4px;
  cursor: pointer;
  border-style: dashed dashed solid dashed;
  border-color: transparent transparent #3b99fc transparent;
  border-top: none;
}

.btn-sort .sort-down {
  position: absolute;
  bottom: 0;
  left: 0;
  display: inline-block;
  width: 0;
  height: 0;
  line-height: 0;
  font-size: 0;
  overflow: hidden;
  border-width: 4px;
  cursor: pointer;
  border-style: solid dashed dashed dashed;
  border-color: #999 transparent transparent transparent;
  border-bottom: none;
}

.btn-sort .sort-down.active {
  display: inline-block;
  width: 0;
  height: 0;
  line-height: 0;
  font-size: 0;
  overflow: hidden;
  border-width: 4px;
  cursor: pointer;
  border-style: solid dashed dashed dashed;
  border-color: #3b99fc transparent transparent transparent;
  border-bottom: none;
}

/* --------------- Train Item Styles ---------------*/

.train-result-item {
  padding: 15px 0;
  border-bottom: 1px dashed #dedede;
}

.train-result-item:before,
.train-result-item:after {
  content: "";
  display: table;
}

.train-result-item:after {
  clear: both;
  overflow: hidden;
}

.train-result-item:last-child {
  border-bottom: none;
}

.train-result-item .train-number-info {
  height: 32px;
  line-height: 32px;
  font-size: 20px;
  font-weight: 700;
  margin-bottom: 10px;
}

.train-result-item .train-station-info {
  height: 32px;
  line-height: 32px;
  font-size: 20px;
  font-weight: 700;
  margin-bottom: 10px;
}

.train-result-item .train-time-info {
  height: 32px;
  line-height: 32px;
  font-size: 20px;
  margin-bottom: 5px;
}

.train-result-item .train-check-info {
  height: 32px;
  line-height: 32px;
  font-size: 20px;
  font-weight: 700;
  margin-bottom: 10px;
}

.train-result-item .train-status-info {
  height: 32px;
  line-height: 32px;
  font-size: 20px;
  margin-bottom: 5px;
}

.train-result-item .train-status-info.train-status-info-green {
  color: lightgreen;
}

.train-result-item .train-status-info.train-status-info-gray {
  color: gray;
}

.train-result-item .train-status-info.train-status-info-red {
  color: red;
}

/* --------------- No Train Styles ---------------*/

.no-train {
  width: 420px;
  margin: 20px auto;
}

.no-train .icon {
  display: inline-block;
  width: 66px;
  height: 66px;
  font-size: 40px;
}

.no-train p {
  display: inline-block;
}

.no-train .no-train-text {
  transform: translateX(-20px) translateY(-8px);
}

.pagination {  
  margin-top: 20px;  
}  
</style>