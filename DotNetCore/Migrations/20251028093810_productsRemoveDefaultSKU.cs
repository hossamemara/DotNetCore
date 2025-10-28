using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetCore.Migrations
{
    /// <inheritdoc />
    public partial class productsRemoveDefaultSKU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionUser",
                table: "PermissionUser");

            migrationBuilder.DropIndex(
                name: "IX_PermissionUser_UsersId",
                table: "PermissionUser");

            migrationBuilder.AlterColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "123");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser",
                columns: new[] { "UsersId", "RolesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionUser",
                table: "PermissionUser",
                columns: new[] { "UsersId", "PermissionsId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_RolesId",
                table: "RoleUser",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUser_PermissionsId",
                table: "PermissionUser",
                column: "PermissionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_RoleUser_RolesId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionUser",
                table: "PermissionUser");

            migrationBuilder.DropIndex(
                name: "IX_PermissionUser_PermissionsId",
                table: "PermissionUser");

            migrationBuilder.AlterColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "123",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionUser",
                table: "PermissionUser",
                columns: new[] { "PermissionsId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUser_UsersId",
                table: "PermissionUser",
                column: "UsersId");
        }
    }
}
