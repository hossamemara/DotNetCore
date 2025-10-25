using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetCore.Migrations
{
    /// <inheritdoc />
    public partial class MaxRangeSKU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "123",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "123");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "123",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "123");
        }
    }
}
