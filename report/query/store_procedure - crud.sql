INSERT:
CREATE PROCEDURE AddData(
@first_name VARCHAR(50),
@last_name VARCHAR(50),
@phone VARCHAR(50),
@username VARCHAR(50),
@email VARCHAR(50),
@password VARCHAR(50))
AS
BEGIN
insert into reg_info 
values ( @first_name, @last_name, @phone, @username, @email, @password )
END



UPDATE:
CREATE PROCEDURE UpdateData(
@id int,
@first_name VARCHAR(50),
@last_name VARCHAR(50),
@phone VARCHAR(50),
@username VARCHAR(50),
@email VARCHAR(50),
@password VARCHAR(50))
AS
BEGIN
UPDATE reg_info
SET
first_name = @first_name,
last_name = @last_name,
phone = @phone,
username = @username,
email = @email,
password = @password
where id = @id
END


SELECT:
CREATE PROCEDURE SelectData
AS
BEGIN
select * from reg_info
END


DELETE:
CREATE PROCEDURE DeleteData
(@id int)
AS
BEGIN
DELETE FROM reg_info
WHERE id = @id
END