import { createRouter, createWebHistory, type RouteRecordRaw} from 'vue-router'
import Home from '../views/Home.vue';
import Login from '../views/Login.vue';
import Booking from '../views/Booking.vue';
import LoginPage from '../views/TestLoginPage.vue';
import RegisterPage from '../views/TestRegisterPage.vue';
import MyTickets from '../views/MyTickets.vue';
import PaidOrder from '../views/PaidOrder.vue';
import UnpaidOrder from '../views/UnpaidOrder.vue';
import WaitOrder from '../views/WaitOrder.vue';
import TrainManagement from '../views/TrainManagement.vue';


// const router = createRouter({
//   history: createWebHistory(import.meta.env.BASE_URL),
//   routes: [
//     {
//       path: '/',
//       name: 'home',
//       component: HomeView
//     },
//     {
//       path: '/about',
//       name: 'about',
//       // route level code-splitting
//       // this generates a separate chunk (About.[hash].js) for this route
//       // which is lazy-loaded when the route is visited.
//       component: () => import('../views/AboutView.vue')
//     }
//   ]
// })

const routes: Array<RouteRecordRaw> = [
  { path: '/', name: 'Home', component: Home },
  { path: '/login', name: 'Login', component: LoginPage },
  { path: '/register', name: 'Register', component: RegisterPage },
  { path: '/booking', name: 'Booking', component: Booking },
  { path: '/ticket', name: 'MyTickets', component: MyTickets },
  { path: '/paidorder', name: 'PaidOrder', component: PaidOrder },
  { path: '/unpaidorder', name: 'UnpaidOrder', component: UnpaidOrder },
  { path: '/waitorder', name: 'WaitOrder', component: WaitOrder },
  { path: '/trainmanagement', name: 'TrainManagement', component: TrainManagement },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router
