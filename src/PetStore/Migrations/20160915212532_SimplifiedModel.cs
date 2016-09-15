using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetStore.Migrations
{
    public partial class SimplifiedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "Product",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Category_MainCategoryId",
                schema: "Product",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                schema: "Product",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "Product",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                schema: "Product",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Pets_TypeId",
                schema: "Pet",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "Product",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "Product");

            migrationBuilder.EnsureSchema(
                name: "ApplicationData");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "Product",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Product",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                schema: "Product",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                schema: "Product",
                table: "Products",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSubCategories",
                schema: "Product",
                table: "SubCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                schema: "Product",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                schema: "Product",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_TypeId",
                schema: "Pet",
                table: "Pets",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                schema: "Product",
                table: "Products",
                column: "ProductCategoryId",
                principalSchema: "Product",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSubCategories_ProductCategories_MainCategoryId",
                schema: "Product",
                table: "SubCategories",
                column: "MainCategoryId",
                principalSchema: "Product",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_MainCategoryId",
                schema: "Product",
                table: "SubCategories",
                newName: "IX_ProductSubCategories_MainCategoryId");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                schema: "Product",
                newName: "ProductSubCategories",
                newSchema: "ApplicationData");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "Product",
                newName: "ProductCategories",
                newSchema: "ApplicationData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                schema: "Product",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSubCategories_ProductCategories_MainCategoryId",
                schema: "ApplicationData",
                table: "ProductSubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSubCategories",
                schema: "ApplicationData",
                table: "ProductSubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                schema: "ApplicationData",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryId",
                schema: "Product",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Pets_TypeId",
                schema: "Pet",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "Product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                schema: "Product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategory",
                schema: "Product",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "Product",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                schema: "ApplicationData",
                table: "ProductSubCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "ApplicationData",
                table: "ProductCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "Product",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_TypeId",
                schema: "Pet",
                table: "Pets",
                column: "TypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                schema: "Product",
                table: "Images",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "Product",
                table: "Products",
                column: "CategoryId",
                principalSchema: "ApplicationData",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Category_MainCategoryId",
                schema: "ApplicationData",
                table: "ProductSubCategories",
                column: "MainCategoryId",
                principalSchema: "ApplicationData",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_ProductSubCategories_MainCategoryId",
                schema: "ApplicationData",
                table: "ProductSubCategories",
                newName: "IX_SubCategories_MainCategoryId");

            migrationBuilder.RenameTable(
                name: "ProductSubCategories",
                schema: "ApplicationData",
                newName: "SubCategories",
                newSchema: "Product");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                schema: "ApplicationData",
                newName: "Category",
                newSchema: "Product");
        }
    }
}
