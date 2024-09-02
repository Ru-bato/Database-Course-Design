<template>
    <div>
      <h3>用户管理</h3>
      <!-- 用户管理的具体内容 -->
      <button @click="addUser">添加用户</button>
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
      <!-- 添加用户和编辑用户的模态框可以根据需要添加 -->
    </div>
  </template>
  
  <script>
  export default {
    name: 'UserManagement',
    data() {
      return {
        users: [], // 从后端获取用户数据
      };
    },
    methods: {
      addUser() {
        // 添加用户逻辑
      },
      editUser(user) {
        // 编辑用户逻辑
      },
      deleteUser(userId) {
        // 删除用户逻辑
      },
    },
  };
  </script>
  
  <style scoped>
  /* 添加样式 */
  </style>
  