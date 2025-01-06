using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warhammer40KFanSite.Migrations
{
    public partial class UserChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoryAuthor",
                table: "Stories");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "AccountAge",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StoryAuthorUserId",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stories_StoryAuthorUserId",
                table: "Stories",
                column: "StoryAuthorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Users_StoryAuthorUserId",
                table: "Stories",
                column: "StoryAuthorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Users_StoryAuthorUserId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_StoryAuthorUserId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "StoryAuthorUserId",
                table: "Stories");

            migrationBuilder.AlterColumn<int>(
                name: "AccountAge",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "StoryAuthor",
                table: "Stories",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
