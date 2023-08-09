using System.Collections.Generic;
using MetricsTogglesDebt.Data.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MetricsTogglesDebt.Data.Migrations
{
    /// <inheritdoc />
    public partial class commit_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sha1 = table.Column<string>(type: "text", nullable: false),
                    Parents = table.Column<List<string>>(type: "jsonb", nullable: false),
                    Tree = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<Author>(type: "jsonb", nullable: false),
                    Committer = table.Column<Committer>(type: "jsonb", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    GPG = table.Column<GPG>(type: "jsonb", nullable: false),
                    Refs = table.Column<List<string>>(type: "jsonb", nullable: false),
                    Tags = table.Column<List<string>>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commits", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commits");
        }
    }
}
