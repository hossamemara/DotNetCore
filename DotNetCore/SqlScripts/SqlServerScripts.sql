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


INSERT INTO [DotNetCore9].dbo.Users(Email,[Password]) VALUES ('esraa.nagah@z2data.com', HASHBYTES('SHA2_512', 'Eng$01128'))

INSERT INTO [DotNetCore9].dbo.UserPermissions(UserId,PermissionId) VALUES (1,1)


SELECT *, LEN(Password) FROM [DotNetCore9].dbo.Users

SELECT * FROM [DotNetCore9].dbo.UserPermissions

