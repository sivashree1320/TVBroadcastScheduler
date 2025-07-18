using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVBroadcastScheduler.Migrations
{
    /// <inheritdoc />
    public partial class AddChannelAndCategoryToBroadcast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Channel",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Broadcasts");

            migrationBuilder.DropColumn(
                name: "Channel",
                table: "Broadcasts");
        }
    }
}
