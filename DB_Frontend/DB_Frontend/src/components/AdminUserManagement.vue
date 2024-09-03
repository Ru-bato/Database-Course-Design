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
        <tr v-for="user in users" :key="user.id">
          <td>{{ user.id }}</td>
          <td>{{ user.name }}</td>
          <td>{{ user.active ? '激活' : '禁用' }}</td>
          <td>
            <button @click="editUser(user)">编辑</button>
            <button @click="deleteUser(user.id)">删除</button>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- 添加用户模态框 -->
    <div v-if="showAddUserModal" class="modal">
      <div class="modal-content">
        <h4>添加新用户</h4>
        <label>ID:</label>
        <input v-model="newUser.User_id" placeholder="输入用户ID">
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
        <div>
          <button @click="createUser">保存</button>
          <button @click="showAddUserModal = false">取消</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'UserManagement',
  data() {
    return {
      users: [],
      showAddUserModal: false, // 控制模态框显示
      newUser: {
        User_id: '',
        Username: '',
        Password: '',
        Id_number: '',
        Phone_number: '',
      },
    };
  },
  created() {
    this.fetchUsers();
  },
  methods: {
    fetchUsers() {
      axios.get('http://localhost:5000/api/Admin/GetAllUserIds')
        .then(response => {
          const userIds = response.data;
          userIds.forEach(id => {
            this.getUser(id);
          });
        })
        .catch(error => {
          console.error("获取用户ID失败：", error);
        });
    },
    getUser(id) {
      axios.get(`http://localhost:5000/api/User/GetUser/${id}`)
        .then(response => {
          const user = response.data.User;
          user.active = !response.data.IsAdmin;
          this.users.push(user);
        })
        .catch(error => {
          console.error("获取用户信息失败：", error);
        });
    },
    createUser() {
      axios.post('http://localhost:5000/api/User/CreateUser', this.newUser)
        .then(response => {
          alert(response.data);
          this.showAddUserModal = false; // 关闭模态框
          this.fetchUsers(); // 重新加载用户信息
        })
        .catch(error => {
          console.error("添加用户失败：", error);
        });
    },
    editUser(user) {
      axios.put('http://localhost:5000/api/Admin/UpdateUser', user)
        .then(response => {
          alert(response.data);
          this.fetchUsers();
        })
        .catch(error => {
          console.error("修改用户信息失败：", error);
        });
    },
    deleteUser(userId) {
      axios.delete(`http://localhost:5000/api/Admin/DeleteUser/${userId}`)
        .then(response => {
          alert(response.data);
          this.fetchUsers();
        })
        .catch(error => {
          console.error("删除用户失败：", error);
        });
    },
  },
};
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
