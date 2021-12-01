create table imageurl
(
id int primary key identity(1,1),
img_url varchar(30),
)







create proc geturl
as begin
select * from imageurl
end



exec geturl



create proc addurl @url varchar(30)
as
begin
insert into imageurl (img_url)
select @url
end



