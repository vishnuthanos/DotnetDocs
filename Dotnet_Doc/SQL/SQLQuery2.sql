

  create table EmpDup(empid int,name varchar(20))

    insert into EmpDup values(1,'Andy')
    insert into EmpDup values (1,'Andy')
	 insert into EmpDup values (6,'Andy')
	insert into EmpDup values (4,'vishnu')
    insert into EmpDup values (2,'Chris')
    insert into EmpDup values(3,'Bill')
    insert into EmpDup values(3,'Bill')
    insert into EmpDup values (3,'Bill')       
    

	drop table EmpDup

 With CTE_Duplicates as
   (select name , row_number() over(partition by name order by name ) rownumber 
   from EmpDup  )
   delete from CTE_Duplicates where rownumber!=1

   select * from empdup

   with cte_vishnu as
   (select name ,ROW_NUMBER() over(partition by name order by name ) r from empdup )
   delete from cte_vishnu where r!=1
   ---------------------------------------------------------------------------------
select * from Employees 
------------ nth salary using top ---------------------------------
select top 1 salary from
(
select distinct top 2 salary from employees order by salary desc 
)
result 
order by salary
-------------------nth salary using cte-----------------------------
with resultcte as
(select  salary ,DENSE_RANK() over (order by salary desc) as d
from Employees
)
select top 1 salary from resultcte where d = 2
-----------------------------------------------------------------------
Select *, ROW_NUMBER() over(partition by salary order by salary ) as rownumber from Employees 
Select *, rank() over(partition by salary order by salary ) as rownumber from Employees 
Select *, dense_rank() over(partition by salary order by salary ) as rownumber from Employees 
---------------------------------------------------------------------------------------------
Select *, ROW_NUMBER() over( order by salary ) as rownumber,
rank() over(order by  salary ) as rank1 ,
 dense_rank() over( order by salary ) as denserank
from Employees 
----------------------------------------------------------------------------------------------
Create table Employees
(
     ID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     Salary int
)
GO


Insert into Employees values ('Ben', 'Hoskins', 'Male', 70000)
Insert into Employees values ('Mark', 'Hastings', 'Male', 60000)
Insert into Employees values ('Steve', 'Pound', 'Male', 45000)
Insert into Employees values ('Ben', 'Hoskins', 'Male', 70000)
Insert into Employees values ('Philip', 'Hastings', 'Male', 45000)
Insert into Employees values ('Mary', 'Lambeth', 'Female', 30000)
Insert into Employees values ('Valarie', 'Vikings', 'Female', 35000)
Insert into Employees values ('John', 'Stanmore', 'Male', 80000)
GO
----------------------------------------------------------------------------------------------------







