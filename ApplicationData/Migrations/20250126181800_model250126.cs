using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationData.Migrations
{
    /// <inheritdoc />
    public partial class model250126 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalNameYomi",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "FamilyNameYomi",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "GivenNameYomi",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "YomiName",
                table: "Profiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalNameYomi",
                table: "Profiles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyNameYomi",
                table: "Profiles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GivenNameYomi",
                table: "Profiles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YomiName",
                table: "Profiles",
                type: "TEXT",
                nullable: true);
        }
    }
}
