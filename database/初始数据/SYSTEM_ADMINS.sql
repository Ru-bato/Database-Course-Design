create table ADMINS
(
    ADMIN_ID     VARCHAR2(50)  not null
        primary key,
    USERNAME     VARCHAR2(100) not null,
    PASSWORD     VARCHAR2(100) not null,
    ID_NUMBER    VARCHAR2(18)  not null,
    PHONE_NUMBER VARCHAR2(15)  not null
)
/

INSERT INTO SYSTEM.ADMINS (ADMIN_ID, USERNAME, PASSWORD, ID_NUMBER, PHONE_NUMBER) VALUES ('111', 'ssj', '1', '002', '12345');
INSERT INTO SYSTEM.ADMINS (ADMIN_ID, USERNAME, PASSWORD, ID_NUMBER, PHONE_NUMBER) VALUES ('003', 'xjb', 'string', 'string', 'string');