using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace JourneyChurch.Groups.Web.Migrations
{
    public partial class groupnotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Group",
                isNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Notes", table: "Group");
        }
    }
}
