create table QUESTION
(
    QUESTION_ID     NUMBER         not null
        primary key,
    QUESTION_TEXT   VARCHAR2(1000) not null,
    QUESTION_ANSWER VARCHAR2(1000),
    QUESTION_TYPE   NUMBER
)
/

INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (1, '什么是联程车票？', '联程车票是一种允许旅客在一个车票上完成多个乘车段的车票。它通常用于长途旅行，其中涉及多个不同的起点和终点。例如，从A城市到B城市的旅程可能需要在C城市换乘。联程车票将所有这些乘车段整合为一个票据，使旅客能够一次性购买整个旅程的车票，而无需分别购买每一段的票。这种票据能够简化旅行安排，并有助于节省时间和费用。', 1);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (4, '车票有效期是如何规定的？', '车票的有效期通常由多个因素决定，包括发票日期、旅行日期和车票类型。车票上会注明其有效期，在指定的时间范围内，旅客可以使用该车票乘坐规定的列车或交通工具。不同类型的车票（如单程票、往返票或联程票）可能有不同的有效期规定。例如，一些车票可能要求旅客在购票后的某段时间内使用，或在特定的日期和时间范围内有效。了解车票的有效期对于确保按时出行至关重要。', 1);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (2, '去哪里可以购买车票？', '车票的购买途径包括多种方式。最常见的途径是通过官方网站或手机应用程序进行在线购买。许多铁路公司和公共交通运营商提供了官方的购票平台，方便旅客进行车票查询和购买。此外，车票还可以在车站的售票窗口或自动售票机上购买。对于一些特殊需求或个性化服务的旅客，线下的票务代理和旅行社也是购票的选择之一。', 1);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (3, '如何购买优惠（惠）车票？', '购买优惠车票通常需要关注特定的时间段和条件。例如，很多铁路公司和交通运营商会在特定节假日或旅行淡季提供折扣票。旅客可以通过官方网站或手机应用程序查看优惠信息，了解哪些车次或日期有折扣。同时，许多运营商还会提供会员专属折扣或通过合作伙伴发布的优惠码来享受价格优惠。提早规划旅行并密切关注相关的促销活动可以帮助旅客获取最优惠的票价。', 1);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (5, '为什么有“硬卧代硬座”、“软卧代软座”、“卧代二等座”车票？', '这些车票类型反映了不同的服务和舒适度选项，以满足旅客的多样化需求。例如，“硬卧代硬座”通常表示原本应为硬座的车票可以升级为硬卧的服务，这样旅客在长途旅行中可以享受更高的舒适度。类似地，“软卧代软座”则是将原本的软座车票升级为软卧服务。而“卧代二等座”则表示可以将二等座车票升级为卧铺票。这样的服务选项可以让旅客根据需要选择不同级别的舒适度和价格，优化旅行体验。', 1);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (7, '什么是广深铁路牡丹信用卡？', '广深铁路牡丹信用卡是广深铁路公司联合中国银行推出的一种信用卡。持卡人可以通过这张卡享受各种专属优惠和服务，包括车票购买的积分奖励、折扣优惠、优先服务等。牡丹信用卡还可以用于支付广深铁路及相关合作伙伴的其他消费，如酒店预订和旅行服务。持卡人通常还会获得一系列附加福利，如旅游保险、消费积分兑换等，旨在提升用户的旅行体验和消费便利性。', 1);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (8, '什么是实名制车票？', '实名制车票是指车票上注明了旅客的真实姓名、身份证号码、联系方式等信息，旅客在购票时需提供真实有效的身份证件。', 2);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (9, '如何购买实名制车票？', '实名制车票可以通过官方购票网站、手机应用程序或线下售票点购买。在购票时，需要提供身份证件信息进行实名登记。', 2);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (10, '如何办理实名制车票的退票和改签？', '实名制车票的退票和改签通常需要在购票时使用的身份证件上进行操作。可以通过官方网站、手机应用程序或前往线下售票点办理。', 2);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (11, '怎么样才能确保我的车票信息安全？', '确保车票信息安全的措施包括使用官方购票渠道、定期更换密码、避免在不安全的网络环境中购买车票以及妥善保管身份证件和车票。', 2);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (12, '实名制车票的实施有哪些好处？', '实名制车票可以有效打击黄牛票贩子，提升乘车安全性，同时也有助于管理和统计旅客数据，提升服务质量。', 2);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (13, '如果我忘记带身份证，怎么办？', '如果忘记带身份证，通常无法通过实名制验证登车。建议在出行前确认带齐身份证件，或者联系相关部门询问其他替代方案。', 2);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (14, '什么是报销凭证？', '报销凭证是指用于报销费用时提交的证明文件。它可以包括发票、收据、合同、付款证明等，用于证明支出的真实性和合规性。', 3);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (15, '如何获取报销凭证？', '报销凭证通常由提供服务或销售商品的商家开具。你可以在购买商品或服务时索取发票或收据作为凭证。', 3);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (16, '报销凭证需要哪些信息？', '报销凭证通常需要包括以下信息：开具日期、金额、发票或收据号、商家信息、购买或服务内容等。确保这些信息准确无误，以便顺利进行报销。', 3);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (17, '如果报销凭证丢失了怎么办？', '如果报销凭证丢失，首先应联系相关商家或服务提供者重新开具证明。如果无法重新开具，可能需要提供其他形式的证明文件，如银行对账单或交易记录。', 3);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (18, '怎样确保报销凭证符合财务审核标准？', '确保报销凭证符合财务审核标准，可以做到以下几点：遵循公司报销政策、确保凭证信息完整准确、保留相关的支持文件（如合同或订单）、以及及时提交报销申请。', 3);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (19, '如何购买火车票？', '1.访问铁路公司官方网站或手机应用程序（如12306官网或App）。
2.拨打铁路客服热线（如12306）进行查询。
3.前往火车站的售票窗口或自助售票机查询。
4.使用第三方购票平台（如携程、去哪儿等）。', 4);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (20, '购买火车票时需要准备哪些信息？', '1.身份证件：提供有效身份证件（如身份证、护照等）。
2.出发地和目的地：确定你要前往的城市和站点。
3.乘客信息：包括乘客姓名、身份证号码等。
4.支付信息：用于支付票款的银行卡或其他支付工具。', 4);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (21, '如何取票？', '1.车站自助取票机：使用身份证件和订单号在自助取票机上取票。
2.售票窗口：前往车站的售票窗口，提供身份证件和订单号取票。
3.快递取票：如果选择了快递送票服务，票务公司会将票送到你指定的地址。', 4);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (22, '如何退票和改签?', '1.退票：登录铁路公司官网或应用程序，选择“退票”功能，输入订单号和相关信息，提交退票申请。也可以前往车站售票窗口或自助售票机办理退票。
2.改签：登录铁路公司官网或应用程序，选择“改签”功能，输入订单号和相关信息，选择新的出发时间和列车。改签也可以在车站售票窗口或自助售票机办理。', 4);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (23, '火车票的有效期和使用注意事项是什么？', '1.有效期：火车票一般在购票当天及以后的指定列车上有效，具体有效期可查看票面信息。
2.乘车时间：请务必按时乘车，通常会在发车时间前30分钟到达车站进行检票。
3.身份证件：乘车时需要携带与购票时一致的有效身份证件，以备查验。
4.注意事项：请保管好车票，不要遗失。若遇到票务问题，请及时联系铁路客服或前往车站售票窗口处理。', 4);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (24, '如何申请火车的学生优惠票？', '申请火车的学生优惠票通常需要持有有效的学生证或其他证明文件，并在购票时提供这些证件。在某些国家，你还可能需要在票网站或窗口选择学生票选项并验证学生身份。具体的申请步骤可以参考当地铁路公司或相关售票平台的指南。', 5);
INSERT INTO SYSTEM.QUESTION (QUESTION_ID, QUESTION_TEXT, QUESTION_ANSWER, QUESTION_TYPE) VALUES (6, '什么是中铁银通卡？', '中铁银通卡是由中国国家铁路集团有限公司推出的一种专用购票卡。它是一种预付费卡，旅客可以通过它便捷地购买车票和支付相关费用。持卡人可以在全国范围内的铁路车站使用中铁银通卡进行购票和刷卡支付。这种卡片通常会提供一些额外的优惠或积分奖励，方便频繁旅行的旅客进行积累和兑换。中铁银通卡还可以用于一些车站的自助设备，提升了购票的便捷性和效率。', 1);