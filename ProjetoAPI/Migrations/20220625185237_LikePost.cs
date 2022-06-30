using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAPI.Migrations
{
    public partial class LikePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Like",
                table: "Posts");
        }
    }
}
