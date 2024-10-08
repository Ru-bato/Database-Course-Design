import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router'
import Home from '@/views/HomeView.vue'
import Login from '@/views/LoginPage.vue'
import Register from '@/views/RegisterPage.vue'
import MyTickets from '@/views/MyTickets.vue'
import PaidOrder from '@/views/PaidOrder.vue'
import UnpaidOrder from '@/views/UnpaidOrder.vue'
import WaitOrder from '@/views/WaitOrder.vue'
import TicketsQuestions from '@/views/TicketsQuestions.vue'
import StationPage from '@/views/StationPage.vue'
import Index from '@/views/IndexPage.vue'
import VerifyIdentityPage from '@/views/VerifyIdentityPage.vue'
import ResetPasswordPage from '@/views/ResetPasswordPage.vue'
import PersonalPage from '@/views/PersonalPage.vue'
import TickShowPage from '@/views/TickShowPage.vue'
import OrderListPage from '@/views/OrderListPage.vue'
import FoodListPage from '@/views/FoodListPage.vue'
import FoodServerPage from '@/views/FoodServerPage.vue'
import MyFoodPage from '@/views/MyFoodPage.vue'
import BuyTicketsPage from '@/views/BuyTicketsPage.vue'

const routes: Array<RouteRecordRaw> = [
  { path: '/', name: 'Index', component: Index, meta: { requiresAuth: true } },
  { path: '/login', name: 'Login', component: Login },
  { path: '/register', name: 'Register', component: Register },
  { path: '/verifyIdentity', name: 'VerifyIdentity', component: VerifyIdentityPage },
  { path: '/resetPassword', name: 'ResetPassword', component: ResetPasswordPage },
  { path: '/ticket', name: 'MyTickets', component: MyTickets, meta: { requiresAuth: true } },
  { path: '/paidOrder', name: 'PaidOrder', component: PaidOrder, meta: { requiresAuth: true } },
  {
    path: '/unpaidOrder',
    name: 'UnpaidOrder',
    component: UnpaidOrder,
    meta: { requiresAuth: true }
  },
  { path: '/waitOrder', name: 'WaitOrder', component: WaitOrder, meta: { requiresAuth: true } },
  { path: '/ticketsQuestions', name: 'TicketsQuestions', component: TicketsQuestions },
  { path: '/stationPage', name: 'StationPage', component: StationPage },

  {
    path: '/personal',
    name: 'PersonalPage',
    component: PersonalPage,
    meta: { requiresAuth: true }
  },
  { path: '/ticketShow', name: 'TicketShow', component: TickShowPage },
  { path: '/orderList', name: 'OrderList', component: OrderListPage },
  { path: '/foodServer', name: 'FoodServer', component: FoodServerPage },
  { path: '/foodList', name: 'FoodList', component: FoodListPage },
  { path: '/myFood', name: 'MyFood', component:MyFoodPage },
  { path: '/buyTickets', name: 'BuyTickets', component: BuyTicketsPage }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

// 自动注销机制

// 初始化最后活动时间
let lastActivityTime = Date.now()
const IDLE_TIME_LIMIT =  15 * 60 * 1000 // 15分钟

function updateLastActivityTime() {
  lastActivityTime = Date.now()
}

function checkIdleTime() {
  const currentTime = Date.now()
  const timeDifference = currentTime - lastActivityTime

  if (timeDifference > IDLE_TIME_LIMIT) {
    localStorage.removeItem('User_ID')
    localStorage.removeItem('ready_to_reset_User_ID')
    alert('由于长时间未操作，您已被自动注销。请重新登录。')
    return false
  }
  return true
}

// 监听用户活动
window.addEventListener('mousemove', updateLastActivityTime)
window.addEventListener('keydown', updateLastActivityTime)
window.addEventListener('click', updateLastActivityTime)

// 全局前置路由守卫
router.beforeEach((to, from, next) => {
  const isAuthenticated = !!localStorage.getItem('User_ID') // 根据token判断用户是否已登录
  // 检查是否需要登录
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    // 需要登录的页面，检查登录状态和闲置时间
    if (isAuthenticated && checkIdleTime()) {
      // 用户已登录且未超时
      next()
    } else {
      // 用户未登录或已超时
      alert('请先登录或重新登录。')
      localStorage.removeItem('User_ID')
      localStorage.removeItem('ready_to_reset_User_ID')
      next('/login') // 重定向到登录页面
    }
  } else {
    // 不需要登录的页面，直接访问
    next()
  }
})

export default router
