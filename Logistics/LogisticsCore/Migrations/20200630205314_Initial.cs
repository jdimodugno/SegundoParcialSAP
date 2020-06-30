using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogisticsCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Node",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IdentifierName = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Node", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    Distance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportationVehicle",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationVehicle", x => x.LicensePlate);
                });

            migrationBuilder.CreateTable(
                name: "Path",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    OriginId = table.Column<Guid>(nullable: false),
                    DestinationId = table.Column<Guid>(nullable: false),
                    SegmentIdentifierName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Path", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Path_Node_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Node",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Path_Node_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Node",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RouteNode",
                columns: table => new
                {
                    RouteId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    NodeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteNode", x => new { x.RouteId, x.NodeId, x.Order });
                    table.ForeignKey(
                        name: "FK_RouteNode_Node_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Node",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteNode_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shipping",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateScheduled = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: true),
                    CurrentSegmentId = table.Column<Guid>(nullable: true),
                    RouteId = table.Column<Guid>(nullable: false),
                    TransportationVehicleLicensePlate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipping_Path_CurrentSegmentId",
                        column: x => x.CurrentSegmentId,
                        principalTable: "Path",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipping_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shipping_TransportationVehicle_TransportationVehicleLicensePlate",
                        column: x => x.TransportationVehicleLicensePlate,
                        principalTable: "TransportationVehicle",
                        principalColumn: "LicensePlate");
                });

            migrationBuilder.InsertData(
                table: "Node",
                columns: new[] { "Id", "IdentifierName", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), "CABA", -34.613149999999997, -58.377229999999997, "CABA" },
                    { new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), "CORDOBA", -31.416668000000001, -64.183334000000002, "Córdoba" },
                    { new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), "CORRIENTES", -27.471226000000001, -58.839584000000002, "Corrientes" },
                    { new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), "FORMOSA", -26.177530000000001, -58.178139999999999, "Formosa" },
                    { new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), "LA_PLATA", -34.920344999999998, -57.969558999999997, "La Plata" },
                    { new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), "LA_RIOJA", -29.411049999999999, -66.850669999999994, "La Rioja" },
                    { new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), "MENDOZA", -32.888354999999997, -68.838843999999995, "Mendoza" },
                    { new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), "NEUQUEN", -38.951610000000002, -68.059100000000001, "Neuquén" }
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "Detail", "Distance" },
                values: new object[,]
                {
                    { new Guid("7205cf14-eaba-44fa-a83b-c547e4427589"), "CORRIENTES - MENDOZA - CABA - LA_PLATA - CORRIENTES", 2999 },
                    { new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), "CORRIENTES - LA_PLATA - CABA - MENDOZA - CORDOBA - CORRIENTES", 3011 },
                    { new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), "MENDOZA - LA_PLATA - FORMOSA - CORDOBA - MENDOZA", 3287 },
                    { new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), "LA_RIOJA - CORRIENTES - CABA - LA_PLATA - NEUQUEN - CORDOBA - LA_RIOJA", 3911 },
                    { new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), "CORRIENTES - LA_PLATA - NEUQUEN - MENDOZA - LA_RIOJA - CORRIENTES", 3752 },
                    { new Guid("78a6ed32-a30b-4cfe-84d6-f1e67bce6bde"), "FORMOSA - CORRIENTES - CABA - LA_PLATA - FORMOSA", 1970 },
                    { new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), "LA_RIOJA - CORDOBA - NEUQUEN - CABA - FORMOSA - LA_RIOJA", 4096 },
                    { new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), "NEUQUEN - MENDOZA - LA_RIOJA - FORMOSA - CORDOBA - NEUQUEN", 3761 }
                });

            migrationBuilder.InsertData(
                table: "TransportationVehicle",
                columns: new[] { "LicensePlate", "Model", "Year" },
                values: new object[,]
                {
                    { "GAMMA_3", "Scania R 450", 2015 },
                    { "ALPHA_1", "Scania G 410", 2000 },
                    { "BETA_2", "Scania P 320", 2010 },
                    { "EPSILON_4", "Scania R 620", 2017 }
                });

            migrationBuilder.InsertData(
                table: "Path",
                columns: new[] { "Id", "DestinationId", "OriginId", "SegmentIdentifierName", "Weight" },
                values: new object[,]
                {
                    { new Guid("33d63672-1b3c-4759-b899-061fdcd0b0ff"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), "CABA-CORDOBA", 646 },
                    { new Guid("a86aa52d-a8dd-4c7f-98ad-589c5ccb777f"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), "CABA-MENDOZA", 985 },
                    { new Guid("cd0763aa-ee5e-4377-9d44-2af784764bff"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), "CORDOBA-MENDOZA", 466 },
                    { new Guid("380e5fbc-f34b-46b6-85b0-0984302438e9"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), "CORRIENTES-MENDOZA", 1131 },
                    { new Guid("62da53ee-6546-4636-9f7d-58320ca70792"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), "FORMOSA-MENDOZA", 1269 },
                    { new Guid("ea10c090-5ee0-40db-9fbf-deb73ba0065f"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), "LA_PLATA-MENDOZA", 1029 },
                    { new Guid("a014b9a5-7bda-4710-a1b4-9ce738ddcd5c"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), "LA_RIOJA-MENDOZA", 427 },
                    { new Guid("e712f373-88f3-47b9-9ae6-ad0fa2b37bed"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), "MENDOZA-CABA", 985 },
                    { new Guid("27ac43b0-d0f9-4469-a143-f82de63faf63"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), "MENDOZA-CORDOBA", 466 },
                    { new Guid("fcf6219a-5d0b-4bf5-bfc5-2b30b83d21f9"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), "MENDOZA-CORRIENTES", 1131 },
                    { new Guid("d5a734b8-8cb8-4889-a6f5-bfb3dbf73f7c"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), "MENDOZA-LA_PLATA", 1029 },
                    { new Guid("fced7571-c684-43f7-bee6-10a63788e9f3"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), "MENDOZA-LA_RIOJA", 427 },
                    { new Guid("029f2f90-d57d-4065-ba01-e09664223499"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), "CABA-NEUQUEN", 989 },
                    { new Guid("edd8f7c2-7488-4f4f-96b2-0b8d0f755c5c"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), "CORDOBA-NEUQUEN", 907 },
                    { new Guid("3b112c7e-1b4e-4026-b30b-573bd2c575ba"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), "CORRIENTES-NEUQUEN", 1534 },
                    { new Guid("16ef4ea0-a69c-4c06-adcf-41d3d847aaee"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), "FORMOSA-NEUQUEN", 1690 },
                    { new Guid("6cd40ca0-c99f-4ec5-82fb-59ca4b401d34"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), "LA_PLATA-NEUQUEN", 1005 },
                    { new Guid("3309c504-d0e5-4aad-8ee1-6c880c9be823"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), "LA_RIOJA-NEUQUEN", 1063 },
                    { new Guid("1311e88a-62b1-423f-9dba-b9c35f393585"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), "MENDOZA-NEUQUEN", 676 },
                    { new Guid("589ed2b0-990c-472c-a0fa-f5a97de79c04"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), "NEUQUEN-CABA", 989 },
                    { new Guid("1c49cb4f-edd6-4915-a2fb-033e2132ed9d"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), "NEUQUEN-CORDOBA", 907 },
                    { new Guid("5246612a-5bb0-4fca-81be-0607fcc4bf4c"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), "NEUQUEN-CORRIENTES", 1534 },
                    { new Guid("fd73aca9-ae3e-4ad0-b193-a43ec23feaa0"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), "NEUQUEN-FORMOSA", 1690 },
                    { new Guid("de36b12f-6ffc-4e98-bd68-aff85c5d69fe"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), "NEUQUEN-LA_PLATA", 1005 },
                    { new Guid("1c4d640a-f3d4-4816-8001-9647b69e55b4"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), "NEUQUEN-LA_RIOJA", 1063 },
                    { new Guid("cfb26a48-356f-46a9-8d16-a57ba6b66c1b"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), "NEUQUEN-MENDOZA", 676 },
                    { new Guid("e9b96bdd-7088-4cf7-87ef-87c46659efe2"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), "LA_RIOJA-LA_PLATA", 1038 },
                    { new Guid("ebedc388-6d17-4303-9432-580c991a0f19"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), "LA_RIOJA-FORMOSA", 927 },
                    { new Guid("8b1ee88b-e42e-4002-b6e7-7238c1a068df"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), "MENDOZA-FORMOSA", 1269 },
                    { new Guid("d1f70af7-79eb-4711-8e7e-a617ef016dff"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), "LA_RIOJA-CORDOBA", 340 },
                    { new Guid("8ceeb850-7344-4e93-a7ae-7c456861b8be"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), "CORDOBA-CABA", 646 },
                    { new Guid("f26ad063-acf8-43d2-8456-c31c148a6ac5"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), "CABA-CORRIENTES", 792 },
                    { new Guid("0539ea1e-02f4-437d-b8a1-8667515eb80f"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), "LA_RIOJA-CORRIENTES", 814 },
                    { new Guid("a089451c-5fc7-4210-8559-0abc08090b63"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), "CORRIENTES-CABA", 792 },
                    { new Guid("4c143705-fc10-4083-a6e1-f7b67b1d616b"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), "CORRIENTES-CORDOBA", 677 },
                    { new Guid("fb9f3d3b-7536-4b47-8fd0-4bb4e0980a16"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), "CABA-FORMOSA", 933 },
                    { new Guid("464170a4-c83b-483b-96fa-9a5e360a8354"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), "CORDOBA-FORMOSA", 824 },
                    { new Guid("5fed9efe-1019-4cc4-8aea-9f1798920eea"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), "CORRIENTES-FORMOSA", 157 },
                    { new Guid("3ab500ba-95aa-4553-ac52-ec10b2a984c4"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), "FORMOSA-CABA", 933 },
                    { new Guid("25d1ceae-aae3-4691-b56b-e3786094a137"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), "FORMOSA-CORDOBA", 824 },
                    { new Guid("3df33ba3-3396-4b23-adc3-a4d9c6eaffe2"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), "FORMOSA-CORRIENTES", 157 },
                    { new Guid("572f803a-78fd-4df5-94ef-acd475c1d033"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), "CABA-LA_PLATA", 53 },
                    { new Guid("37c7fda5-2989-4a01-b145-bf0b7882b0b8"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), "CORDOBA-LA_PLATA", 698 },
                    { new Guid("909befe3-5901-4598-97b7-61012f52979f"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), "CORDOBA-CORRIENTES", 677 },
                    { new Guid("b7d96228-8df4-40ff-b535-833b8bf16d3c"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), "FORMOSA-LA_PLATA", 968 },
                    { new Guid("2c2ef3ed-4c2f-49c5-a129-55fa6c5f65f3"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), "CORRIENTES-LA_PLATA", 830 },
                    { new Guid("899aa944-e5e6-4282-9902-11cc12a5924b"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), "LA_RIOJA-CABA", 986 },
                    { new Guid("72613eae-1ad5-46a1-aaea-433a982b1c36"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), "FORMOSA-LA_RIOJA", 927 },
                    { new Guid("de930c55-de32-4cf0-b6f8-f9a88bd87b77"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), "CORRIENTES-LA_RIOJA", 814 },
                    { new Guid("7cde9b53-bde6-4bd4-997e-ae5155ee1960"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), "CORDOBA-LA_RIOJA", 340 },
                    { new Guid("4a316b55-2ae4-4ca8-80c6-9a64bda9a4b8"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), "LA_PLATA-LA_RIOJA", 1038 },
                    { new Guid("8a639432-687f-4769-a803-7866acd3daac"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), "LA_PLATA-FORMOSA", 968 },
                    { new Guid("ea9e0541-9716-43e7-b4e8-282be7f49332"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), "LA_PLATA-CORRIENTES", 830 },
                    { new Guid("8c263b86-ac04-406e-8899-9ba0ae533e4b"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), "LA_PLATA-CORDOBA", 698 },
                    { new Guid("0415f6d9-a438-421a-ae74-334681442180"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), "LA_PLATA-CABA", 53 },
                    { new Guid("fef4a3e8-e7fc-43bc-8284-2f58adc466d2"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), "CABA-LA_RIOJA", 986 }
                });

            migrationBuilder.InsertData(
                table: "RouteNode",
                columns: new[] { "RouteId", "NodeId", "Order" },
                values: new object[,]
                {
                    { new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), 4 },
                    { new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), 3 },
                    { new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), 4 },
                    { new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), 5 },
                    { new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), 6 },
                    { new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), 7 },
                    { new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), 1 },
                    { new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), 2 },
                    { new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), 3 },
                    { new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), 5 },
                    { new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), 6 },
                    { new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), 2 },
                    { new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), 3 },
                    { new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), 4 },
                    { new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), 5 },
                    { new Guid("7205cf14-eaba-44fa-a83b-c547e4427589"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), 1 },
                    { new Guid("7205cf14-eaba-44fa-a83b-c547e4427589"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), 2 },
                    { new Guid("7205cf14-eaba-44fa-a83b-c547e4427589"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), 3 },
                    { new Guid("7205cf14-eaba-44fa-a83b-c547e4427589"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), 4 },
                    { new Guid("7205cf14-eaba-44fa-a83b-c547e4427589"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), 5 },
                    { new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), 2 },
                    { new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), 1 },
                    { new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), 1 },
                    { new Guid("78a6ed32-a30b-4cfe-84d6-f1e67bce6bde"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), 2 },
                    { new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), 5 },
                    { new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), 6 },
                    { new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), 1 },
                    { new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), new Guid("a4a245bf-03c0-4f40-aff5-7dcb1a3b1a5c"), 2 },
                    { new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), 4 },
                    { new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), 5 },
                    { new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), 6 },
                    { new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), 1 },
                    { new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), 2 },
                    { new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), 3 },
                    { new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), 4 },
                    { new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), 3 },
                    { new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), new Guid("80899bc6-4906-4165-bc3c-d183e0a2da28"), 6 },
                    { new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), 5 },
                    { new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), new Guid("6397a4d0-ac78-47e8-84e1-8d8294bd2b8f"), 3 },
                    { new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), new Guid("e6689645-b9b7-4157-bb31-f01834331e13"), 1 },
                    { new Guid("78a6ed32-a30b-4cfe-84d6-f1e67bce6bde"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), 5 },
                    { new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), new Guid("c8245920-9382-494e-a20f-aaef16ad15e2"), 2 },
                    { new Guid("78a6ed32-a30b-4cfe-84d6-f1e67bce6bde"), new Guid("e090d74f-3f99-42b1-b248-68c6b7ab5c96"), 3 },
                    { new Guid("78a6ed32-a30b-4cfe-84d6-f1e67bce6bde"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), 1 },
                    { new Guid("78a6ed32-a30b-4cfe-84d6-f1e67bce6bde"), new Guid("c2e5b0ad-e569-42f2-a1d7-23339305c8f0"), 4 },
                    { new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), new Guid("30e1b05b-14bc-40ad-83fa-6298f31e12ce"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "CurrentSegmentId", "DateCompleted", "DateScheduled", "RouteId", "Status", "TransportationVehicleLicensePlate" },
                values: new object[,]
                {
                    { new Guid("90b4b04f-9417-44f9-bee7-9fdf2440f6b1"), null, new DateTime(2020, 4, 2, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6920), new DateTime(2020, 3, 30, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6920), new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), 1, "GAMMA_3" },
                    { new Guid("f0f269e5-1e21-4bc0-917d-37110dfa749a"), null, new DateTime(2020, 3, 9, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7190), new DateTime(2020, 3, 6, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7190), new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), 1, "GAMMA_3" },
                    { new Guid("d45720fd-c44b-4ae7-b164-12cc023fe592"), null, new DateTime(2020, 4, 6, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6920), new DateTime(2020, 4, 3, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6920), new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), 1, "GAMMA_3" },
                    { new Guid("7233b3f5-1ae1-456b-a24a-46d9f9c55866"), null, new DateTime(2020, 3, 29, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7160), new DateTime(2020, 3, 26, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7160), new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), 1, "GAMMA_3" },
                    { new Guid("280a69b8-d5e0-48e5-8645-088804adb81a"), null, new DateTime(2020, 3, 25, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7170), new DateTime(2020, 3, 22, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7170), new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), 1, "GAMMA_3" },
                    { new Guid("6f236aab-16c0-4950-9bb9-99efb2fa4cc9"), null, new DateTime(2020, 3, 21, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7170), new DateTime(2020, 3, 18, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7170), new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), 1, "GAMMA_3" },
                    { new Guid("8e583e2d-0841-4901-be03-d1ff1ac6ee35"), null, new DateTime(2020, 3, 13, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7190), new DateTime(2020, 3, 10, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7190), new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), 1, "GAMMA_3" },
                    { new Guid("4a56eff9-a924-472f-95c6-aebb3b47d2f6"), null, new DateTime(2020, 2, 22, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7220), new DateTime(2020, 2, 19, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7220), new Guid("7205cf14-eaba-44fa-a83b-c547e4427589"), 1, "EPSILON_4" },
                    { new Guid("0808a5f2-613e-4963-bf20-2ffe6de72e7d"), null, new DateTime(2020, 3, 1, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7210), new DateTime(2020, 2, 27, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7210), new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), 1, "EPSILON_4" },
                    { new Guid("32776d56-ed5d-4b5a-a6da-1dba5f2a0c9c"), null, new DateTime(2020, 2, 26, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7210), new DateTime(2020, 2, 23, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7210), new Guid("7205cf14-eaba-44fa-a83b-c547e4427589"), 1, "EPSILON_4" },
                    { new Guid("3cae1dd2-81c7-4134-b6b1-52633d7a7533"), null, new DateTime(2020, 2, 18, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7220), new DateTime(2020, 2, 15, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7220), new Guid("7205cf14-eaba-44fa-a83b-c547e4427589"), 1, "EPSILON_4" },
                    { new Guid("2a44d112-f096-4ae8-ae7f-0d9e7bdd4484"), null, new DateTime(2020, 2, 14, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7230), new DateTime(2020, 2, 11, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7230), new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), 1, "EPSILON_4" },
                    { new Guid("78abebf9-9841-4037-ad67-964fd6bca374"), null, new DateTime(2020, 2, 10, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7230), new DateTime(2020, 2, 7, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7230), new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), 1, "EPSILON_4" },
                    { new Guid("1e3ef17b-203d-481a-8dd2-3dab9711546d"), null, new DateTime(2020, 4, 10, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6910), new DateTime(2020, 4, 7, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6910), new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), 1, "GAMMA_3" },
                    { new Guid("e90ca4d9-7752-4f2b-a914-c2aac28016e1"), null, new DateTime(2020, 2, 6, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7230), new DateTime(2020, 2, 3, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7230), new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), 1, "EPSILON_4" },
                    { new Guid("faac2394-2fb3-4e31-8940-18372a200fca"), null, new DateTime(2020, 3, 5, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7200), new DateTime(2020, 3, 2, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7200), new Guid("7205cf14-eaba-44fa-a83b-c547e4427589"), 1, "EPSILON_4" },
                    { new Guid("e75317a2-f5bc-415b-a201-f158002854af"), null, null, new DateTime(2020, 7, 18, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6910), new Guid("2f4b3283-5633-49ec-bf68-cc21719eebdd"), 0, "GAMMA_3" },
                    { new Guid("1251e3fb-c2a7-4870-b113-fee4581588eb"), null, new DateTime(2020, 6, 5, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4490), new DateTime(2020, 6, 2, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4490), new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), 1, "ALPHA_1" },
                    { new Guid("9ce39451-5685-4bbc-94ee-a77717fe65f7"), null, new DateTime(2020, 4, 26, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6860), new DateTime(2020, 4, 23, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6860), new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), 1, "BETA_2" },
                    { new Guid("78b224cd-620f-4cac-9493-4b60a8c740ca"), null, new DateTime(2020, 2, 2, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7240), new DateTime(2020, 1, 30, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7240), new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), 1, "EPSILON_4" },
                    { new Guid("41bdefb2-714d-4f9d-8fa0-c460fad12aaf"), null, null, new DateTime(2020, 7, 12, 17, 53, 13, 763, DateTimeKind.Local).AddTicks(9280), new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), 0, "ALPHA_1" },
                    { new Guid("38769566-f5eb-4e20-b593-fd9582bdd555"), null, new DateTime(2020, 6, 29, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(2920), new DateTime(2020, 6, 26, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(2920), new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), 1, "ALPHA_1" },
                    { new Guid("567134f7-9cb9-4c1d-ac04-5a77b583bd6b"), null, new DateTime(2020, 6, 25, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4430), new DateTime(2020, 6, 22, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4430), new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), 1, "ALPHA_1" },
                    { new Guid("d13456ec-530f-4e68-87d9-1e30c2587429"), null, new DateTime(2020, 6, 21, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4460), new DateTime(2020, 6, 18, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4460), new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), 1, "ALPHA_1" },
                    { new Guid("f24b939b-a81e-4f66-bc1c-21e380aa5f44"), null, new DateTime(2020, 6, 17, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4470), new DateTime(2020, 6, 14, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4470), new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), 1, "ALPHA_1" },
                    { new Guid("e6dd576d-d442-4d53-88a7-f0aa9d57f254"), null, new DateTime(2020, 6, 13, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4480), new DateTime(2020, 6, 10, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4480), new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), 1, "ALPHA_1" },
                    { new Guid("837e7ff9-c056-4654-9007-b33c46ffeb01"), null, new DateTime(2020, 4, 18, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6900), new DateTime(2020, 4, 15, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6900), new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), 1, "BETA_2" },
                    { new Guid("dd458b44-3db2-49c3-b7e4-94f6afe3b6f8"), null, new DateTime(2020, 6, 9, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4490), new DateTime(2020, 6, 6, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4490), new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), 1, "ALPHA_1" },
                    { new Guid("35208d6e-9a61-45d8-95a1-31352d1c5e44"), null, null, new DateTime(2020, 7, 18, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6790), new Guid("78a6ed32-a30b-4cfe-84d6-f1e67bce6bde"), 0, "BETA_2" },
                    { new Guid("e9abceb9-0abb-4c89-b0bd-e596ecb218c6"), null, new DateTime(2020, 5, 20, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6810), new DateTime(2020, 5, 17, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6810), new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), 1, "BETA_2" },
                    { new Guid("2f2b3f57-42dd-4d1e-aa65-c6b9c46a81ab"), null, new DateTime(2020, 5, 16, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6810), new DateTime(2020, 5, 13, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6810), new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), 1, "BETA_2" },
                    { new Guid("20869236-d88c-4341-9818-a61209e4a966"), null, new DateTime(2020, 5, 12, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6820), new DateTime(2020, 5, 9, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6820), new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), 1, "BETA_2" },
                    { new Guid("b34f00ee-6198-4287-acd1-91e6e69682b9"), null, new DateTime(2020, 5, 8, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6820), new DateTime(2020, 5, 5, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6820), new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), 1, "BETA_2" },
                    { new Guid("28238c60-f1a2-4803-b6b5-93360d1692e0"), null, new DateTime(2020, 5, 4, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6830), new DateTime(2020, 5, 1, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6830), new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), 1, "BETA_2" },
                    { new Guid("902414e7-62ee-416f-af3f-ace5163399b2"), null, new DateTime(2020, 4, 30, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6830), new DateTime(2020, 4, 27, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6830), new Guid("78a6ed32-a30b-4cfe-84d6-f1e67bce6bde"), 1, "BETA_2" },
                    { new Guid("baccddf7-dee4-4cee-842f-09c26f9150dd"), null, new DateTime(2020, 6, 1, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4500), new DateTime(2020, 5, 29, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4500), new Guid("a7d2740c-8ecc-4498-b5c4-d9671c894640"), 1, "ALPHA_1" },
                    { new Guid("bdc62c9a-fd8d-4a6f-97e7-9f7bc5f287a9"), null, new DateTime(2020, 1, 29, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7240), new DateTime(2020, 1, 26, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7240), new Guid("16be5ffb-352f-466b-b0ab-9e7f1a748b1a"), 1, "EPSILON_4" }
                });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "CurrentSegmentId", "DateCompleted", "DateScheduled", "RouteId", "Status", "TransportationVehicleLicensePlate" },
                values: new object[] { new Guid("067d730a-4005-4850-b851-b83871d69d7c"), new Guid("25d1ceae-aae3-4691-b56b-e3786094a137"), null, new DateTime(2020, 7, 3, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(7180), new Guid("77e03db2-a2ed-46c4-bcd7-15f6bfec8faf"), 2, "GAMMA_3" });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "CurrentSegmentId", "DateCompleted", "DateScheduled", "RouteId", "Status", "TransportationVehicleLicensePlate" },
                values: new object[] { new Guid("fec66c38-0819-4862-9f23-029407d2527e"), new Guid("ebedc388-6d17-4303-9432-580c991a0f19"), null, new DateTime(2020, 7, 2, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(6860), new Guid("1eb8608f-40aa-4539-90c6-5a01bb51ca3c"), 2, "BETA_2" });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "CurrentSegmentId", "DateCompleted", "DateScheduled", "RouteId", "Status", "TransportationVehicleLicensePlate" },
                values: new object[] { new Guid("2a113c2c-4431-4b26-b978-22c248ac1b59"), new Guid("6cd40ca0-c99f-4ec5-82fb-59ca4b401d34"), null, new DateTime(2020, 7, 1, 17, 53, 13, 777, DateTimeKind.Local).AddTicks(4500), new Guid("730d543a-584e-4fc8-a802-174a69b88aa0"), 2, "ALPHA_1" });

            migrationBuilder.CreateIndex(
                name: "IX_Path_DestinationId",
                table: "Path",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Path_OriginId_DestinationId",
                table: "Path",
                columns: new[] { "OriginId", "DestinationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteNode_NodeId",
                table: "RouteNode",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_CurrentSegmentId",
                table: "Shipping",
                column: "CurrentSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_RouteId",
                table: "Shipping",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_TransportationVehicleLicensePlate",
                table: "Shipping",
                column: "TransportationVehicleLicensePlate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteNode");

            migrationBuilder.DropTable(
                name: "Shipping");

            migrationBuilder.DropTable(
                name: "Path");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "TransportationVehicle");

            migrationBuilder.DropTable(
                name: "Node");
        }
    }
}
