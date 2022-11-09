using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Tax" },
                values: new object[,]
                {
                    { new Guid("85947199-525c-4103-8e76-2cec3bde1440"), "Austria", 20.0 },
                    { new Guid("cd26aa58-3a45-4426-b152-b892d47b0920"), "United Kingdom", 20.0 },
                    { new Guid("e97c71c7-05c6-4f01-8d54-dcf4af92291a"), "Sweden", 25.0 },
                    { new Guid("84199f5d-d5ef-419a-a7e3-016e562806c3"), "Spain", 21.0 },
                    { new Guid("d64a184a-6d43-49a8-bcf0-d63c0439e1ff"), "Slovenia", 22.0 },
                    { new Guid("5cea06e3-c5b6-4baa-a54c-60dc62bf71a8"), "Slovakia", 20.0 },
                    { new Guid("d5d73a2a-9101-4afd-b760-4f0a57648102"), "Romania", 19.0 },
                    { new Guid("b7494b69-732a-4fcb-bc8c-de8925ec2059"), "Portugal", 23.0 },
                    { new Guid("49399173-f104-4bf0-bdb9-eacf3e3ed091"), "Poland", 23.0 },
                    { new Guid("3d2f3afa-b709-4b07-bd1e-a55717bdf907"), "Netherlands", 21.0 },
                    { new Guid("c68428fe-dba6-420c-b903-2a5244a205ba"), "Malta", 18.0 },
                    { new Guid("e1c25396-a7a5-4911-abfd-39ae7d0c0f3f"), "Luxembourg", 17.0 },
                    { new Guid("788b36f1-74f2-4f9c-be83-ec5ef275107d"), "Latvia", 21.0 },
                    { new Guid("242579e3-1d28-40a0-90fd-976dfc4dbcbc"), "Italy", 22.0 },
                    { new Guid("9a8e079e-1c7f-47ad-b467-fda16854d7d2"), "Lithuania", 21.0 },
                    { new Guid("b92894f7-dd22-4c93-b862-428b3d2f94d1"), "Hungary", 27.0 },
                    { new Guid("1987455c-2c6b-4fa1-ae09-354746d144b8"), "Belgium", 21.0 },
                    { new Guid("993d73f0-0024-43fc-9256-e5bdd8775073"), "Bulgaria", 20.0 },
                    { new Guid("bcd31951-b1c3-48a4-8156-f3938e27102a"), "Cyprus", 19.0 },
                    { new Guid("04fdb557-28b8-4460-abe7-7c6209f9ede4"), "Czech Republic", 21.0 },
                    { new Guid("c1802782-f42e-4130-8719-072ddc34e14e"), "Ireland", 23.0 },
                    { new Guid("6d1fe4bf-e4b1-4004-85ce-73dc28f3383e"), "Denmark", 25.0 },
                    { new Guid("cfd8f640-72df-43ea-afb9-fd20a61380a7"), "Croatia", 25.0 },
                    { new Guid("6a26f151-0bff-4f0b-97e0-afadfa3f6c90"), "Finland", 24.0 },
                    { new Guid("4aaf5886-e3fd-467b-b791-bfb130ae9380"), "France", 20.0 },
                    { new Guid("64d6bb0e-9abc-4fab-bf9c-2cfaf26ec1db"), "Germany", 19.0 },
                    { new Guid("596be977-e0c8-4810-8c03-baec70461f90"), "Greece", 24.0 },
                    { new Guid("b9899c9a-ece1-4d83-b99a-6b6aa70d2ab4"), "Estonia", 20.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("ebc5fb98-4e35-40ee-ad4b-d879722bc020"), "Pizza", 30.0 },
                    { new Guid("ca006d09-e327-43a7-8ba6-35f150817184"), "Apple", 100.0 },
                    { new Guid("ab155fef-3c7d-45ab-9e9a-557ad5400e96"), "Banana", 199.0 },
                    { new Guid("01577127-0918-4351-81d0-5b545ab90686"), "Car", 9990.5 },
                    { new Guid("832c54a1-d0ea-476a-a235-7f33b73660dc"), "Eggs", 24.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
