using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolStore.Migrations
{
    public partial class additionalconfigrefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartLineItemID",
                table: "ProductConfiguration",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderLineItemID",
                table: "ProductConfiguration",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductConfiguration_CartLineItemID",
                table: "ProductConfiguration",
                column: "CartLineItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductConfiguration_OrderLineItemID",
                table: "ProductConfiguration",
                column: "OrderLineItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConfiguration_CartLineItem_CartLineItemID",
                table: "ProductConfiguration",
                column: "CartLineItemID",
                principalTable: "CartLineItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConfiguration_OrderLineItem_OrderLineItemID",
                table: "ProductConfiguration",
                column: "OrderLineItemID",
                principalTable: "OrderLineItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductConfiguration_CartLineItem_CartLineItemID",
                table: "ProductConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductConfiguration_OrderLineItem_OrderLineItemID",
                table: "ProductConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_ProductConfiguration_CartLineItemID",
                table: "ProductConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_ProductConfiguration_OrderLineItemID",
                table: "ProductConfiguration");

            migrationBuilder.DropColumn(
                name: "CartLineItemID",
                table: "ProductConfiguration");

            migrationBuilder.DropColumn(
                name: "OrderLineItemID",
                table: "ProductConfiguration");
        }
    }
}
