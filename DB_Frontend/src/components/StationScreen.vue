<template>
  <div class="train-show-box">
  <!-- 车次展示 -->
    <div class="train-result-box">
      <div class="train-result-hd">
      <!-- 表头 -->
        <div class="train-result-titlist titlist-controller">
          <div class="train-number">车次</div>
          <div class="train-station">{{ tableTitle.stationType }}</div>
          <div class="train-time">{{ tableTitle.timeType }}<span class="btn-sort"><i class="sort-top active" attr-code="trainTime"></i><i class="sort-down" attr-code="trainTime"></i></span></div>
          <div class="train-check">{{ tableTitle.checkType }}</div>
          <div class="train-status">状态</div>
        </div>
      </div>

      <div class="train-list-bd">
      <!-- 车次列表 -->
        <div v-for="train in trainList" :key="train.number" class="train-result-item">
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
          <div :class="`train-status-info ${train.status === '停止检票' ? 'train-status-info-red' :
                                            train.status === '正在检票' ? 'train-status-info-green' :
                                            train.status === '正在候车' ? 'train-status-info-gray' : 
                                            train.status === '正点' ? 'train-status-info-green' : 
                                            train.status === '晚点' ? 'train-status-info-red' : ''}`">
          {{ train.status }}</div>
          </div>
        </div>

        <div v-if="!trainList.length" class="no-train" id="no_filter_train">
        <!-- 无结果页面 -->
          <span class="icon">&#xe653;</span>
          <p class="no-train-text">没有查询到符合条件的车次！</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ['tableTitle', 'trainList']
};
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
  display: none;
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
</style>