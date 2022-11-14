﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MVPContext))]
    partial class MVPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tax")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6fd657b3-dee2-41e0-a005-00d316623c11"),
                            Name = "Austria",
                            Tax = 20.0
                        },
                        new
                        {
                            Id = new Guid("04bff609-2abe-4e2f-b5d3-de7db29fe0fb"),
                            Name = "Belgium",
                            Tax = 21.0
                        },
                        new
                        {
                            Id = new Guid("f3aae1dd-8ac4-48d1-83fb-4e217a9f2fc7"),
                            Name = "Bulgaria",
                            Tax = 20.0
                        },
                        new
                        {
                            Id = new Guid("849e3a1c-00a7-4634-8400-cfd0722001ed"),
                            Name = "Cyprus",
                            Tax = 19.0
                        },
                        new
                        {
                            Id = new Guid("a28b4218-f1e5-449e-953b-458b38db7ffe"),
                            Name = "Czech Republic",
                            Tax = 21.0
                        },
                        new
                        {
                            Id = new Guid("25341dac-f4a8-4b27-ae24-bf23423310e5"),
                            Name = "Croatia",
                            Tax = 25.0
                        },
                        new
                        {
                            Id = new Guid("7ee56ed2-7c0a-4f6b-b054-cf9eff403c23"),
                            Name = "Denmark",
                            Tax = 25.0
                        },
                        new
                        {
                            Id = new Guid("e64123bb-cbdf-4209-ad42-be14848a9d8b"),
                            Name = "Estonia",
                            Tax = 20.0
                        },
                        new
                        {
                            Id = new Guid("cb56f4d3-3c8f-4937-8585-670b5808a9b0"),
                            Name = "Finland",
                            Tax = 24.0
                        },
                        new
                        {
                            Id = new Guid("1ec3e48b-3294-4abf-9c7d-2a4813fdae9a"),
                            Name = "France",
                            Tax = 20.0
                        },
                        new
                        {
                            Id = new Guid("f7101f7d-ac2d-4ca1-b89a-bb4aad3cbb67"),
                            Name = "Germany",
                            Tax = 19.0
                        },
                        new
                        {
                            Id = new Guid("1b8ade54-2cb0-4312-877e-0f62f543dc47"),
                            Name = "Greece",
                            Tax = 24.0
                        },
                        new
                        {
                            Id = new Guid("7ddd9432-d2a3-48c1-9b83-9ba6be59da8f"),
                            Name = "Hungary",
                            Tax = 27.0
                        },
                        new
                        {
                            Id = new Guid("1374a572-32ba-47ee-be00-0d27e2f8813a"),
                            Name = "Ireland",
                            Tax = 23.0
                        },
                        new
                        {
                            Id = new Guid("e86e6440-5ccf-491b-a9cf-4f8ca1614dc3"),
                            Name = "Italy",
                            Tax = 22.0
                        },
                        new
                        {
                            Id = new Guid("efe9ad7c-6364-4857-80de-ac2c2a4b26b9"),
                            Name = "Latvia",
                            Tax = 21.0
                        },
                        new
                        {
                            Id = new Guid("e0be20e9-a039-46e2-abcc-8c3909726295"),
                            Name = "Lithuania",
                            Tax = 21.0
                        },
                        new
                        {
                            Id = new Guid("783e91a1-65bb-4bb9-85c9-49a99fe94d10"),
                            Name = "Luxembourg",
                            Tax = 17.0
                        },
                        new
                        {
                            Id = new Guid("aa37ab85-ebd1-4d7c-9fca-59e0f314eb48"),
                            Name = "Malta",
                            Tax = 18.0
                        },
                        new
                        {
                            Id = new Guid("dc58a2b2-756e-4307-8752-7a6cc48d29b1"),
                            Name = "Netherlands",
                            Tax = 21.0
                        },
                        new
                        {
                            Id = new Guid("884997a2-a9b6-4728-abf2-0644a8b254c2"),
                            Name = "Poland",
                            Tax = 23.0
                        },
                        new
                        {
                            Id = new Guid("432a96b6-8ed9-4be8-af3a-c723496b3667"),
                            Name = "Portugal",
                            Tax = 23.0
                        },
                        new
                        {
                            Id = new Guid("21728111-543e-4a4a-ac84-0c91c9c2e5a0"),
                            Name = "Romania",
                            Tax = 19.0
                        },
                        new
                        {
                            Id = new Guid("2af47fc0-bae1-4b74-bd14-17a086146812"),
                            Name = "Slovakia",
                            Tax = 20.0
                        },
                        new
                        {
                            Id = new Guid("ca947024-83ad-46fe-a7d3-13d6a07ff6d3"),
                            Name = "Slovenia",
                            Tax = 22.0
                        },
                        new
                        {
                            Id = new Guid("3c45b095-f3d4-4b8d-a437-0b1343525b6a"),
                            Name = "Spain",
                            Tax = 21.0
                        },
                        new
                        {
                            Id = new Guid("9516c418-c5a8-4065-8e82-ace029ba38d2"),
                            Name = "Sweden",
                            Tax = 25.0
                        },
                        new
                        {
                            Id = new Guid("6c3f4003-74db-4de0-9f2a-999c6e6d35e8"),
                            Name = "United Kingdom",
                            Tax = 20.0
                        });
                });

            modelBuilder.Entity("Data.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceFormat")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("66450e28-fab3-40d6-8510-b0ab1789889b"),
                            Name = "Apple",
                            Price = 100.0
                        },
                        new
                        {
                            Id = new Guid("651a0707-b5cc-4f50-aa75-7baf9bba3253"),
                            Name = "Banana",
                            Price = 199.0
                        },
                        new
                        {
                            Id = new Guid("72f1c298-f316-467e-9030-9506e367a5f9"),
                            Name = "Car",
                            Price = 9990.5
                        },
                        new
                        {
                            Id = new Guid("2bf5c86a-b398-42cb-8931-e78d13b49731"),
                            Name = "Pizza",
                            Price = 30.0
                        },
                        new
                        {
                            Id = new Guid("069a7a09-40ca-4e1a-a273-9c69c13d51ef"),
                            Name = "Eggs",
                            Price = 24.0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Data.Authentication.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
