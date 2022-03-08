using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_13.Migrations
{
    public partial class CourseUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DegreeType",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegreeType",
                table: "Courses");
        }
    }
}
