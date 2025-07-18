using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TVBroadcastScheduler.Migrations
{
    /// <inheritdoc />
    public partial class SeedBroadcastsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Channel",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovalComment",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Broadcasts",
                columns: new[] { "Id", "ApprovalComment", "Category", "Channel", "CreatedBy", "Description", "EndTime", "StartTime", "Status", "Title" },
                values: new object[,]
                {
                    { 1, null, "Daily", "BBC News", "scheduler", "Start your day with fresh updates and music.", new DateTime(2025, 7, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 20, 7, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "English Morning Show" },
                    { 2, null, "Daily", "CNN", "scheduler", "World economy & stock news.", new DateTime(2025, 7, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Business Buzz" },
                    { 3, null, "Daily", "Discovery", "scheduler", "Latest in gadgets and innovation.", new DateTime(2025, 7, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Tech Talk Live" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Broadcasts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Broadcasts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Broadcasts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Channel",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovalComment",
                table: "Broadcasts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
