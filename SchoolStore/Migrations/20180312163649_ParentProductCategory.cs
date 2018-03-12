using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolStore.Migrations
{
    public partial class ParentProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentProductCategory",
                table: "ProductCategory");

            migrationBuilder.AddColumn<int>(
                name: "ParentProductCategoryId",
                table: "ProductCategory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ParentProductCategoryId",
                table: "ProductCategory",
                column: "ParentProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_ProductCategory_ParentProductCategoryId",
                table: "ProductCategory",
                column: "ParentProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_ProductCategory_ParentProductCategoryId",
                table: "ProductCategory");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategory_ParentProductCategoryId",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "ParentProductCategoryId",
                table: "ProductCategory");

            migrationBuilder.AddColumn<int>(
                name: "ParentProductCategory",
                table: "ProductCategory",
                nullable: false,
                defaultValue: 0);
        }
    }
}
