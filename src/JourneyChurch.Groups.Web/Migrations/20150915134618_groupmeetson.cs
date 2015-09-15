using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace JourneyChurch.Groups.Web.Migrations
{
    public partial class groupmeetson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MeetsAt",
                table: "Group",
                isNullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<int>(
                name: "MeetsOn",
                table: "Group",
                isNullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "MeetsAt", table: "Group");
            migrationBuilder.DropColumn(name: "MeetsOn", table: "Group");
        }
    }
}
