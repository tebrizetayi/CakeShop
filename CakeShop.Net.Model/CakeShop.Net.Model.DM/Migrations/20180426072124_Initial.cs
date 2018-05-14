using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CakeShop.Net.Model.DM.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderAddressLine1 = table.Column<string>(nullable: true),
                    OrderAddressLine2 = table.Column<string>(nullable: true),
                    OrderCity = table.Column<string>(nullable: true),
                    OrderCountry = table.Column<string>(nullable: true),
                    OrderCreatedBy_UserId = table.Column<int>(nullable: false),
                    OrderCreatedDate = table.Column<DateTime>(nullable: false),
                    OrderEmail = table.Column<string>(nullable: true),
                    OrderFirstName = table.Column<string>(nullable: true),
                    OrderLastName = table.Column<string>(nullable: true),
                    OrderModifiedBy_UserId = table.Column<int>(nullable: false),
                    OrderModifiedDate = table.Column<DateTime>(nullable: false),
                    OrderPhoneNumber = table.Column<string>(nullable: true),
                    OrderState = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<bool>(nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    OrderZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderDetailAmount = table.Column<int>(nullable: false),
                    OrderDetailCreatedBy_UserId = table.Column<int>(nullable: false),
                    OrderDetailCreatedDate = table.Column<DateTime>(nullable: false),
                    OrderDetailModifiedBy_UserId = table.Column<int>(nullable: false),
                    OrderDetailModifiedDate = table.Column<DateTime>(nullable: false),
                    OrderDetailPrice = table.Column<decimal>(nullable: false),
                    OrderDetailStatus = table.Column<bool>(nullable: false),
                    OrderDetail_OrderId = table.Column<Guid>(nullable: false),
                    OrderDetail_PieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pie",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PieAllergyInformation = table.Column<string>(nullable: true),
                    PieCreatedBy_UserId = table.Column<int>(nullable: false),
                    PieCreatedDate = table.Column<DateTime>(nullable: false),
                    PieImageThumbnailUrl = table.Column<string>(nullable: true),
                    PieImageUrl = table.Column<string>(nullable: true),
                    PieInStock = table.Column<bool>(nullable: false),
                    PieIsPieOfTheWeek = table.Column<bool>(nullable: false),
                    PieLongDescription = table.Column<string>(nullable: true),
                    PieModifiedBy_UserId = table.Column<int>(nullable: false),
                    PieModifiedDate = table.Column<DateTime>(nullable: false),
                    PieName = table.Column<string>(nullable: true),
                    PiePrice = table.Column<decimal>(nullable: false),
                    PieShortDescription = table.Column<string>(nullable: true),
                    PieStatus = table.Column<bool>(nullable: false),
                    Pie_CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShoppingCartItemAmount = table.Column<int>(nullable: false),
                    ShoppingCartItemCreatedBy_UserId = table.Column<int>(nullable: false),
                    ShoppingCartItemCreatedDate = table.Column<DateTime>(nullable: false),
                    ShoppingCartItemModifiedBy_UserId = table.Column<int>(nullable: false),
                    ShoppingCartItemModifiedDate = table.Column<DateTime>(nullable: false),
                    ShoppingCartItemStatus = table.Column<bool>(nullable: false),
                    ShoppingCartItem_PieId = table.Column<Guid>(nullable: false),
                    ShoppingCartItem_ShoppingCartId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserAlternatePassword = table.Column<string>(nullable: true),
                    UserCreatedBy_UserId = table.Column<int>(nullable: false),
                    UserCreatedDate = table.Column<DateTime>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    UserFirstName = table.Column<string>(nullable: true),
                    UserLastName = table.Column<string>(nullable: true),
                    UserModifiedBy_UserId = table.Column<int>(nullable: false),
                    UserModifiedDate = table.Column<DateTime>(nullable: false),
                    UserPassword = table.Column<string>(nullable: true),
                    UserPasswordSalt = table.Column<string>(nullable: true),
                    UserStatus = table.Column<bool>(nullable: false),
                    UserUsername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Pie");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
