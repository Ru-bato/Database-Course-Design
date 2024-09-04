# 个人界面设计

前后端已完成连接，由于测试需要登录功能（主要是需要本地user_id），在与项目合并后再进行测试。

前端包括components与views两部分，在`\src\router\index.ts`中添加：

```typescript
import PersonalPage from '@/views/PersonalPage.vue'
```

并在路径中添加：

```typescript
{ path: '/personal', name: 'PersonalPage', component: PersonalPage}
```

