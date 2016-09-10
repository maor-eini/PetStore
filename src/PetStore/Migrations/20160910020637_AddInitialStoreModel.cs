﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetStore.Migrations
{
    public partial class AddInitialStoreModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.EnsureSchema(
                name: "Order");

            migrationBuilder.EnsureSchema(
                name: "ApplicationData");

            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.EnsureSchema(
                name: "Provider");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "PetType",
                schema: "ApplicationData",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SubCategoryId = table.Column<int>(nullable: true),
                    SubCategoryId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_SubCategoryId1",
                        column: x => x.SubCategoryId1,
                        principalSchema: "Product",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                schema: "Provider",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProviderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: true),
                    Gender = table.Column<string>(maxLength: 1, nullable: true),
                    ImageId = table.Column<string>(nullable: true),
                    IsActive = table.Column<string>(maxLength: 1, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordOld = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserAddressesId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "User",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Product",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "User",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "User",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                schema: "ApplicationData",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    TypeId = table.Column<string>(nullable: true),
                    UserAccountId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_PetType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "ApplicationData",
                        principalTable: "PetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pet_Accounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalSchema: "User",
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UserAccountId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Accounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalSchema: "User",
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    BuildingNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    IsDefaultBillingAddress = table.Column<string>(nullable: true),
                    IsDefaultShippingAddress = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    UserAccountId = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Accounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalSchema: "User",
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    UserAccountId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Accounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalSchema: "User",
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_Id",
                        column: x => x.Id,
                        principalSchema: "Product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderItems",
                schema: "Provider",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    ProviderId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderItems", x => new { x.ProductId, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_ProviderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderItems_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalSchema: "Provider",
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                schema: "User",
                columns: table => new
                {
                    ShoppingCartId = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => new { x.ShoppingCartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "User",
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OrderedDate = table.Column<DateTime>(nullable: false),
                    ShippedDate = table.Column<DateTime>(nullable: false),
                    ShippingAddressId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    UserAccountId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalSchema: "User",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalSchema: "User",
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "Order",
                columns: table => new
                {
                    OrderId = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Order",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "User",
                table: "Roles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "User",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "User",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "User",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "User",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "User",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                schema: "Order",
                table: "Orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserAccountId",
                schema: "Order",
                table: "Orders",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                schema: "Order",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                schema: "Order",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_TypeId",
                schema: "ApplicationData",
                table: "Pet",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_UserAccountId",
                schema: "ApplicationData",
                table: "Pet",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "Product",
                table: "Products",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_SubCategoryId1",
                schema: "Product",
                table: "Category",
                column: "SubCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Id",
                schema: "Product",
                table: "Images",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ProductId",
                schema: "Product",
                table: "Tags",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderItems_ProductId",
                schema: "Provider",
                table: "ProviderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderItems_ProviderId",
                schema: "Provider",
                table: "ProviderItems",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserAccountId",
                schema: "User",
                table: "ShoppingCarts",
                column: "UserAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                schema: "User",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                schema: "User",
                table: "ShoppingCartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "User",
                table: "Accounts",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "User",
                table: "Accounts",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserAccountId",
                schema: "User",
                table: "Addresses",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserAccountId",
                schema: "User",
                table: "Images",
                column: "UserAccountId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "User");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "User");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "User");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "User");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "User");

            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Pet",
                schema: "ApplicationData");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "ProviderItems",
                schema: "Provider");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "PetType",
                schema: "ApplicationData");

            migrationBuilder.DropTable(
                name: "Providers",
                schema: "Provider");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "ShoppingCarts",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "User");
        }
    }
}
