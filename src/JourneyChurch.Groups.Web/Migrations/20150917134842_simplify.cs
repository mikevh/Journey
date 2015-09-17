using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace JourneyChurch.Groups.Web.Migrations
{
    public partial class simplify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MeetsAt",
                table: "Group",
                isNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MeetsAt",
                table: "Group",
                isNullable: false);
        }
    }
}
