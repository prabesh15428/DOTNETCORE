create database weather

create table data
(
id int primary key identity(1,1),
location varchar(40),
country varchar(40),
longitude varchar(30),
latitude varchar(30)
)

create proc getdata
as
begin 
select * from data
end

exec getdata

create proc adddata @location varchar(40) , @country varchar(40), @longitude varchar(30), @latitude varchar(30)  
as 
begin 

insert into data(location,country,longitude,latitude)
select @location , @country , @longitude ,@latitude
end 