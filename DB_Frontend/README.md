# 前端简要说明

## 请注意，此说明在项目初期编写，随着项目进行，并未对其更新，因此其内容仅供参考

## 目录结构

```
frontend/
├── public/                 # 静态资源
├── src/
│   ├── assets/             # 资源文件（图片、样式等）
│   ├── components/         # 通用组件
│   ├── router/             # 路由配置
│   ├── store/              # Vuex 状态管理
│   ├── views/              # 页面视图
│   ├── styles/             # 全局样式（暂不设置，有需要再添加）
│   ├── utils/              # 工具函数
│   ├── App.vue             # 主组件
│   ├── main.ts             # 入口文件
│   └── shims-vue.d.ts      # 类型声明（暂不设置，有需要再添加）
└── package.json            # 项目依赖
```

## 命名约定

### 文件和目录

- 组件文件：采用 PascalCase，例如 `MyComponent.vue`
- 视图文件：采用 PascalCase，例如 `HomePage.vue`
- 样式文件：采用 kebab-case，例如 `main-header.scss`
- 工具函数：采用 camelCase，例如 `formatDate.ts`

### 变量和函数

- 变量：采用 camelCase，例如 `userName`
- 常量：采用 UPPER_SNAKE_CASE，例如 `MAX_ITEMS`
- 函数：采用 camelCase，例如 `fetchData()`

## 代码风格

### 代码缩进

- 使用 2 个空格进行缩进

### 分号（CSS和Typescript）

- 每行语句结束时使用分号

### 引号

- TypeScript 中使用单引号，HTML 属性中使用双引号

### 空行

- 文件末尾保留一个空行
- 不同逻辑块之间使用空行分隔

### 注释

- 项目中各种信息均用中文（这是老师的要求）
- 因此自己写的注释请用中文，gpt生成的注释随意，尽量中文
