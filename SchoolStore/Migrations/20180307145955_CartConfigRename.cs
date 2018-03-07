using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolStore.Migrations
{
    public partial class CartConfigRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLineItem_ProductConfiguration_ProductID",
                table: "CartLineItem");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "CartLineItem",
                newName: "ProductConfigurationID");

            migrationBuilder.RenameIndex(
                name: "IX_CartLineItem_ProductID",
                table: "CartLineItem",
                newName: "IX_CartLineItem_ProductConfigurationID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLineItem_ProductConfiguration_ProductConfigurationID",
                table: "CartLineItem",
                column: "ProductConfigurationID",
                principalTable: "ProductConfiguration",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLineItem_ProductConfiguration_ProductConfigurationID",
                table: "CartLineItem");

            migrationBuilder.RenameColumn(
                name: "ProductConfigurationID",
                table: "CartLineItem",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_CartLineItem_ProductConfigurationID",
                table: "CartLineItem",
                newName: "IX_CartLineItem_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLineItem_ProductConfiguration_ProductID",
                table: "CartLineItem",
                column: "ProductID",
                principalTable: "ProductConfiguration",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
