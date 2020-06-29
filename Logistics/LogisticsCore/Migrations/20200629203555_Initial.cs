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
                    OriginId = table.Column<Guid>(nullable: false),
                    DestinationId = table.Column<Guid>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    SegmentIdentifierName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Path", x => new { x.OriginId, x.DestinationId });
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
                    CurrentSegment = table.Column<string>(nullable: true),
                    RouteId = table.Column<Guid>(nullable: false),
                    TransportationVehicleLicensePlate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping", x => x.Id);
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
                    { new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), "CABA", -34.613149999999997, -58.377229999999997, "CABA" },
                    { new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), "CORDOBA", -31.416668000000001, -64.183334000000002, "Córdoba" },
                    { new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), "CORRIENTES", -27.471226000000001, -58.839584000000002, "Corrientes" },
                    { new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), "FORMOSA", -26.177530000000001, -58.178139999999999, "Formosa" },
                    { new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), "LA_PLATA", -34.920344999999998, -57.969558999999997, "La Plata" },
                    { new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), "LA_RIOJA", -29.411049999999999, -66.850669999999994, "La Rioja" },
                    { new Guid("2d798aea-dccb-457c-b694-489b25742641"), "MENDOZA", -32.888354999999997, -68.838843999999995, "Mendoza" },
                    { new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), "NEUQUEN", -38.951610000000002, -68.059100000000001, "Neuquén" }
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "Detail", "Distance" },
                values: new object[,]
                {
                    { new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), "CORRIENTES - LA_PLATA - CABA - MENDOZA - CORDOBA - CORRIENTES", 3011 },
                    { new Guid("a858ad55-d21e-4df3-b391-4d596d5f691c"), "MENDOZA - LA_PLATA - FORMOSA - CORDOBA - MENDOZA", 3287 },
                    { new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), "LA_RIOJA - CORRIENTES - CABA - LA_PLATA - NEUQUEN - CORDOBA - LA_RIOJA", 3911 },
                    { new Guid("325281d9-d884-4268-ac95-765d64751d17"), "CORRIENTES - LA_PLATA - NEUQUEN - MENDOZA - LA_RIOJA - CORRIENTES", 3752 },
                    { new Guid("a09a584f-dcf9-4580-a591-f84cbd624081"), "FORMOSA - CORRIENTES - CABA - LA_PLATA - FORMOSA", 1970 },
                    { new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), "LA_RIOJA - CORDOBA - NEUQUEN - CABA - FORMOSA - LA_RIOJA", 4096 },
                    { new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), "NEUQUEN - MENDOZA - LA_RIOJA - FORMOSA - CORDOBA - NEUQUEN", 3761 }
                });

            migrationBuilder.InsertData(
                table: "TransportationVehicle",
                columns: new[] { "LicensePlate", "Model", "Year" },
                values: new object[,]
                {
                    { "SCANIA_3", "Scania R 450", 2015 },
                    { "SCANIA_1", "Scania G 410", 2000 },
                    { "SCANIA_2", "Scania P 320", 2010 },
                    { "SCANIA_4", "Scania R 620", 2017 }
                });

            migrationBuilder.InsertData(
                table: "Path",
                columns: new[] { "OriginId", "DestinationId", "SegmentIdentifierName", "Weight" },
                values: new object[,]
                {
                    { new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), "CABA-CORDOBA", 646 },
                    { new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), "CABA-MENDOZA", 985 },
                    { new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), "CORDOBA-MENDOZA", 466 },
                    { new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), "CORRIENTES-MENDOZA", 1131 },
                    { new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), "FORMOSA-MENDOZA", 1269 },
                    { new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), "LA_PLATA-MENDOZA", 1029 },
                    { new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), "LA_RIOJA-MENDOZA", 427 },
                    { new Guid("2d798aea-dccb-457c-b694-489b25742641"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), "MENDOZA-CABA", 985 },
                    { new Guid("2d798aea-dccb-457c-b694-489b25742641"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), "MENDOZA-CORRIENTES", 1131 },
                    { new Guid("2d798aea-dccb-457c-b694-489b25742641"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), "MENDOZA-FORMOSA", 1269 },
                    { new Guid("2d798aea-dccb-457c-b694-489b25742641"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), "MENDOZA-LA_PLATA", 1029 },
                    { new Guid("2d798aea-dccb-457c-b694-489b25742641"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), "MENDOZA-LA_RIOJA", 427 },
                    { new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), "CABA-NEUQUEN", 989 },
                    { new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), "CORDOBA-NEUQUEN", 907 },
                    { new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), "CORRIENTES-NEUQUEN", 1534 },
                    { new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), "FORMOSA-NEUQUEN", 1690 },
                    { new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), "LA_PLATA-NEUQUEN", 1005 },
                    { new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), "LA_RIOJA-NEUQUEN", 1063 },
                    { new Guid("2d798aea-dccb-457c-b694-489b25742641"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), "MENDOZA-NEUQUEN", 676 },
                    { new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), "NEUQUEN-CABA", 989 },
                    { new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), "NEUQUEN-CORDOBA", 907 },
                    { new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), "NEUQUEN-CORRIENTES", 1534 },
                    { new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), "NEUQUEN-FORMOSA", 1690 },
                    { new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), "NEUQUEN-LA_PLATA", 1005 },
                    { new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), "NEUQUEN-LA_RIOJA", 1063 },
                    { new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), "NEUQUEN-MENDOZA", 676 },
                    { new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), "LA_RIOJA-LA_PLATA", 1038 },
                    { new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), "LA_RIOJA-FORMOSA", 927 },
                    { new Guid("2d798aea-dccb-457c-b694-489b25742641"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), "MENDOZA-CORDOBA", 466 },
                    { new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), "LA_RIOJA-CORDOBA", 340 },
                    { new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), "CORDOBA-CABA", 646 },
                    { new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), "CABA-CORRIENTES", 792 },
                    { new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), "CORDOBA-CORRIENTES", 677 },
                    { new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), "LA_RIOJA-CORRIENTES", 814 },
                    { new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), "CORRIENTES-CORDOBA", 677 },
                    { new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), "CABA-FORMOSA", 933 },
                    { new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), "CORDOBA-FORMOSA", 824 },
                    { new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), "CORRIENTES-FORMOSA", 157 },
                    { new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), "FORMOSA-CABA", 933 },
                    { new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), "FORMOSA-CORDOBA", 824 },
                    { new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), "FORMOSA-CORRIENTES", 157 },
                    { new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), "CABA-LA_PLATA", 53 },
                    { new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), "CORDOBA-LA_PLATA", 698 },
                    { new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), "CORRIENTES-CABA", 792 },
                    { new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), "FORMOSA-LA_PLATA", 968 },
                    { new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), "CORRIENTES-LA_PLATA", 830 },
                    { new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), "LA_RIOJA-CABA", 986 },
                    { new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), "FORMOSA-LA_RIOJA", 927 },
                    { new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), "CORRIENTES-LA_RIOJA", 814 },
                    { new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), "CORDOBA-LA_RIOJA", 340 },
                    { new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), "LA_PLATA-LA_RIOJA", 1038 },
                    { new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), "LA_PLATA-FORMOSA", 968 },
                    { new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), "LA_PLATA-CORRIENTES", 830 },
                    { new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), "LA_PLATA-CORDOBA", 698 },
                    { new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), "LA_PLATA-CABA", 53 },
                    { new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), "CABA-LA_RIOJA", 986 }
                });

            migrationBuilder.InsertData(
                table: "RouteNode",
                columns: new[] { "RouteId", "NodeId", "Order" },
                values: new object[,]
                {
                    { new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), 1 },
                    { new Guid("a858ad55-d21e-4df3-b391-4d596d5f691c"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), 1 },
                    { new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), 2 },
                    { new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), 3 },
                    { new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), 4 },
                    { new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), 5 },
                    { new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), 6 },
                    { new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), 7 },
                    { new Guid("a858ad55-d21e-4df3-b391-4d596d5f691c"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), 2 },
                    { new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), 3 },
                    { new Guid("a858ad55-d21e-4df3-b391-4d596d5f691c"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), 4 },
                    { new Guid("a858ad55-d21e-4df3-b391-4d596d5f691c"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), 5 },
                    { new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), 1 },
                    { new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), 2 },
                    { new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), 4 },
                    { new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), 5 },
                    { new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), 6 },
                    { new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), 6 },
                    { new Guid("a858ad55-d21e-4df3-b391-4d596d5f691c"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), 3 },
                    { new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), 5 },
                    { new Guid("a09a584f-dcf9-4580-a591-f84cbd624081"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), 1 },
                    { new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), 3 },
                    { new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), 4 },
                    { new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), new Guid("03566cd3-a968-4795-966c-f96882b8a72c"), 2 },
                    { new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), 3 },
                    { new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), 4 },
                    { new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), 5 },
                    { new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), 6 },
                    { new Guid("325281d9-d884-4268-ac95-765d64751d17"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), 1 },
                    { new Guid("325281d9-d884-4268-ac95-765d64751d17"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), 2 },
                    { new Guid("325281d9-d884-4268-ac95-765d64751d17"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), 3 },
                    { new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), 1 },
                    { new Guid("325281d9-d884-4268-ac95-765d64751d17"), new Guid("a323c1a9-01ff-49a0-bb2e-8993039648c2"), 5 },
                    { new Guid("325281d9-d884-4268-ac95-765d64751d17"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), 6 },
                    { new Guid("a09a584f-dcf9-4580-a591-f84cbd624081"), new Guid("de1cb888-20c0-4f54-99ec-f011206566b4"), 2 },
                    { new Guid("a09a584f-dcf9-4580-a591-f84cbd624081"), new Guid("70bf3253-1e35-4045-86f0-1364f92f7b98"), 3 },
                    { new Guid("a09a584f-dcf9-4580-a591-f84cbd624081"), new Guid("c25cbacb-0811-4ca9-b397-953e44c45d12"), 4 },
                    { new Guid("a09a584f-dcf9-4580-a591-f84cbd624081"), new Guid("c9464a1e-be38-438f-a6e7-ae8d1144d21b"), 5 },
                    { new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), new Guid("de1449c8-ab97-4fb3-925d-8ad816283ada"), 1 },
                    { new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), 2 },
                    { new Guid("325281d9-d884-4268-ac95-765d64751d17"), new Guid("2d798aea-dccb-457c-b694-489b25742641"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "CurrentSegment", "DateCompleted", "DateScheduled", "RouteId", "Status", "TransportationVehicleLicensePlate" },
                values: new object[,]
                {
                    { new Guid("1d4c1323-3929-4847-9ab2-81854186cbe8"), null, null, new DateTime(2020, 7, 9, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7970), new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), 0, "SCANIA_3" },
                    { new Guid("540006bc-657e-491b-b049-8167bb257a91"), null, null, new DateTime(2020, 7, 11, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7960), new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), 0, "SCANIA_3" },
                    { new Guid("8f319325-e6ed-4222-b717-bd6e0df926e1"), null, null, new DateTime(2020, 7, 8, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7910), new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), 0, "SCANIA_3" },
                    { new Guid("416cc51f-8202-440d-bb3a-4ee0d8ba8535"), null, null, new DateTime(2020, 7, 14, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7940), new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), 0, "SCANIA_3" },
                    { new Guid("78db4147-7baf-4e2e-8e92-e8855866e21d"), null, null, new DateTime(2020, 7, 10, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7920), new Guid("a09a584f-dcf9-4580-a591-f84cbd624081"), 0, "SCANIA_3" },
                    { new Guid("2d8d0805-8217-4546-be28-ee356afe469b"), null, null, new DateTime(2020, 7, 18, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7900), new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), 0, "SCANIA_3" },
                    { new Guid("356b2cf8-ae30-42ad-b941-edf99c117802"), null, null, new DateTime(2020, 7, 9, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7950), new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), 0, "SCANIA_3" },
                    { new Guid("3b1bf70f-0edb-4e0d-a799-7be9a49e902b"), null, null, new DateTime(2020, 7, 16, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7990), new Guid("325281d9-d884-4268-ac95-765d64751d17"), 0, "SCANIA_3" },
                    { new Guid("2f9fb849-ffb4-40b5-84a4-d92e26d08658"), null, null, new DateTime(2020, 7, 13, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8030), new Guid("325281d9-d884-4268-ac95-765d64751d17"), 0, "SCANIA_4" },
                    { new Guid("52fa0979-7abb-4a25-b8dd-a0141555b902"), "LA_RIOJA-CORDOBA", null, new DateTime(2020, 6, 27, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8000), new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), 2, "SCANIA_4" },
                    { new Guid("5e805636-e28f-43f1-8174-190efbc36b93"), null, null, new DateTime(2020, 7, 14, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8020), new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), 0, "SCANIA_4" },
                    { new Guid("5c5b96ba-b5e9-4030-9db3-c4b2efab38f4"), null, null, new DateTime(2020, 7, 15, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8050), new Guid("a858ad55-d21e-4df3-b391-4d596d5f691c"), 0, "SCANIA_4" },
                    { new Guid("addc39d3-988a-4bf9-9c81-837175da1453"), null, null, new DateTime(2020, 7, 10, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8060), new Guid("a858ad55-d21e-4df3-b391-4d596d5f691c"), 0, "SCANIA_4" },
                    { new Guid("126c35b7-90a5-44ef-838a-5add0b3eeb99"), null, null, new DateTime(2020, 7, 10, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8070), new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), 0, "SCANIA_4" },
                    { new Guid("ee897850-31a1-40df-9396-ec933a726cb9"), null, null, new DateTime(2020, 7, 6, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8080), new Guid("325281d9-d884-4268-ac95-765d64751d17"), 0, "SCANIA_4" },
                    { new Guid("7c1c638d-da8f-42cc-8147-5f80e625f555"), "CORDOBA-LA_RIOJA", null, new DateTime(2020, 6, 26, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7880), new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), 2, "SCANIA_3" },
                    { new Guid("933fab86-8c59-4b1e-b7a7-953973a8690a"), null, null, new DateTime(2020, 7, 7, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8100), new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), 0, "SCANIA_4" },
                    { new Guid("88ca0797-8c64-474f-8a87-77afc4f5be47"), null, null, new DateTime(2020, 7, 10, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8000), new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), 0, "SCANIA_3" },
                    { new Guid("f9d9bc86-7e98-46a8-8783-db14c1e9a342"), null, null, new DateTime(2020, 7, 7, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7880), new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), 0, "SCANIA_2" },
                    { new Guid("1e3d3f18-9e28-4252-b00d-b1b85edc7a98"), null, null, new DateTime(2020, 7, 13, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7670), new Guid("a858ad55-d21e-4df3-b391-4d596d5f691c"), 0, "SCANIA_1" },
                    { new Guid("606f4f28-c703-47f8-a28b-0bc8ca5b8f92"), null, null, new DateTime(2020, 7, 17, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7850), new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), 0, "SCANIA_2" },
                    { new Guid("9da3e363-a762-4064-8c78-b0222dacd709"), null, null, new DateTime(2020, 7, 14, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8110), new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), 0, "SCANIA_4" },
                    { new Guid("0e1f2f2e-1ef5-4972-bad1-39e9b48a6d55"), "LA_PLATA-CABA", null, new DateTime(2020, 6, 27, 17, 35, 54, 649, DateTimeKind.Local).AddTicks(6300), new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), 2, "SCANIA_1" },
                    { new Guid("40996715-90e0-4ece-b815-76d23dccc2de"), null, null, new DateTime(2020, 7, 10, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7510), new Guid("a858ad55-d21e-4df3-b391-4d596d5f691c"), 0, "SCANIA_1" },
                    { new Guid("5a87c6ac-7792-4188-aabb-3283c45c0380"), null, null, new DateTime(2020, 7, 14, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7560), new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), 0, "SCANIA_1" },
                    { new Guid("fcd7a3c2-efdf-4412-94c4-b73de61669d0"), null, null, new DateTime(2020, 7, 6, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7580), new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), 0, "SCANIA_1" },
                    { new Guid("62acd632-b241-4af3-88a0-e4f7a3b59ab7"), null, null, new DateTime(2020, 7, 17, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7590), new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), 0, "SCANIA_1" },
                    { new Guid("0f2d7850-6c98-4963-9ece-724937f122d0"), null, null, new DateTime(2020, 7, 10, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7610), new Guid("325281d9-d884-4268-ac95-765d64751d17"), 0, "SCANIA_1" },
                    { new Guid("55f762a0-1730-41b0-9263-ab7968c47007"), null, null, new DateTime(2020, 7, 8, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7630), new Guid("325281d9-d884-4268-ac95-765d64751d17"), 0, "SCANIA_1" },
                    { new Guid("368c9b75-6327-4712-a044-4d29be2361aa"), null, null, new DateTime(2020, 7, 15, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7640), new Guid("a09a584f-dcf9-4580-a591-f84cbd624081"), 0, "SCANIA_1" },
                    { new Guid("5a5df9d5-6cac-4a56-96f3-ffa581c4f2f4"), null, null, new DateTime(2020, 7, 14, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7650), new Guid("325281d9-d884-4268-ac95-765d64751d17"), 0, "SCANIA_1" },
                    { new Guid("ca739277-ba56-48da-bd26-dae77fc7971e"), "MENDOZA-LA_RIOJA", null, new DateTime(2020, 6, 28, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7670), new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), 2, "SCANIA_2" },
                    { new Guid("289f1115-b2a8-453f-89b1-1720a52f8419"), null, null, new DateTime(2020, 7, 12, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7710), new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), 0, "SCANIA_2" },
                    { new Guid("b783861f-3804-4060-8244-5ca5a0e49d4d"), null, null, new DateTime(2020, 7, 8, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7720), new Guid("f05862c8-a668-48e2-bd5c-7b5299e8f441"), 0, "SCANIA_2" },
                    { new Guid("f1780910-2e43-4d70-a1f4-4aefcade6199"), null, null, new DateTime(2020, 7, 7, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7730), new Guid("a09a584f-dcf9-4580-a591-f84cbd624081"), 0, "SCANIA_2" },
                    { new Guid("4383b5bc-58f8-4350-8598-008819cad4ed"), null, null, new DateTime(2020, 7, 15, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7750), new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), 0, "SCANIA_2" },
                    { new Guid("e342589e-4f3e-491d-a705-ccaabeaba814"), null, null, new DateTime(2020, 7, 4, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7760), new Guid("02adbc1e-cf29-45f0-8da6-c1d2048d55b9"), 0, "SCANIA_2" },
                    { new Guid("9bd0a779-6663-4c4e-bd9a-cb4774b464e2"), null, null, new DateTime(2020, 7, 9, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7830), new Guid("aec7ff0e-1c13-4215-874c-5e8faa3d227c"), 0, "SCANIA_2" },
                    { new Guid("9256ac4f-a61a-40d3-839a-3879daa9b125"), null, null, new DateTime(2020, 7, 11, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(7870), new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), 0, "SCANIA_2" },
                    { new Guid("3a134301-92e1-45a0-893d-e6d846e38988"), null, null, new DateTime(2020, 7, 5, 17, 35, 54, 661, DateTimeKind.Local).AddTicks(8120), new Guid("668379c4-1cba-4be0-bfeb-3644e4fc8d92"), 0, "SCANIA_4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Path_DestinationId",
                table: "Path",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteNode_NodeId",
                table: "RouteNode",
                column: "NodeId");

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
                name: "Path");

            migrationBuilder.DropTable(
                name: "RouteNode");

            migrationBuilder.DropTable(
                name: "Shipping");

            migrationBuilder.DropTable(
                name: "Node");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "TransportationVehicle");
        }
    }
}
