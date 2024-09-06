import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router'
import Home from '@/views/HomeView.vue'
// import Booking from '@/views/Booking.vue'
import Login from '@/views/LoginPage.vue'
import Register from '@/views/RegisterPage.vue'
import OrdersList from '@/views/OrdersList.vue'
import MyTickets from '@/views/MyTickets.vue'
import Forgot from '@/views/ForgotPasswordPage.vue'
import PaidOrder from '@/views/PaidOrder.vue'
import UnpaidOrder from '@/views/UnpaidOrder.vue'
import WaitOrder from '@/views/WaitOrder.vue'
import TicketsQuestions from '@/views/TicketsQuestions.vue'
import StationPage from '@/views/StationPage.vue'
import Index from '@/views/IndexPage.vue'
<<<<<<< Updated upstream

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
=======
import VerifyIdentityPage from '@/views/VerifyIdentityPage.vue'
import ResetPasswordPage from '@/views/ResetPasswordPage.vue'
import PersonalPage from '@/views/PersonalPage.vue'
// import TicketShow from ''
>>>>>>> Stashed changes

const routes: Array<RouteRecordRaw> = [
  { path: '/', name: 'Home', component: Home },
  { path: '/login', name: 'Login', component: Login },
  { path: '/register', name: 'Register', component: Register },
  { path: '/forgot', name: 'Forgot', component: Forgot },
  { path: '/order', name: 'OrdersList', component: OrdersList },
  { path: '/ticket', name: 'MyTickets', component: MyTickets },
  { path: '/paidOrder', name: 'PaidOrder', component: PaidOrder },
  { path: '/unpaidOrder', name: 'UnpaidOrder', component: UnpaidOrder },
  { path: '/waitOrder', name: 'WaitOrder', component: WaitOrder },
  { path: '/ticketsQuestions', name: 'TicketsQuestions', component: TicketsQuestions },
  { path: '/stationPage', name: 'StationPage', component: StationPage },
<<<<<<< Updated upstream
  { path: '/index', name: 'Index', component: Index }
=======
  { path: '/index', name: 'Index', component: Index },
  { path: '/personal', name: 'PersonalPage', component: PersonalPage, meta: { requiresAuth: true } },
  // { path: '/ticketShow',name: 'TicketShowPage', component: TicketShow}
>>>>>>> Stashed changes
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

// Todo: 添加路由守卫

export default router
