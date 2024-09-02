<template>
  <div class="train-list">
    <h1>火车信息管理</h1>
    <div>
      <h2>火车列表</h2>
      <table>
        <thead>
          <tr>
            <th>火车ID</th>
            <th>出发站</th>
            <th>到达站</th>
            <th>出发时间</th>
            <th>到达时间</th>
            <th>操作</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="train in trains" :key="train.trainId">
            <td>{{ train.trainId }}</td>
            <td>{{ train.departureStation }}</td>
            <td>{{ train.arrivalStation }}</td>
            <td>{{ train.departureTime }}</td>
            <td>{{ train.arriveTime }}</td>
            <td>
              <button class="edit" @click="editTrain(train)">编辑</button>
              <button class="delete" @click="confirmDelete(train.trainId)">删除</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div v-if="editingTrain" class="edit-form-overlay">
      <div class="edit-form">
        <h2>编辑火车</h2>
        <form @submit.prevent="updateTrain">
          <label>火车ID: <input type="text" v-model="editingTrain.trainId" disabled /></label><br />
          <label>出发站: <input type="text" v-model="editingTrain.departureStation" required /></label><br />
          <label>到达站: <input type="text" v-model="editingTrain.arrivalStation" required /></label><br />
          <label>出发时间: <input type="text" v-model="editingTrain.departureTime" required /></label><br />
          <label>到达时间: <input type="text" v-model="editingTrain.arriveTime" required /></label><br />
          <button type="submit" class="update">更新</button>
          <button @click="cancelEdit" class="cancel">取消</button>
        </form>
      </div>
    </div>
    <div>
      <h2>新增火车</h2>
      <form @submit.prevent="addTrain">
        <label>火车ID: <input type="text" v-model="newTrain.trainId" required /></label><br />
        <label>出发站: <input type="text" v-model="newTrain.departureStation" required /></label><br />
        <label>到达站: <input type="text" v-model="newTrain.arrivalStation" required /></label><br />
        <label>出发时间: <input type="text" v-model="newTrain.departureTime" required /></label><br />
        <label>到达时间: <input type="text" v-model="newTrain.arriveTime" required /></label><br />
        <button type="submit" class="add">新增</button>
      </form>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import axios from 'axios';

interface Train {
  trainId: string;
  departureStation: string;
  arrivalStation: string;
  departureTime: string;
  arriveTime: string;
}

export default defineComponent({
  name: 'TrainList',
  setup() {
    const trains = ref<Train[]>([]);
    const editingTrain = ref<Train | null>(null);
    const newTrain = ref<Train>({
      trainId: '',
      departureStation: '',
      arrivalStation: '',
      departureTime: '',
      arriveTime: ''
    });

    const fetchTrains = async () => {
      try {
        const response = await axios.get('http://localhost:5000/api/AdminOrders/GetAllTrain');
        trains.value = response.data;
      } catch (error) {
        console.error('Failed to fetch trains', error);
      }
    };

    const confirmDelete = (trainId: string) => {
      if (window.confirm('确定要删除这条火车信息吗？')) {
        deleteTrain(trainId);
      }
    };

    const deleteTrain = async (trainId: string) => {
      try {
        await axios.delete(`http://localhost:5000/api/AdminOrders/deleteTrain?t_id=${trainId}`);
        fetchTrains();
      } catch (error) {
        console.error('Failed to delete train', error);
      }
    };

    const editTrain = (train: Train) => {
      editingTrain.value = { ...train };
    };

    const updateTrain = async () => {
      if (editingTrain.value) {
        try {
          await axios.put(`http://localhost:5000/api/AdminOrders/updateTrain`, null, {
            params: {
              t_id: editingTrain.value.trainId,
              d_station: editingTrain.value.departureStation,
              a_station: editingTrain.value.arrivalStation,
              d_time: editingTrain.value.departureTime,
              a_time: editingTrain.value.arriveTime,
            },
          });
          fetchTrains();
          editingTrain.value = null;
        } catch (error) {
          console.error('Failed to update train', error);
        }
      }
    };

    const cancelEdit = () => {
      editingTrain.value = null;
    };

    const addTrain = async () => {
      try {
        await axios.post(`http://localhost:5138/api/AdminOrders/AddTrain`, null, {
          params: {
            t_id: newTrain.value.trainId,
            d_station: newTrain.value.departureStation,
            a_station: newTrain.value.arrivalStation,
            d_time: newTrain.value.departureTime,
            a_time: newTrain.value.arriveTime,
          },
        });
        fetchTrains();
        newTrain.value = {
          trainId: '',
          departureStation: '',
          arrivalStation: '',
          departureTime: '',
          arriveTime: ''
        };
      } catch (error) {
        console.error('Failed to add train', error);
      }
    };

    onMounted(() => {
      fetchTrains();
    });

    return {
      trains,
      editingTrain,
      newTrain,
      confirmDelete,
      deleteTrain,
      editTrain,
      updateTrain,
      cancelEdit,
      addTrain,
    };
  },
});
</script>

<style scoped>
.train-list {
  padding: 20px;
  font-family: 'Arial', sans-serif;
}

h1, h2 {
  color: #333;
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-bottom: 20px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

th, td {
  border: 1px solid #ddd;
  padding: 12px;
  text-align: center; /* 文字居中 */
}

th {
  background-color: #f2f2f2;
  font-weight: bold;
}

tr:nth-child(even) {
  background-color: #f9f9f9;
}

tr:hover {
  background-color: #f1f1f1;
}

button {
  padding: 8px 12px;
  margin: 5px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  transition: background-color 0.3s, transform 0.3s;
  font-size: 14px;
  font-weight: bold;
}

button:hover {
  transform: translateY(-2px);
}

button:active {
  transform: translateY(1px);
}

button:focus {
  outline: none;
}

button.edit {
  background-color: #4CAF50;
  color: white;
}

button.delete {
  background-color: #f44336;
  color: white;
}

button.update {
  background-color: #2196F3;
  color: white;
}

button.cancel {
  background-color: #ccc;
  color: #333;
}

button.add {
  background-color: #FF9800;
  color: white;
}

form {
  background-color: #fff;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
}

label {
  display: block;
  margin-bottom: 10px;
  font-weight: bold;
}

input[type="text"] {
  width: 100%;
  padding: 8px;
  margin-top: 4px;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 14px;
}

input[type="text"]:disabled {
  background-color: #f2f2f2;
}

/* 调整特定列的宽度 */
th:nth-child(1), td:nth-child(1) {
  width: 15%; /* 调整火车ID列的宽度 */
}

th:nth-child(2), td:nth-child(2),
th:nth-child(3), td:nth-child(3) {
  width: 25%; /* 调整出发站和到达站列的宽度 */
}

/* 编辑表单的悬浮样式 */
.edit-form-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.edit-form {
  background: #fff;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  width: 400px;
}
</style>