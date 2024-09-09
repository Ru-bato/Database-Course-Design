<template>
  <div>
    <h3>用户管理</h3>
    <button @click="showAddUserModal = true">添加用户</button>
    <table>
      <thead>
        <tr>
          <th>ID</th>
          <th>名称</th>
          <th>状态</th>
          <th>操作</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in sortedUsers" :key="user.User_ID">
          <td>{{ user.user_ID }}</td>
          <td>{{ user.username }}</td>
          <td>{{ user.status ? '正常' : '封禁' }}</td>
          <td>
            <button @click="editUser(user)">编辑</button>
            <button @click="deleteUser(user.User_ID)">删除</button>
            <button @click="toggleUserStatus(user)">{{ user.Status ? '封禁' : '解封' }}</button>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- 添加用户模态框 -->
    <div v-if="showAddUserModal" class="modal">
      <div class="modal-content">
        <h4>添加新用户</h4>
        <label>ID:</label>
        <input v-model="newUser.User_ID" placeholder="输入用户ID">
        <br>
        <label>名称:</label>
        <input v-model="newUser.Username" placeholder="输入用户名称">
        <br>
        <label>身份证号:</label>
        <input v-model="newUser.Id_number" placeholder="输入身份证号">
        <br>
        <label>手机号:</label>
        <input v-model="newUser.Phone_number" placeholder="输入手机号">
        <br>
        <label>密码:</label>
        <input type="password" v-model="newUser.Password" placeholder="输入密码">
        <br>
        <label>是否学生:</label>
        <input type="checkbox" v-model="newUser.Is_student">
        <br>
        <label>乘车区间:</label>
        <input v-model="newUser.Riding_interval" placeholder="输入乘车区间">
        <div>
          <button @click="createUser">保存</button>
          <button @click="showAddUserModal = false">取消</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, computed } from 'vue';
import axios from 'axios';

// 定义用户接口
interface User {
  User_ID: string;
  Username: string;
  Password: string;
  Id_number: string;
  Phone_number: string;
  Is_student?: boolean;
  Status?: boolean;
  Riding_interval?: string;
}

export default defineComponent({
  name: 'UserManagement',
  setup() {
    const users = ref<User[]>([]);
    const showAddUserModal = ref<boolean>(false);
    const newUser = ref<User>({
      User_ID: '',
      Username: '',
      Password: '',
      Id_number: '',
      Phone_number: '',
      Is_student: undefined,
      Status: true,
      Riding_interval: undefined,
    });

    // 计算属性返回排序后的用户列表
    const sortedUsers = computed(() => {
      return [...users.value].sort((a, b) => a.user_ID - b.user_ID);
    });

    const fetchUsers = async () => {
      try {
        //每次获取用户列表清空users数组避免重复
        users.value=[];
        const response = await axios.get<string[]>('http://localhost:5000/api/Admin/GetAllUserIds');
        console.log(response.data);
        const userIds = response.data;
        userIds.forEach(id => getUser(id));
      } catch (error) {
        console.error("获取用户ID失败：", error);
      }
    };

    const getUser = async (id: string) => {
      try {
        const response = await axios.get<{ User: User }>(`http://localhost:5000/api/User/GetUser/${id}`);
        console.log(response);
        const user = response.data.user;
        users.value.push(user);
        console.log(users);
      } catch (error) {
        console.error("获取用户信息失败：", error);
      }
    };

    const createUser = async () => {
      try {
        const response = await axios.post<string>('http://localhost:5000/api/User/CreateUser', newUser.value);
        alert('用户添加成功！');
        showAddUserModal.value = false; // 关闭模态框
        fetchUsers(); // 重新加载用户信息
      } catch (error) {
        console.error("添加用户失败：", error);
      }
    };

    const toggleUserStatus = async (user: User) => {
      const newStatus = !user.Status;
      try {
        const response = await axios.put<string>(`http://localhost:5000/api/Admin/ProhibitUserLogin/${user.User_ID}`, null, { params: { status: newStatus } });
        alert('用户状态修改成功！');
        user.Status = newStatus; // 更新前端状态
      } catch (error) {
        console.error("修改用户状态失败：", error);
      }
    };

    const editUser = async (user: User) => {
      try {
        const response = await axios.put<string>('http://localhost:5000/api/Admin/UpdateUser', user);
        alert('用户信息修改失败！');
        fetchUsers();
      } catch (error) {
        console.error("修改用户信息失败：", error);
      }
    };

    const deleteUser = async (userId: string) => {
      try {
        const response = await axios.delete<string>(`http://localhost:5000/api/Admin/DeleteUser/${userId}`);
        alert('用户删除成功！');
        fetchUsers();
      } catch (error) {
        console.error("删除用户失败：", error);
      }
    };

    // 在组件创建时加载用户数据
    fetchUsers();

    return {
      users,
      showAddUserModal,
      newUser,
      sortedUsers,
      createUser,
      toggleUserStatus,
      editUser,
      deleteUser
    };
  },
});
</script>

<style scoped>
.modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal-content {
  background-color: white;
  padding: 20px;
  border-radius: 5px;
  width: 300px;
}
</style>
