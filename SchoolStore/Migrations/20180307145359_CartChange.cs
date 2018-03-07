using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolStore.Migrations
{
    public partial class CartChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLineItem_Products_ProductID",
                table: "CartLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductConfiguration_CartLineItem_CartLineItemID",
                table: "ProductConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_ProductConfiguration_CartLineItemID",
                table: "ProductConfiguration");

            migrationBuilder.DropColumn(
                name: "CartLineItemID",
                table: "ProductConfiguration");

            migrationBuilder.AddColumn<int>(
                name: "ProductsID",
                table: "CartLineItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartLineItem_ProductsID",
                table: "CartLineItem",
                column: "ProductsID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLineItem_ProductConfiguration_ProductID",
                table: "CartLineItem",
                column: "ProductID",
                principalTable: "ProductConfiguration",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartLineItem_Products_ProductsID",
                table: "CartLineItem",
                column: "ProductsID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLineItem_ProductConfiguration_ProductID",
                table: "CartLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartLineItem_Products_ProductsID",
                table: "CartLineItem");

            migrationBuilder.DropIndex(
                name: "IX_CartLineItem_ProductsID",
                table: "CartLineItem");

            migrationBuilder.DropColumn(
                name: "ProductsID",
                table: "CartLineItem");

            migrationBuilder.AddColumn<int>(
                name: "CartLineItemID",
                table: "ProductConfiguration",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductConfiguration_CartLineItemID",
                table: "ProductConfiguration",
                column: "CartLineItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLineItem_Products_ProductID",
                table: "CartLineItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConfiguration_CartLineItem_CartLineItemID",
                table: "ProductConfiguration",
                column: "CartLineItemID",
                principalTable: "CartLineItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
