<template>
  <div>
    <h2>Login</h2>
    <form @submit.prevent="login">
      <div>
        <label for="user_id">User ID:</label>
        <input v-model="userId" id="user_id" type="text" required />
      </div>
      <div>
        <label for="password">Password:</label>
        <input v-model="password" id="password" type="password" required />
      </div>
      <button type="submit">Login</button>
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
    const errorMessage = ref('');
    const router = useRouter();

    const login = () => {
      axios.post('http://localhost:5000/api/login', {
        User_ID: userId.value,
        Password: password.value
      })
        .then(response => {
          // Handle successful login
          console.log(response.data);
          router.push('/home'); // Redirect to a home page or dashboard
        })
        .catch(error => {
          // Handle errors
          if (error.response) {
            switch (error.response.status) {
              case 401:
                errorMessage.value = 'Invalid credentials';
                break;
              default:
                errorMessage.value = 'An error occurred';
            }
          }
        });
    };

    return {
      userId,
      password,
      errorMessage,
      login
    };
  }
};
</script>