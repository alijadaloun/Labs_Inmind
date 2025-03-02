using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordAndPhoneToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                schema: "public",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                schema: "public",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "birthdate",
                schema: "public",
                table: "Students",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "password",
                schema: "public",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                schema: "public",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                schema: "public",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "birthdate",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "password",
                schema: "public",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                schema: "public",
                table: "Students");
        }
    }
}
