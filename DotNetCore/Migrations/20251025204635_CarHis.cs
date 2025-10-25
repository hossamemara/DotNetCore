using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetCore.Migrations
{
    /// <inheritdoc />
    public partial class CarHis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserPermissions");
        }
    }
}
