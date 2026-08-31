using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Goalkeeper.Server.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Followup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Flag",
                table: "Teams",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flag",
                table: "Teams");
        }
    }
}
