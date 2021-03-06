﻿// <auto-generated />
using CakeShop.Net.Model.DM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CakeShop.Net.Model.DM.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CakeShop.Net.Model.DM.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OrderAddressLine1");

                    b.Property<string>("OrderAddressLine2");

                    b.Property<string>("OrderCity");

                    b.Property<string>("OrderCountry");

                    b.Property<int>("OrderCreatedBy_UserId");

                    b.Property<DateTime>("OrderCreatedDate");

                    b.Property<string>("OrderEmail");

                    b.Property<string>("OrderFirstName");

                    b.Property<string>("OrderLastName");

                    b.Property<int>("OrderModifiedBy_UserId");

                    b.Property<DateTime>("OrderModifiedDate");

                    b.Property<string>("OrderPhoneNumber");

                    b.Property<string>("OrderState");

                    b.Property<bool>("OrderStatus");

                    b.Property<decimal>("OrderTotal");

                    b.Property<string>("OrderZipCode");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CakeShop.Net.Model.DM.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrderDetailAmount");

                    b.Property<int>("OrderDetailCreatedBy_UserId");

                    b.Property<DateTime>("OrderDetailCreatedDate");

                    b.Property<int>("OrderDetailModifiedBy_UserId");

                    b.Property<DateTime>("OrderDetailModifiedDate");

                    b.Property<decimal>("OrderDetailPrice");

                    b.Property<bool>("OrderDetailStatus");

                    b.Property<Guid>("OrderDetail_OrderId");

                    b.Property<Guid>("OrderDetail_PieId");

                    b.HasKey("Id");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("CakeShop.Net.Model.DM.Pie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PieAllergyInformation");

                    b.Property<int>("PieCreatedBy_UserId");

                    b.Property<DateTime>("PieCreatedDate");

                    b.Property<string>("PieImageThumbnailUrl");

                    b.Property<string>("PieImageUrl");

                    b.Property<bool>("PieInStock");

                    b.Property<bool>("PieIsPieOfTheWeek");

                    b.Property<string>("PieLongDescription");

                    b.Property<int>("PieModifiedBy_UserId");

                    b.Property<DateTime>("PieModifiedDate");

                    b.Property<string>("PieName");

                    b.Property<decimal>("PiePrice");

                    b.Property<string>("PieShortDescription");

                    b.Property<bool>("PieStatus");

                    b.Property<int>("Pie_CategoryId");

                    b.HasKey("Id");

                    b.ToTable("Pie");
                });

            modelBuilder.Entity("CakeShop.Net.Model.DM.ShoppingCartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ShoppingCartItemAmount");

                    b.Property<int>("ShoppingCartItemCreatedBy_UserId");

                    b.Property<DateTime>("ShoppingCartItemCreatedDate");

                    b.Property<int>("ShoppingCartItemModifiedBy_UserId");

                    b.Property<DateTime>("ShoppingCartItemModifiedDate");

                    b.Property<bool>("ShoppingCartItemStatus");

                    b.Property<Guid>("ShoppingCartItem_PieId");

                    b.Property<Guid>("ShoppingCartItem_ShoppingCartId");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCartItem");
                });

            modelBuilder.Entity("CakeShop.Net.Model.DM.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserAlternatePassword");

                    b.Property<int>("UserCreatedBy_UserId");

                    b.Property<DateTime>("UserCreatedDate");

                    b.Property<string>("UserEmail");

                    b.Property<string>("UserFirstName");

                    b.Property<string>("UserLastName");

                    b.Property<int>("UserModifiedBy_UserId");

                    b.Property<DateTime>("UserModifiedDate");

                    b.Property<string>("UserPassword");

                    b.Property<string>("UserPasswordSalt");

                    b.Property<bool>("UserStatus");

                    b.Property<string>("UserUsername");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
