# 我的车票目前进度02 (看代码前请看pdf）

### **已完成：**10.点击车票上对应站点后跳转高德地图，显示该站点定位（这个功能做出来后，可以用在其他出现城市名的部分）

### **90%完成：**19.车次管理：管理员可以增、删、改车次信息，包括车次编号、出发时间、到达时间、票价、余票数等（余票数暂时在train表没有，这个需要购票同学调整）

http://localhost:5173/trainmanagement


### **80%完成：**14.查询待支付，已支付，候补订单，本人车票（基础要求完成）

另外20%情况：

1. **订单上还有少数按钮（餐饮，退票，改签等）需要“买票”，“查询”小组同学完成。**
2. **当前我们直接假设当前登录的 `userId` 为 `0001`或`0002`，在订单页面中直接使用这个 `userId` 来获取订单数据，并不是根据当前登录账号决定，需要组长帮忙去完善。**
3. **排版问题**
4. **时间问题**，**因此无法筛选**

**我的车票，略**，没有修改

**我的订单，已经拆分**

候补订单：http://localhost:5173/waitorder



已支付订单：http://localhost:5173/paidorder



未支付订单：http://localhost:5173/unpaidorder
