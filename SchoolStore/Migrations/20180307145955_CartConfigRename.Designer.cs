﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SchoolStore.Models;
using System;

namespace SchoolStore.Migrations
{
    [DbContext(typeof(JimTestContext))]
    [Migration("20180307145955_CartConfigRename")]
    partial class CartConfigRename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("SchoolStore.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<string>("State");

                    b.Property<string>("ZipCode");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SchoolStore.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FavoriteSchool");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

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

            modelBuilder.Entity("SchoolStore.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<Guid>("TrackingNumber");

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("SchoolStore.Models.CartLineItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CartID");

                    b.Property<int?>("ProductConfigurationID");

                    b.Property<int?>("ProductsID");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.HasIndex("CartID");

                    b.HasIndex("ProductConfigurationID");

                    b.HasIndex("ProductsID");

                    b.ToTable("CartLineItem");
                });

            modelBuilder.Entity("SchoolStore.Models.Color", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("SchoolStore.Models.CustomerAddress", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("AddressType");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("CustomerAddress");
                });

            modelBuilder.Entity("SchoolStore.Models.OrderHeader", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BillToAddressId");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<DateTime?>("OrderDate");

                    b.Property<decimal?>("ShipCost");

                    b.Property<int?>("ShipToAddressId");

                    b.Property<decimal?>("SubTotal");

                    b.Property<decimal?>("TaxAmount");

                    b.Property<decimal?>("TotalDue");

                    b.Property<Guid>("TrackingNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("OrderHeader");
                });

            modelBuilder.Entity("SchoolStore.Models.OrderLineItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderHeaderID")
                        .IsRequired();

                    b.Property<int?>("ProductID")
                        .IsRequired();

                    b.Property<int?>("Quantity");

                    b.HasKey("ID");

                    b.HasIndex("OrderHeaderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderLineItem");
                });

            modelBuilder.Entity("SchoolStore.Models.ProductCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryImage");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<string>("Name");

                    b.Property<int>("ParentProductCategory");

                    b.HasKey("ID");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("SchoolStore.Models.ProductConfiguration", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColorID");

                    b.Property<int>("Inventory");

                    b.Property<int?>("OrderLineItemID");

                    b.Property<decimal>("PriceSurcharge");

                    b.Property<int?>("ProductID");

                    b.Property<int>("SizeID");

                    b.HasKey("ID");

                    b.HasIndex("ColorID");

                    b.HasIndex("OrderLineItemID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SizeID");

                    b.ToTable("ProductConfiguration");
                });

            modelBuilder.Entity("SchoolStore.Models.Products", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryID");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<string>("ImageURL");

                    b.Property<string>("ProductDescription");

                    b.Property<string>("ProductName");

                    b.Property<decimal?>("UnitPrice");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SchoolStore.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<bool>("IsApproved");

                    b.Property<int?>("ProductID");

                    b.Property<int>("Rating");

                    b.Property<int?>("ReviewID");

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.HasIndex("ReviewID");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SchoolStore.Models.Size", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Size");
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
                    b.HasOne("SchoolStore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SchoolStore.Models.ApplicationUser")
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

                    b.HasOne("SchoolStore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SchoolStore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolStore.Models.Cart", b =>
                {
                    b.HasOne("SchoolStore.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SchoolStore.Models.CartLineItem", b =>
                {
                    b.HasOne("SchoolStore.Models.Cart", "Cart")
                        .WithMany("CartLineItems")
                        .HasForeignKey("CartID");

                    b.HasOne("SchoolStore.Models.ProductConfiguration", "ProductConfiguration")
                        .WithMany()
                        .HasForeignKey("ProductConfigurationID");

                    b.HasOne("SchoolStore.Models.Products")
                        .WithMany("CartLineItems")
                        .HasForeignKey("ProductsID");
                });

            modelBuilder.Entity("SchoolStore.Models.CustomerAddress", b =>
                {
                    b.HasOne("SchoolStore.Models.Address", "Address")
                        .WithMany("CustomerAddress")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolStore.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SchoolStore.Models.OrderHeader", b =>
                {
                    b.HasOne("SchoolStore.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SchoolStore.Models.OrderLineItem", b =>
                {
                    b.HasOne("SchoolStore.Models.OrderHeader", "OrderHeader")
                        .WithMany("OrderLineItems")
                        .HasForeignKey("OrderHeaderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolStore.Models.Products", "Product")
                        .WithMany("OrderLineItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolStore.Models.ProductConfiguration", b =>
                {
                    b.HasOne("SchoolStore.Models.Color", "Color")
                        .WithMany("Configurations")
                        .HasForeignKey("ColorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolStore.Models.OrderLineItem")
                        .WithMany("Configurations")
                        .HasForeignKey("OrderLineItemID");

                    b.HasOne("SchoolStore.Models.Products", "Product")
                        .WithMany("Configurations")
                        .HasForeignKey("ProductID");

                    b.HasOne("SchoolStore.Models.Size", "Size")
                        .WithMany("Configurations")
                        .HasForeignKey("SizeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolStore.Models.Products", b =>
                {
                    b.HasOne("SchoolStore.Models.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("SchoolStore.Models.Review", b =>
                {
                    b.HasOne("SchoolStore.Models.Products", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductID");

                    b.HasOne("SchoolStore.Models.Review")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewID");

                    b.HasOne("SchoolStore.Models.ApplicationUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
