using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationData.Migrations
{
    /// <inheritdoc />
    public partial class model250123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNormal",
                table: "Profiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNormal",
                table: "Profiles");
        }
    }
}
