<template>
    <div>
      <h2>Register</h2>
      <form @submit.prevent="register">
        <div>
          <label for="user_id">User ID:</label>
          <input v-model="userId" id="user_id" type="text" required />
        </div>
        <div>
          <label for="password">Password:</label>
          <input v-model="password" id="password" type="password" required />
        </div>
        <div>
          <label for="confirm_password">Confirm Password:</label>
          <input v-model="confirmPassword" id="confirm_password" type="password" required />
        </div>
        <button type="submit">Register</button>
      </form>
      <p v-if="errorMessage">{{ errorMessage }}</p>
    </div>
  </template>
  
  <script lang="ts">
  import { ref } from 'vue';
  import axios from 'axios';
  import { useRouter } from 'vue-router';
  
  export default {
    setup() {
      const userId = ref('');
      const password = ref('');
      const confirmPassword = ref('');
      const errorMessage = ref('');
      const router = useRouter();
  
      const register = async () => {
        if (password.value !== confirmPassword.value) {
          errorMessage.value = 'Passwords do not match';
          return;
        }
  
        try {
          const response = await axios.post('http://localhost:5000/api/register', {
            User_ID: userId.value,
            Password: password.value
          });
  
          // Handle successful registration
          console.log(response.data);
          router.push('/login'); // Redirect to login page
        } catch (error: any) {
          // Handle errors
          if (error.response) {
            errorMessage.value = 'An error occurred';
          }
        }
      };
  
      return {
        userId,
        password,
        confirmPassword,
        errorMessage,
        register
      };
    }
  };
  </script>
  