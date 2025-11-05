
INSERT INTO [DotNetCoreEF9].dbo.Users(Email,Country,[Password]) VALUES ('hossam.emara@example.com','USA', HASHBYTES('SHA2_512', 'Eng$01128'))


TRUNCATE TABLE [DotNetCoreEF9].dbo.Permission

INSERT INTO [DotNetCoreEF9].dbo.Permission(PermissionName)
VALUES ('ReadProduct')

INSERT INTO [DotNetCoreEF9].dbo.Permission(PermissionName)
VALUES ('AddProduct')

INSERT INTO [DotNetCoreEF9].dbo.Permission(PermissionName)
VALUES ('UpdateProduct')

INSERT INTO [DotNetCoreEF9].dbo.Permission(PermissionName)
VALUES ('DeleteProduct')



INSERT [DotNetCoreEF9].dbo.RoleUser(UsersId,RolesId)
VALUES (1,1)



INSERT [DotNetCoreEF9].dbo.PermissionUser(UsersId,PermissionsId)
VALUES (1,1)


INSERT [DotNetCoreEF9].dbo.Products(Name,Sku)
VALUES ('Laptop','Laptop_123')



INSERT [DotNetCoreEF9].dbo.[OrderNew](Amount)
VALUES (1000)

SELECT * FROM [DotNetCoreEF9].dbo.[Orders]


SELECT * FROM [DotNetCoreEF9].dbo.[OrdersNew]




