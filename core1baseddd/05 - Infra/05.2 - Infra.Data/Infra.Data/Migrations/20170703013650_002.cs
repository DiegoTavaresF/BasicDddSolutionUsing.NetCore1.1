using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ExampleEntity");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExampleEntity",
                maxLength: 120,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExampleEntity");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ExampleEntity",
                nullable: true);
        }
    }
}
