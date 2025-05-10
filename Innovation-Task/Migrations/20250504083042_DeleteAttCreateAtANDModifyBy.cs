using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innovation_Task.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAttCreateAtANDModifyBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ModifyAt",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedAt",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyAt",
                table: "Employees",
                type: "int",
                nullable: true);
        }
    }
}
