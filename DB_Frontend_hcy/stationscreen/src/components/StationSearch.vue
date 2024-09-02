<template>
  <div class="station-search-form">
    <!-- 搜索和控制组件 -->
    <div class="form-item">
      <div class="form-label">当前车站</div>
      <div class="form-controller">
      <!-- 车站搜索框 -->
        <div class="input-box input-station">
          <input
            type="text"
            v-model="stationName"
            placeholder="请输入车站名称"
            class="input-text"
          />
        </div>
      </div>
    </div>

    <div class="form-item">
      <div class="form-label">车次查询</div>
      <div class="form-controller">
      <!-- 车次搜索框 -->
        <div class="input-box input-train">
          <input
            type="text"
            v-model="trainNumber"
            placeholder="输入车次查询"
            class="input-text"
          />
        </div>
      </div>
    </div>

    <div class="form-item form-item-button">
    <!-- 查询按钮 -->
      <button @click="queryTrains" class="btn btn-primary">查询</button>
    </div>

    <div class="form-item form-item-button">
    <!-- 刷新按钮 -->
      <button @click="refreshTrains" class="btn btn-primary">刷新</button>
    </div>

    <div class="form-item form-item-switch-button-container">
    <!-- 切换出发到达按钮 -->
      <div class="form-item form-item-switch-button">
        <button
          id="depart"
          class="btn"
          :class="{ 'btn-primary': isDepartActive, 'active': isDepartActive }"
          @click="toggleDepart"
        >出发</button>
        <button
          id="arrive"
          class="btn"
          :class="{ 'btn-primary': isArriveActive, 'active': isArriveActive }"
          @click="toggleArrive"
        >到达</button>
      </div>
    </div>
  </div>

  <!-- 处理出发/到达按钮切换 -->
  <StationScreen :tableTitle="tableTitle" :trainList="filteredTrains" />
</template>

<script lang="ts">
import { defineComponent, ref, computed } from 'vue';
import axios from 'axios';
import StationScreen from './StationScreen.vue';

interface Train {
  number: string; // 车次
  station: string; // 车站
  _time: string; // 时间
  check: string; // 检票口或出站口
  status: string; // 状态
}

export default defineComponent({
  components: {
    StationScreen
  },
  setup() {  
    const stationName = ref<string>('');
    const trainNumber = ref<string>('');
    const isDepartActive = ref<boolean>(true);
    const isArriveActive = ref<boolean>(false);
    const viewMode = ref<'depart' | 'arrive'>('depart');
    const trainList = ref<Train[]>([]);

    const tableTitle = computed(() => {
      return viewMode.value === 'depart' 
        ? { stationType: '终点站', timeType: '出发时间', checkType: '检票口' } 
        : { stationType: '起点站', timeType: '到达时间', checkType: '出站口' };
    });

    const filteredTrains = computed(() => {
      return trainList.value.filter(train => {
        return trainNumber.value ? train.number === trainNumber.value : true;
      });
    });

    const toggleDepart = () => {
      isDepartActive.value = true;
      isArriveActive.value = false;
      viewMode.value = 'depart';
      queryTrains();
    };

    const toggleArrive = () => {
      isDepartActive.value = false;
      isArriveActive.value = true;
      viewMode.value = 'arrive';
      queryTrains();
    };

    const queryTrains = async () => {
      const url = isDepartActive.value 
        ? 'http://localhost:5080/api/Screen/departure'
        : 'http://localhost:5080/api/Screen/arrival';

      try {
        const response = await axios.post(url, { query: stationName.value });
        if (response.data) {
          trainList.value = response.data as Train[];
        } else {
          console.log('empty');
        }
      } catch (error) {
        console.error('Error fetching train data:', error);
      }
    };

    const refreshTrains = () => {
      queryTrains();
    };

    return {  
      stationName,
      trainNumber,
      isDepartActive,
      isArriveActive,
      tableTitle,
      filteredTrains,
      toggleDepart,
      toggleArrive,
      queryTrains,
      refreshTrains
    };
  }
});
</script>

<style scoped>
/* --------------- Search Form Styles ---------------*/

.station-search-form {
  border: 1px solid #3b99fc;
  background: #F9FDFF;
  padding: 20px;
}

.station-search-form:before,
.station-search-form:after {
  content: "";
  display: table;
}

.station-search-form:after {
  clear: both;
  overflow: hidden;
}

.station-search-form .form-item {
  float: left;
  margin-right: 20px;
  height: 30px;
  line-height: 30px;
}

.station-search-form .form-label {
  float: left;
  margin-right: 10px;
}

.station-search-form .form-controller {
  float: left;
}

.station-search-form .form-item-button {
  float: right;
  margin-right: 0;
}

.train-search-form .form-item-button .button {
  vertical-align: top;
}

.station-search-form .form-item-switch-button-container {
  display: flex;
  border: 2px solid #007BFF;
  border-radius: 5px;
  overflow: hidden;
}

.station-search-form .form-item-switch-button {
  padding: 0px 8px;
  background-color: #F9FDFF;
  transition: background-color 0.3s;
  font-size: 16px;
  margin: 0;
}

.station-search-form .form-item-switch-button .active {
  background-color: #007BFF;
  color: white;
}

.station-search-form .form-item-switch-button:hover {
  background-color: #e0e0e0;
}

.input-box {
  display: inline-block;
  position: relative;
}

.input-box .input, .input-box .textarea {
  width: 100%;
  vertical-align: top;
}

.input-box .icon {
  position: absolute;
  top: 0;
  right: 0;
  width: 30px;
  height: 30px;
  line-height: 30px;
  text-align: center;
  color: #dcdcdc;
  cursor: pointer;
  font-size: 18px;
}

.input-box .icon:hover {
  color: #3b99fc;
}

.btn {
  display: inline-block;
  font-size: 14px;
  color: #333;
  min-width: 80px;
  height: 30px;
  line-height: 30px;
  padding: 1px 1px;
  margin-right: 10px;
  border: 1px solid #dedede;
  border-radius: 6px;
  background-color: #fff;
  text-align: center;
  white-space: nowrap;
  vertical-align: middle;
  cursor: pointer;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
  outline: none;
  position: relative;
  -webkit-transition: border-color ease-in-out 0.15s,color ease-in-out 0.15s,background ease-in-out 0.15s,-webkit-box-shadow ease-in-out 0.15s;
  transition: border-color ease-in-out 0.15s,color ease-in-out 0.15s,background ease-in-out 0.15s,-webkit-box-shadow ease-in-out 0.15s;
  transition: border-color ease-in-out 0.15s,box-shadow ease-in-out 0.15s,color ease-in-out 0.15s,background ease-in-out 0.15s;
  transition: border-color ease-in-out 0.15s,box-shadow ease-in-out 0.15s,color ease-in-out 0.15s,background ease-in-out 0.15s,-webkit-box-shadow ease-in-out 0.15s;
}

.btn:hover {
  color: #ff8000;
  border-color: #ff8000;
}

.btn.btn-primary {
  background: #ff8000;
  color: #fff;
  border-color: #ff8000;
}

.btn.btn-primary:hover {
  background: #ff6602;
  border-color: #ff6602;
}
</style>
