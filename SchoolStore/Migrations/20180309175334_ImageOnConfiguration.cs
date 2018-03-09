using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolStore.Migrations
{
    public partial class ImageOnConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "ProductConfiguration",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "ProductConfiguration");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Products",
                nullable: true);
        }
    }
}
