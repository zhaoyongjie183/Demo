using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFormwork.Migrations
{
    public partial class _201907172325 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogName",
                table: "Blog",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogName",
                table: "Blog");
        }
    }
}
