using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interview.Infrastructure.Persistence.EfCore.Migrations
{
    public partial class JobColumnChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FringeBenefitId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "WorkTypeId",
                table: "Jobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FringeBenefitId",
                table: "Jobs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkTypeId",
                table: "Jobs",
                type: "uuid",
                nullable: true);
        }
    }
}
