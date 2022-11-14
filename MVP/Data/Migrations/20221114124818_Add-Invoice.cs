using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0391f90d-88ea-487c-bd3d-4a4f436a842a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("166b99cc-f4d9-491c-bea2-0e48ac6d5218"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1bad24f1-4f24-44cf-b5bc-473368b8c52b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ebf6a56-a890-41df-8ae2-f423978368b6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2a74de0a-ebd0-4759-9081-bb5ccec4dec0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3221eefa-3ee5-488b-85cd-cf1198c90180"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("34babcb6-4673-479a-a3dd-fdf1e4a33e3d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3a5c9bab-39a5-4a3d-b150-d620fb817ba1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4759f1ba-8659-4dc0-a0d0-000931af2b83"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("527ec3e2-ae69-4aa2-9a62-6bddb210546d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5a5e3359-8320-48f5-89f3-e064f8cad8ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5baaf4c0-7032-4db8-9d22-81092028294c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7d456c60-5b09-4832-8e7c-111628c4780c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7e3838b1-7b4a-473e-ad8d-f4db50da3440"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("842c637a-1b8d-4878-b1c3-36149e71c1bd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8e9998ac-17f9-4f05-a722-6e52cc48d89a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9133baf7-9a1f-4cec-8f9a-201b3ec42762"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c0439c1d-6645-4c8f-a450-9130571fde78"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c2636d14-bc15-4245-9305-26c656e20583"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c7579721-8300-4820-95b8-97296bbfa353"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d07a161a-6aff-4224-bc44-a510022826a3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d9a9700f-1dff-45d8-a4a9-ff55cb3bc6b8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e228c339-7188-415d-8e7c-f437f3c112ab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eed6252f-7f28-4f1c-9065-8bb186b4a6fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f06a5a98-5655-470d-ada8-6effef1c0c20"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f24549c7-eca7-442e-94ed-3a4c559ba9c4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f403e41c-2d82-40bb-81da-e21f35b01a66"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f77ba6b8-4910-4587-b50e-cb79870dcfb8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3e2bd399-7bef-407f-a32e-8fba1fe85c2e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5897b1a9-dcff-4399-b478-2ea8e1e35e98"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b5ef8097-8a0a-4fa0-9dd3-24183e17327f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ded29ad9-3cfa-4d62-9ac5-fa47a7bfdb9c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f0f745f2-d0a9-4aef-811f-fb34e88b7ba2"));

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InvoiceFormat = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Tax" },
                values: new object[,]
                {
                    { new Guid("6fd657b3-dee2-41e0-a005-00d316623c11"), "Austria", 20.0 },
                    { new Guid("6c3f4003-74db-4de0-9f2a-999c6e6d35e8"), "United Kingdom", 20.0 },
                    { new Guid("9516c418-c5a8-4065-8e82-ace029ba38d2"), "Sweden", 25.0 },
                    { new Guid("3c45b095-f3d4-4b8d-a437-0b1343525b6a"), "Spain", 21.0 },
                    { new Guid("ca947024-83ad-46fe-a7d3-13d6a07ff6d3"), "Slovenia", 22.0 },
                    { new Guid("2af47fc0-bae1-4b74-bd14-17a086146812"), "Slovakia", 20.0 },
                    { new Guid("21728111-543e-4a4a-ac84-0c91c9c2e5a0"), "Romania", 19.0 },
                    { new Guid("432a96b6-8ed9-4be8-af3a-c723496b3667"), "Portugal", 23.0 },
                    { new Guid("884997a2-a9b6-4728-abf2-0644a8b254c2"), "Poland", 23.0 },
                    { new Guid("dc58a2b2-756e-4307-8752-7a6cc48d29b1"), "Netherlands", 21.0 },
                    { new Guid("aa37ab85-ebd1-4d7c-9fca-59e0f314eb48"), "Malta", 18.0 },
                    { new Guid("783e91a1-65bb-4bb9-85c9-49a99fe94d10"), "Luxembourg", 17.0 },
                    { new Guid("efe9ad7c-6364-4857-80de-ac2c2a4b26b9"), "Latvia", 21.0 },
                    { new Guid("e86e6440-5ccf-491b-a9cf-4f8ca1614dc3"), "Italy", 22.0 },
                    { new Guid("e0be20e9-a039-46e2-abcc-8c3909726295"), "Lithuania", 21.0 },
                    { new Guid("7ddd9432-d2a3-48c1-9b83-9ba6be59da8f"), "Hungary", 27.0 },
                    { new Guid("04bff609-2abe-4e2f-b5d3-de7db29fe0fb"), "Belgium", 21.0 },
                    { new Guid("f3aae1dd-8ac4-48d1-83fb-4e217a9f2fc7"), "Bulgaria", 20.0 },
                    { new Guid("849e3a1c-00a7-4634-8400-cfd0722001ed"), "Cyprus", 19.0 },
                    { new Guid("a28b4218-f1e5-449e-953b-458b38db7ffe"), "Czech Republic", 21.0 },
                    { new Guid("1374a572-32ba-47ee-be00-0d27e2f8813a"), "Ireland", 23.0 },
                    { new Guid("7ee56ed2-7c0a-4f6b-b054-cf9eff403c23"), "Denmark", 25.0 },
                    { new Guid("25341dac-f4a8-4b27-ae24-bf23423310e5"), "Croatia", 25.0 },
                    { new Guid("cb56f4d3-3c8f-4937-8585-670b5808a9b0"), "Finland", 24.0 },
                    { new Guid("1ec3e48b-3294-4abf-9c7d-2a4813fdae9a"), "France", 20.0 },
                    { new Guid("f7101f7d-ac2d-4ca1-b89a-bb4aad3cbb67"), "Germany", 19.0 },
                    { new Guid("1b8ade54-2cb0-4312-877e-0f62f543dc47"), "Greece", 24.0 },
                    { new Guid("e64123bb-cbdf-4209-ad42-be14848a9d8b"), "Estonia", 20.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2bf5c86a-b398-42cb-8931-e78d13b49731"), "Pizza", 30.0 },
                    { new Guid("66450e28-fab3-40d6-8510-b0ab1789889b"), "Apple", 100.0 },
                    { new Guid("651a0707-b5cc-4f50-aa75-7baf9bba3253"), "Banana", 199.0 },
                    { new Guid("72f1c298-f316-467e-9030-9506e367a5f9"), "Car", 9990.5 },
                    { new Guid("069a7a09-40ca-4e1a-a273-9c69c13d51ef"), "Eggs", 24.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("04bff609-2abe-4e2f-b5d3-de7db29fe0fb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1374a572-32ba-47ee-be00-0d27e2f8813a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1b8ade54-2cb0-4312-877e-0f62f543dc47"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ec3e48b-3294-4abf-9c7d-2a4813fdae9a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("21728111-543e-4a4a-ac84-0c91c9c2e5a0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("25341dac-f4a8-4b27-ae24-bf23423310e5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2af47fc0-bae1-4b74-bd14-17a086146812"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3c45b095-f3d4-4b8d-a437-0b1343525b6a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("432a96b6-8ed9-4be8-af3a-c723496b3667"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6c3f4003-74db-4de0-9f2a-999c6e6d35e8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6fd657b3-dee2-41e0-a005-00d316623c11"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("783e91a1-65bb-4bb9-85c9-49a99fe94d10"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7ddd9432-d2a3-48c1-9b83-9ba6be59da8f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7ee56ed2-7c0a-4f6b-b054-cf9eff403c23"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("849e3a1c-00a7-4634-8400-cfd0722001ed"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("884997a2-a9b6-4728-abf2-0644a8b254c2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9516c418-c5a8-4065-8e82-ace029ba38d2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a28b4218-f1e5-449e-953b-458b38db7ffe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aa37ab85-ebd1-4d7c-9fca-59e0f314eb48"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ca947024-83ad-46fe-a7d3-13d6a07ff6d3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cb56f4d3-3c8f-4937-8585-670b5808a9b0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dc58a2b2-756e-4307-8752-7a6cc48d29b1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e0be20e9-a039-46e2-abcc-8c3909726295"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e64123bb-cbdf-4209-ad42-be14848a9d8b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e86e6440-5ccf-491b-a9cf-4f8ca1614dc3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("efe9ad7c-6364-4857-80de-ac2c2a4b26b9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f3aae1dd-8ac4-48d1-83fb-4e217a9f2fc7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f7101f7d-ac2d-4ca1-b89a-bb4aad3cbb67"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("069a7a09-40ca-4e1a-a273-9c69c13d51ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2bf5c86a-b398-42cb-8931-e78d13b49731"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("651a0707-b5cc-4f50-aa75-7baf9bba3253"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66450e28-fab3-40d6-8510-b0ab1789889b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("72f1c298-f316-467e-9030-9506e367a5f9"));

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
        }
    }
}
