# Oracle说明文档

## 1. 需要添加的表

### 1.1 ADMINS表

根据你提供的建表语句，下面是 `ADMINS` 表的结构描述：

| 列名           | 数据类型        | 约束                      | 描述               |
| -------------- | --------------- | ------------------------- | ------------------ |
| `ADMIN_ID`     | `VARCHAR2(50)`  | `PRIMARY KEY`, `NOT NULL` | 管理员的唯一标识符 |
| `USERNAME`     | `VARCHAR2(100)` | `NOT NULL`                | 管理员的用户名     |
| `PASSWORD`     | `VARCHAR2(100)` | `NOT NULL`                | 管理员的密码       |
| `ID_NUMBER`    | `VARCHAR2(18)`  | `NOT NULL`                | 管理员的身份证号码 |
| `PHONE_NUMBER` | `VARCHAR2(15)`  | `NOT NULL`                | 管理员的电话号码   |

 说明：

- **`ADMIN_ID`**：主键，唯一标识每个管理员。
- **`USERNAME`**：管理员的用户名，用于登录或识别。
- **`PASSWORD`**：管理员的密码，存储管理员的认证信息。
- **`ID_NUMBER`**：管理员的身份证号码，用于身份验证或记录。
- **`PHONE_NUMBER`**：管理员的电话号码，用于联系管理员。



### 1.2 FOOD表

| 列名        | 数据类型        | 约束                      | 描述             |
| ----------- | --------------- | ------------------------- | ---------------- |
| `FOOD_ID`   | `VARCHAR2(255)` | `PRIMARY KEY`, `NOT NULL` | 食品的唯一标识符 |
| `FOOD_NAME` | `VARCHAR2(255)` | 无                        | 食品名称         |
| `PRICE`     | `NUMBER`        | 无                        | 食品价格         |

说明：

- **`FOOD_ID`**：主键，唯一标识每种食品。
- **`FOOD_NAME`**：食品的名称。
- **`PRICE`**：食品的价格。



### 1.3 ORDERLIST表

| 列名           | 数据类型       | 约束                      | 描述             |
| -------------- | -------------- | ------------------------- | ---------------- |
| `ORDER_ID`     | `VARCHAR2(20)` | `PRIMARY KEY`, `NOT NULL` | 订单的唯一标识符 |
| `USER_ID`      | `VARCHAR2(20)` | 无                        | 用户的唯一标识符 |
| `TRAIN_ID`     | `VARCHAR2(20)` | 无                        | 列车的唯一标识符 |
| `ORDER_STATUS` | `VARCHAR2(20)` | 无                        | 订单状态         |
| `PRICE`        | `NUMBER`       | 无                        | 订单价格         |
| `TICKET_TYPE`  | `VARCHAR2(20)` | 无                        | 票种类型         |
| `PASSENGER_ID` | `VARCHAR2(20)` | 无                        | 乘客的唯一标识符 |

说明：

- **`ORDER_ID`**：主键，唯一标识每个订单。
- **`USER_ID`**：用户的唯一标识符。
- **`TRAIN_ID`**：列车的唯一标识符。
- **`ORDER_STATUS`**：订单的状态信息（包括已支付“paid”,未支付“unpaid”和候补“wait”共3种状态）。
- **`PRICE`**：订单的价格。
- **`TICKET_TYPE`**：票的类型。
- **`PASSENGER_ID`**：乘客的唯一标识符。



### 1.4 PASSENGERS表

| 列名             | 数据类型        | 约束                      | 描述             |
| ---------------- | --------------- | ------------------------- | ---------------- |
| `PASSENGER_ID`   | `VARCHAR2(20)`  | `NOT NULL`, `PRIMARY KEY` | 乘客的唯一标识符 |
| `USER_ID`        | `VARCHAR2(255)` | `NOT NULL`                | 用户的唯一标识符 |
| `PASSENGER_NAME` | `VARCHAR2(20)`  | `NOT NULL`                | 乘客的姓名       |
| `ID_NUMBER`      | `VARCHAR2(255)` | 无                        | 乘客的身份证号码 |

说明：

