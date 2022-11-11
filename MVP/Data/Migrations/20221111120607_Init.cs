using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
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
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Tax = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Tax" },
                values: new object[,]
                {
                    { new Guid("3a5c9bab-39a5-4a3d-b150-d620fb817ba1"), "Austria", 20.0 },
                    { new Guid("5baaf4c0-7032-4db8-9d22-81092028294c"), "United Kingdom", 20.0 },
                    { new Guid("7e3838b1-7b4a-473e-ad8d-f4db50da3440"), "Sweden", 25.0 },
                    { new Guid("166b99cc-f4d9-491c-bea2-0e48ac6d5218"), "Spain", 21.0 },
                    { new Guid("f06a5a98-5655-470d-ada8-6effef1c0c20"), "Slovenia", 22.0 },
                    { new Guid("eed6252f-7f28-4f1c-9065-8bb186b4a6fd"), "Slovakia", 20.0 },
                    { new Guid("f403e41c-2d82-40bb-81da-e21f35b01a66"), "Romania", 19.0 },
                    { new Guid("c2636d14-bc15-4245-9305-26c656e20583"), "Portugal", 23.0 },
                    { new Guid("f77ba6b8-4910-4587-b50e-cb79870dcfb8"), "Poland", 23.0 },
                    { new Guid("e228c339-7188-415d-8e7c-f437f3c112ab"), "Netherlands", 21.0 },
                    { new Guid("3221eefa-3ee5-488b-85cd-cf1198c90180"), "Malta", 18.0 },
                    { new Guid("c7579721-8300-4820-95b8-97296bbfa353"), "Luxembourg", 17.0 },
                    { new Guid("1bad24f1-4f24-44cf-b5bc-473368b8c52b"), "Latvia", 21.0 },
                    { new Guid("7d456c60-5b09-4832-8e7c-111628c4780c"), "Italy", 22.0 },
                    { new Guid("d9a9700f-1dff-45d8-a4a9-ff55cb3bc6b8"), "Lithuania", 21.0 },
                    { new Guid("5a5e3359-8320-48f5-89f3-e064f8cad8ba"), "Hungary", 27.0 },
                    { new Guid("d07a161a-6aff-4224-bc44-a510022826a3"), "Belgium", 21.0 },
                    { new Guid("f24549c7-eca7-442e-94ed-3a4c559ba9c4"), "Bulgaria", 20.0 },
                    { new Guid("842c637a-1b8d-4878-b1c3-36149e71c1bd"), "Cyprus", 19.0 },
                    { new Guid("527ec3e2-ae69-4aa2-9a62-6bddb210546d"), "Czech Republic", 21.0 },
                    { new Guid("8e9998ac-17f9-4f05-a722-6e52cc48d89a"), "Ireland", 23.0 },
                    { new Guid("2a74de0a-ebd0-4759-9081-bb5ccec4dec0"), "Denmark", 25.0 },
                    { new Guid("34babcb6-4673-479a-a3dd-fdf1e4a33e3d"), "Croatia", 25.0 },
                    { new Guid("1ebf6a56-a890-41df-8ae2-f423978368b6"), "Finland", 24.0 },
                    { new Guid("4759f1ba-8659-4dc0-a0d0-000931af2b83"), "France", 20.0 },
                    { new Guid("c0439c1d-6645-4c8f-a450-9130571fde78"), "Germany", 19.0 },
                    { new Guid("0391f90d-88ea-487c-bd3d-4a4f436a842a"), "Greece", 24.0 },
                    { new Guid("9133baf7-9a1f-4cec-8f9a-201b3ec42762"), "Estonia", 20.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("ded29ad9-3cfa-4d62-9ac5-fa47a7bfdb9c"), "Pizza", 30.0 },
                    { new Guid("5897b1a9-dcff-4399-b478-2ea8e1e35e98"), "Apple", 100.0 },
                    { new Guid("f0f745f2-d0a9-4aef-811f-fb34e88b7ba2"), "Banana", 199.0 },
                    { new Guid("b5ef8097-8a0a-4fa0-9dd3-24183e17327f"), "Car", 9990.5 },
                    { new Guid("3e2bd399-7bef-407f-a32e-8fba1fe85c2e"), "Eggs", 24.0 }
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
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
