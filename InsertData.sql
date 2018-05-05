CREATE VIEW viewInfo AS
select WorkSheet.id , taskId , employeeId , sheetDate , 
	   startingHour , endingHour , 
	   Task.Name as TaskName , project.Name as ProjectName , customer.Name as CustomerName
	   from WorkSheet
inner join Task on WorkSheet.taskId = Task.Id
inner join project on Task.projectId = project.Id 
inner join customer on project.customerId = customer.Id 



--fill customer
INSERT INTO Customer ( Name ) VALUES
( 'Alpha' ), 
( 'Beta' ),
( 'Gamma' )
  
INSERT INTO Project ( Name , customerId) VALUES
( 'Alpha One'  , 1),
( 'Alpha Two'  , 1),
( 'Alpha Three'  , 1), 
( 'Beta One'  , 2),
( 'Beta Two'  , 2),
( 'Beta Three'  , 2), 
( 'Gamma One'  , 3),
( 'Gamma Two'  , 3),
( 'Gamma Three'  , 3)

--select * from Project

INSERT INTO Task ( Name , projectId) VALUES
('Alpha One T1' , 1),
('Alpha One T2' , 1),
('Alpha One T3' , 1),
('Alpha Two T1' , 2),
('Alpha Two T2' , 2),
('Alpha Three T1' , 3),
('Beta One T1' , 4),
('Beta One T2' , 4),
('Beta One T3' , 4),
('Beta Two T1' , 5),
('Beta Two T2' , 5),
('Beta Three T1' , 6),
('Gamma One T1' , 7),
('Gamma One T2' , 7),
('Gamma One T3' , 7),
('Gamma Two T1' , 8),
('Gamma Two T2' , 8),
('Gamma Three T1' , 9),
('Gamma Three T2' , 9),
('Gamma Three T3' , 9),
('Gamma Three T4' , 9),
('Gamma Three T5' , 9),
('Gamma Three T6' , 9),
('Gamma Three T7' , 9),
('Gamma Three T8' , 9),
('Gamma Three T9' , 9)

--select * from task order by id 

--------------------------
--------------------------

insert into Employee (userName , userPassword,firstName , lastName , costPerHour) values
('HW' ,'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 'Hello' , 'World' , 50)

--------------------------
--------------------------
--select * from [dbo].[WorkSheet]

insert into WorkSheet (taskId , employeeId, sheetDate , startingHour , endingHour , comment ) values
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(2 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T2'),
(2 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T2'),
(2 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T2'),
(2 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T2'),
(2 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T2'),
(2 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T2'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1'),
(1 , 1, GETDATE() , '09:00' , '17:00' , 'working on Alpha One T1')

