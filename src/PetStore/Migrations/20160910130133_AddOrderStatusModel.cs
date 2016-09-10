using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Migrations
{
    public partial class AddOrderStatusModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Order",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                schema: "ApplicationData",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                schema: "Order",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                schema: "Order",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatus_StatusId",
                schema: "Order",
                table: "Orders",
                column: "StatusId",
                principalSchema: "ApplicationData",
                principalTable: "OrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatus_StatusId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StatusId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatus",
                schema: "ApplicationData");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Order",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }
    }
}
