-- USE DotNetCore9

-- CREATE DATABASE DotNetCore9


CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[SKU] NVARCHAR(50) NOT NULL UNIQUE
)


INSERT INTO DotNetCore9.dbo.Products(Name,SKU)
VALUES('PC', 'PC123')


SELECT * FROM DotNetCore9.dbo.Products
 
--USE DotNetCore9



CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY(1,1),
[Email] NVARCHAR(100) UNIQUE,
[Password] VARBINARY(128) 
)
GO

CREATE TABLE UserPermissions
(
	UserId INT NOT NULL REFERENCES Users(Id) ON DELETE CASCADE,
	PermissionId INT NOT NULL,
	PRIMARY KEY(UserId,PermissionId)
)
GO


CREATE TABLE UserRoles
(
	UserId INT NOT NULL REFERENCES Users(Id) ON DELETE CASCADE,
	RoleId INT NOT NULL,
	PRIMARY KEY(UserId,RoleId)
)
GO


SELECT * FROM Roles r

INSERT INTO UserRoles(UserId,RoleId)
VALUES(1,1)


INSERT INTO UserRoles(UserId,RoleId)
VALUES(1,2)


SELECT u.Email, r.[Role] FROM Roles r
INNER JOIN UserRoles ur ON r.Id = ur.RoleId
INNER JOIN Users u ON u.Id = ur.UserId
WHERE ur.UserId = 1


INSERT INTO UserRoles(UserId,RoleId)
VALUES(1,1)

SELECT * FROM Users u


UPDATE Users
SET Country = 'Egypt'
WHERE Id = 2

ALTER TABLE Users
ADD Country NVARCHAR(50)


SELECT * FROM UserRoles


CREATE TABLE Roles
(
	
	Id INT PRIMARY KEY IDENTITY(1,1),
	[RoleName] NVARCHAR(50) UNIQUE
)
GO


INSERT INTO Roles
VALUES ('Admin')


INSERT INTO Roles
VALUES ('SuperUser')




SELECT * FROM UserRoles ur



INSERT INTO [DotNetCore9].dbo.Users(Email,[Password]) VALUES ('esraa.nagah@z2data.com', HASHBYTES('SHA2_512', 'Eng$01128'))

INSERT INTO [DotNetCore9].dbo.UserPermissions(UserId,PermissionId) VALUES (1,1)


SELECT *, LEN(Password) FROM [DotNetCore9].dbo.Users

SELECT * FROM [DotNetCore9].dbo.UserPermissions