- **`PASSENGER_ID`**：主键，唯一标识每位乘客。
- **`USER_ID`**：用户的唯一标识符，用于关联乘客与用户。
- **`PASSENGER_NAME`**：乘客的姓名。
- **`ID_NUMBER`**：乘客的身份证号码，用于身份验证或记录。



### 1.5 PERSONS表

| 列名      | 数据类型        | 约束                      | 描述             |
| --------- | --------------- | ------------------------- | ---------------- |
| `ID`      | `VARCHAR2(10)`  | `NOT NULL`, `PRIMARY KEY` | 个人的唯一标识符 |
| `NAME`    | `VARCHAR2(50)`  | 无                        | 个人的姓名       |
| `ADDRESS` | `VARCHAR2(100)` | 无                        | 个人的地址       |
| `AGE`     | `NUMBER`        | 无                        | 个人的年龄       |

说明：

- **`ID`**：主键，唯一标识每个人。
- **`NAME`**：个人的姓名。
- **`ADDRESS`**：个人的地址。
- **`AGE`**：个人的年龄。



### 1.6 QUESTION表

| 列名              | 数据类型         | 约束                      | 描述                                 |
| ----------------- | ---------------- | ------------------------- | ------------------------------------ |
| `QUESTION_ID`     | `NUMBER`         | `NOT NULL`, `PRIMARY KEY` | 问题的唯一标识符                     |
| `QUESTION_TEXT`   | `VARCHAR2(1000)` | `NOT NULL`                | 问题的文本内容                       |
| `QUESTION_ANSWER` | `VARCHAR2(1000)` | 无                        | 问题的答案                           |
| `QUESTION_TYPE`   | `NUMBER`         | 无                        | 问题的类型（可能表示不同的问答类型） |

说明：

- **`QUESTION_ID`**：主键，唯一标识每个问题。
- **`QUESTION_TEXT`**：存储问题的文本内容，不能为空。
- **`QUESTION_ANSWER`**：存储问题的答案，可以为空。
- **`QUESTION_TYPE`**：用于标识问题的类型，（如1代表“车票类型”相关问题，2代表“购票类型”相关问题等）。



### 1.7 STATION表

| 列名           | 数据类型       | 约束                      | 描述             |
| -------------- | -------------- | ------------------------- | ---------------- |
| `STATION_ID`   | `VARCHAR2(20)` | `NOT NULL`, `PRIMARY KEY` | 车站的唯一标识符 |
| `STATION_NAME` | `VARCHAR2(20)` | 无                        | 车站的名称       |

说明：

- **`STATION_ID`**：主键，唯一标识每个车站。
- **`STATION_NAME`**：车站的名称。



### 1.8 TRAIN表

| 列名                | 数据类型       | 约束                      | 描述             |
| ------------------- | -------------- | ------------------------- | ---------------- |
| `TRAIN_ID`          | `VARCHAR2(20)` | `NOT NULL`, `PRIMARY KEY` | 列车的唯一标识符 |
| `DEPARTURE_STATION` | `VARCHAR2(20)` | 无                        | 出发车站         |
| `ARRIVAL_STATION`   | `VARCHAR2(20)` | 无                        | 到达车站         |
| `DEPARTURE_TIME`    | `VARCHAR2(20)` | 无                        | 出发时间         |
| `ARRIVAL_TIME`      | `VARCHAR2(20)` | 无                        | 到达时间         |
| `PRICE`             | `NUMBER`       | `DEFAULT 0`               | 票价             |
| `REMAINING_TICKETS` | `NUMBER`       | `DEFAULT 0`               | 剩余票数         |

说明：

- **`TRAIN_ID`**：主键，唯一标识每列车。
- **`DEPARTURE_STATION`** 和 **`ARRIVAL_STATION`**：表示列车的出发和到达车站。
- **`DEPARTURE_TIME`** 和 **`ARRIVAL_TIME`**：列车的出发和到达对应站的时间。
- **`PRICE`** 和 **`REMAINING_TICKETS`**：分别表示票价和剩余票数。



### 1.9 TRAINSTATION表

