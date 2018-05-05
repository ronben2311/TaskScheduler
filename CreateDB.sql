create database [MatrixTaskDB]


CREATE TABLE Customer
(
id int IDENTITY(1,1) PRIMARY KEY,
name Nvarchar(100)
)

CREATE INDEX ix_nonC_Name
ON Customer (name)

--------------------
--------------------

CREATE TABLE Project
(
id int IDENTITY(1,1) PRIMARY KEY,
name Nvarchar(100),
customerId int FOREIGN KEY REFERENCES Customer(Id)
)

create INDEX ix_nonC_NameCusid
ON Project (name , customerId)

----------------------
----------------------

CREATE TABLE Task
(
id int IDENTITY(1,1) PRIMARY KEY,
name Nvarchar(100),
projectId int FOREIGN KEY REFERENCES Project(Id)
)

CREATE INDEX ix_nonC_NameProjid
ON Task (name , projectId)

---------------------
---------------------

CREATE TABLE Employee
(
id int IDENTITY(1,1) PRIMARY KEY,
userName Nvarchar(100),
userPassword Nvarchar(200), -- can be guid
firstName Nvarchar(100),
lastName Nvarchar(100),
costPerHour int 
)

CREATE INDEX ix_nonC_UidUpass
ON Employee (userName , userPassword)

-----------------------
-----------------------

CREATE TABLE WorkSheet
(
Id int IDENTITY(1,1) PRIMARY KEY,
taskId int FOREIGN KEY REFERENCES Task(Id),
employeeId int FOREIGN KEY REFERENCES Employee(Id),
sheetDate DATE,
startingHour TIME,
endingHour TIME,
comment Nvarchar(max) 
)

CREATE INDEX ix_nonC_TidEid
ON WorkSheet (taskId , employeeId)





