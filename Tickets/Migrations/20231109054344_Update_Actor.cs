using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tickets.Migrations
{
    public partial class Update_Actor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Actors",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Actors",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Actors");
        }
    }
}
