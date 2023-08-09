using System.Collections.Generic;
using MetricsTogglesDebt.Data.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetricsTogglesDebt.Data.Migrations
{
    /// <inheritdoc />
    public partial class edittable_commit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tree",
                table: "Commits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<List<string>>(
                name: "Tags",
                table: "Commits",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<string>(
                name: "Sha1",
                table: "Commits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<List<string>>(
                name: "Refs",
                table: "Commits",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<List<string>>(
                name: "Parents",
                table: "Commits",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Commits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<GPG>(
                name: "GPG",
                table: "Commits",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(GPG),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<Committer>(
                name: "Committer",
                table: "Commits",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(Committer),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<Author>(
                name: "Author",
                table: "Commits",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(Author),
                oldType: "jsonb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tree",
                table: "Commits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<string>>(
                name: "Tags",
                table: "Commits",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sha1",
                table: "Commits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<string>>(
                name: "Refs",
                table: "Commits",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<string>>(
                name: "Parents",
                table: "Commits",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Commits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<GPG>(
                name: "GPG",
                table: "Commits",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(GPG),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<Committer>(
                name: "Committer",
                table: "Commits",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(Committer),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<Author>(
                name: "Author",
                table: "Commits",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(Author),
                oldType: "jsonb",
                oldNullable: true);
        }
    }
}