| 列名                  | 数据类型                 | 约束                             | 描述                                |
| --------------------- | ------------------------ | -------------------------------- | ----------------------------------- |
| `STATION_ID`          | `VARCHAR2(20)`           | `NOT NULL`, `REFERENCES STATION` | 外键，引用 `STATION` 表的车站标识符 |
| `TRAIN_ID`            | `VARCHAR2(20)`           | `NOT NULL`, `REFERENCES TRAIN`   | 外键，引用 `TRAIN` 表的列车标识符   |
| `ARRIVAL_TIME`        | `VARCHAR2(20)`           | 无                               | 到达时间                            |
| `DEPARTURE_TIME`      | `VARCHAR2(20)`           | 无                               | 出发时间                            |
| `TRAIN_ENTRANCE`      | `VARCHAR2(20)`           | 无                               | 列车进入车站的站台或入口信息        |
| `TRAIN_EXIT`          | `VARCHAR2(20)`           | 无                               | 列车离开车站的站台或出口信息        |
| `DEPART_TRAIN_STATUS` | `VARCHAR2(20)`           | 无                               | 列车离开车站时的状态                |
| `ARRIVE_TRAIN_STATUS` | `VARCHAR2(20)`           | 无                               | 列车到达车站时的状态                |
| `PRIMARY KEY`         | `(STATION_ID, TRAIN_ID)` | 组合主键                         | 车站和列车的唯一组合标识符          |

说明：

- **`STATION_ID`** 和 **`TRAIN_ID`**：外键，分别引用 `STATION` 表和 `TRAIN` 表，确保车站和列车的存在性。
- **`ARRIVAL_TIME`** 和 **`DEPARTURE_TIME`**：表示列车在该车站的到达和出发时间。
- **`TRAIN_ENTRANCE`** 和 **`TRAIN_EXIT`**：提供列车在车站的检票口和出站口信息（如A1,B2）。
- **`DEPART_TRAIN_STATUS`** 和 **`ARRIVE_TRAIN_STATUS`**：记录列车在车站时的状态信息。



### 1.10 USERTEST表

| 列名              | 数据类型        | 约束                      | 描述                                          |
| ----------------- | --------------- | ------------------------- | --------------------------------------------- |
| `USER_ID`         | `VARCHAR2(50)`  | `NOT NULL`, `PRIMARY KEY` | 用户的唯一标识符                              |
| `USERNAME`        | `VARCHAR2(100)` | `NOT NULL`                | 用户名                                        |
| `PASSWORD`        | `VARCHAR2(100)` | `NOT NULL`                | 密码                                          |
| `IS_STUDENT`      | `CHAR`          | 无                        | 是否为学生 (通常是 'Y' 或 'N')                |
| `STATUS`          | `CHAR`          | `NOT NULL`                | 用户状态 (例如，'A' 表示激活，'I' 表示未激活) |
| `ID_NUMBER`       | `VARCHAR2(18)`  | `UNIQUE`                  | 身份证号，必须唯一                            |
| `PHONE_NUMBER`    | `VARCHAR2(100)` | `NOT NULL`, `UNIQUE`      | 电话号码，必须唯一                            |
| `RIDING_INTERVAL` | `VARCHAR2(20)`  | 无                        | 乘车间隔                                      |

说明：

- **`USER_ID`**：主键，唯一标识每个用户。
- **`USERNAME`** 和 **`PASSWORD`**：用户的登录名和密码。
- **`IS_STUDENT`**：标识用户是否为学生，通常用单个字符表示。
- **`STATUS`**：用户的状态，标识账户的激活状态或其他信息。
- **`ID_NUMBER`** 和 **`PHONE_NUMBER`**：分别是身份证号和电话号码，均需唯一。
- **`RIDING_INTERVAL`**：记录用户的乘车间隔信息。



## 2.建表语句

​         所有建表语句以及插入语句都已经提供在`sql`文件夹中，如`SYSTEM_ADMINS.sql`中包含建表语句和相应的插入sql语句。

​         如果要运行程序，应该执行`sql`文件夹中提供的所有`sql`文件中的建表和插入语句。

