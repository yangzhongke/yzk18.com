using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Articles.Infrastructure.Migrations
{
    public partial class RemoveMultiLang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body_Chinese",
                table: "T_Articles");

            migrationBuilder.DropColumn(
                name: "Body_English",
                table: "T_Articles");

            migrationBuilder.DropColumn(
                name: "Title_Chinese",
                table: "T_Articles");

            migrationBuilder.DropColumn(
                name: "Title_English",
                table: "T_Articles");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "T_Articles",
                type: "longtext",
                maxLength: 1048576,
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "T_Articles",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "T_Articles");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "T_Articles");

            migrationBuilder.AddColumn<string>(
                name: "Body_Chinese",
                table: "T_Articles",
                type: "longtext",
                maxLength: 1048576,
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Body_English",
                table: "T_Articles",
                type: "longtext",
                maxLength: 1048576,
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title_Chinese",
                table: "T_Articles",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title_English",
                table: "T_Articles",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
