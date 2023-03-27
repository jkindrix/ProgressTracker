using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMetric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdatedAt",
                table: "Items",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<int>(
                name: "MetricId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Metrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_MetricId",
                table: "Items",
                column: "MetricId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Metrics_MetricId",
                table: "Items",
                column: "MetricId",
                principalTable: "Metrics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Metrics_MetricId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Metrics");

            migrationBuilder.DropIndex(
                name: "IX_Items_MetricId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MetricId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Items",
                newName: "LastUpdatedAt");
        }
    }
}
