create table PERSONS
(
    ID      VARCHAR2(10) not null
        primary key,
    NAME    VARCHAR2(50),
    ADDRESS VARCHAR2(100),
    AGE     NUMBER
)
/

INSERT INTO SYSTEM.PERSONS (ID, NAME, ADDRESS, AGE) VALUES ('1', 'Alice', '123 Main St', 30);
INSERT INTO SYSTEM.PERSONS (ID, NAME, ADDRESS, AGE) VALUES ('2', 'Bob', '456 Maple Ave', 25);