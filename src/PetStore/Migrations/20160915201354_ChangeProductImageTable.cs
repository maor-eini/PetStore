using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetStore.Migrations
{
    public partial class ChangeProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_Id",
                schema: "Product",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_Id",
                schema: "Product",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "Product",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                schema: "Product",
                table: "Images",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Product",
                table: "Images",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                schema: "Product",
                table: "Images",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                schema: "Product",
                table: "Images",
                column: "ProductId",
                principalSchema: "Product",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                schema: "Product",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProductId",
                schema: "Product",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "Product",
                table: "Images");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                schema: "Product",
                table: "Images",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Product",
                table: "Images",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Images_Id",
                schema: "Product",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_Id",
                schema: "Product",
                table: "Images",
                column: "Id",
                principalSchema: "Product",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
