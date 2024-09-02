# 星“济”铁路——铁路票务智能化管理平台（请大家先阅读项目进度）

main分支跟进了9.2日0点的最新进度，记为Version 1（zhc的后端代码将在Version 2）合并

## Version 1已完成：
 - 登录、注册（对应数据库中USERSTEST表，User_ID从1开始递增，密码格式为包含大小写，数字和特殊字符，总长度 > 10，例如Password_123）
 - 其他见GROUP-TICKET-xjb-cljj分支相关说明

## 运行项目

 - 运行前端
   
  ```bash
  npm install
  npm run dev
  ```

 - 运行后端（另一个终端）
  ```bash
  cd DB_Backend // 后端根目录
  dotnet run
  ```
然后前后端可以连通
