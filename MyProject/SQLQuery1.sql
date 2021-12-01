create table UserData
(
	id int primary key identity(1,1),
	[Name] varchar(30),
	[Address] varchar(30),
	Email varchar(30),
	Mobile varchar(30)
)
ALTER TABLE UserData
ADD Gender varchar(10)
select * from UserData

alter proc getUser
AS
BEGIN
select * from UserData
END 
exec getUser

alter proc addUser

@Name varchar(30),
@Address nvarchar(30) ,
@Email nvarchar(50), 
@Mobile nvarchar(20),
@Gender nvarchar(10)

as
begin
Insert into UserData([Name],[Address],Email,Mobile,Gender)
select @Name,@Address,@Email,@Mobile,@Gender
end 
exec addUser

alter proc editUser
@id int,
@Name varchar(30),
@Address nvarchar(30) ,
@Email nvarchar(50), 
@Mobile nvarchar(20),
@Gender nvarchar(10)

as
begin
UPDATE UserData
SET
[Name] = @Name,
[Address] = @Address,
Email = @Email,
Mobile = @Mobile,
Gender = @Gender
WHERE  id = @id
end 
exec editUser

