
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

