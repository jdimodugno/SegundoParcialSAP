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
                    { new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), "CABA", -34.613149999999997, -58.377229999999997, "CABA" },
                    { new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), "CORDOBA", -31.416668000000001, -64.183334000000002, "Córdoba" },
                    { new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), "CORRIENTES", -27.471226000000001, -58.839584000000002, "Corrientes" },
                    { new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), "FORMOSA", -26.177530000000001, -58.178139999999999, "Formosa" },
                    { new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), "LA_PLATA", -34.920344999999998, -57.969558999999997, "La Plata" },
                    { new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), "LA_RIOJA", -29.411049999999999, -66.850669999999994, "La Rioja" },
                    { new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), "MENDOZA", -32.888354999999997, -68.838843999999995, "Mendoza" },
                    { new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), "NEUQUEN", -38.951610000000002, -68.059100000000001, "Neuquén" }
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "Detail", "Distance" },
                values: new object[,]
                {
                    { new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), "CORRIENTES - LA_PLATA - CABA - MENDOZA - CORDOBA - CORRIENTES", 3011 },
                    { new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), "MENDOZA - LA_PLATA - FORMOSA - CORDOBA - MENDOZA", 3287 },
                    { new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), "LA_RIOJA - CORRIENTES - CABA - LA_PLATA - NEUQUEN - CORDOBA - LA_RIOJA", 3911 },
                    { new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), "CORRIENTES - LA_PLATA - NEUQUEN - MENDOZA - LA_RIOJA - CORRIENTES", 3752 },
                    { new Guid("6d96972b-60c1-4428-96f3-6647b281124e"), "FORMOSA - CORRIENTES - CABA - LA_PLATA - FORMOSA", 1970 },
                    { new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), "LA_RIOJA - CORDOBA - NEUQUEN - CABA - FORMOSA - LA_RIOJA", 4096 },
                    { new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), "NEUQUEN - MENDOZA - LA_RIOJA - FORMOSA - CORDOBA - NEUQUEN", 3761 }
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
                columns: new[] { "Id", "DestinationId", "OriginId", "SegmentIdentifierName", "Weight" },
                values: new object[,]
                {
                    { new Guid("a2df3f33-c41a-4336-9edc-fa89b561392c"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), "CABA-CORDOBA", 646 },
                    { new Guid("1ab5ae19-edac-408d-aa1a-673dca34e80e"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), "CABA-MENDOZA", 985 },
                    { new Guid("b8f21712-af7a-47b9-bd1b-d1161daaccfb"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), "CORDOBA-MENDOZA", 466 },
                    { new Guid("bf81606d-5920-4907-a76e-d1a8e7c9079e"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), "CORRIENTES-MENDOZA", 1131 },
                    { new Guid("18887803-e0e4-4832-9d12-daad31d83b92"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), "FORMOSA-MENDOZA", 1269 },
                    { new Guid("12d92793-279c-4fa4-a2a0-1f6e8732c7cf"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), "LA_PLATA-MENDOZA", 1029 },
                    { new Guid("534c290a-ab4b-440f-a290-8f43b60024ed"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), "LA_RIOJA-MENDOZA", 427 },
                    { new Guid("df3b4652-69ed-4d41-b7bc-8492da732e29"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), "MENDOZA-CABA", 985 },
                    { new Guid("15d4eebe-61fa-491e-9bac-32acc2717d78"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), "MENDOZA-CORRIENTES", 1131 },
                    { new Guid("35254348-48e6-42ce-b2cd-c0d459cc933d"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), "MENDOZA-FORMOSA", 1269 },
                    { new Guid("900bfff9-c6a0-4fd1-8828-82f69e013f58"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), "MENDOZA-LA_PLATA", 1029 },
                    { new Guid("0f7b44ec-9e99-4049-a65e-98814abcb013"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), "MENDOZA-LA_RIOJA", 427 },
                    { new Guid("45a16731-80f7-4271-9c93-31c22362e2ca"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), "CABA-NEUQUEN", 989 },
                    { new Guid("2c435ee7-cff0-452f-8c0a-a7c8bf8c4628"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), "CORDOBA-NEUQUEN", 907 },
                    { new Guid("2951ab87-8ffc-4023-9c3a-4916b9282da4"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), "CORRIENTES-NEUQUEN", 1534 },
                    { new Guid("cb367466-1836-4015-88e5-e9e709b83b5b"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), "FORMOSA-NEUQUEN", 1690 },
                    { new Guid("50e386e9-1281-4abd-a744-5558be08c73b"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), "LA_PLATA-NEUQUEN", 1005 },
                    { new Guid("df8499dd-5086-412e-bedf-0616d9f574c7"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), "LA_RIOJA-NEUQUEN", 1063 },
                    { new Guid("87f11839-a5c7-4f1f-aedb-28b380e3b1bd"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), "MENDOZA-NEUQUEN", 676 },
                    { new Guid("a435af28-aa89-4c96-805f-86578172f593"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), "NEUQUEN-CABA", 989 },
                    { new Guid("ea552dde-3120-4ce2-a68c-2aeecf79060e"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), "NEUQUEN-CORDOBA", 907 },
                    { new Guid("784a3b23-318a-45a1-8549-edbb51da4ff0"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), "NEUQUEN-CORRIENTES", 1534 },
                    { new Guid("0b323af6-c51d-48c6-8442-826119ec5e39"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), "NEUQUEN-FORMOSA", 1690 },
                    { new Guid("88b1c1a0-f3c5-476e-987f-d7692c9d8991"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), "NEUQUEN-LA_PLATA", 1005 },
                    { new Guid("dd6c1c40-8e33-43bf-919d-820b7cc17d70"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), "NEUQUEN-LA_RIOJA", 1063 },
                    { new Guid("46ad52fe-3447-4ada-a11b-b2f7e3bdb8a6"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), "NEUQUEN-MENDOZA", 676 },
                    { new Guid("887feb03-4c76-40a9-aa3b-8be17181f866"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), "LA_RIOJA-LA_PLATA", 1038 },
                    { new Guid("dc428e25-a3cc-4045-82a0-4b4ade6eff7d"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), "LA_RIOJA-FORMOSA", 927 },
                    { new Guid("74a96f8e-13c8-4ab2-a43b-19171c9fcd16"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), "MENDOZA-CORDOBA", 466 },
                    { new Guid("2e49f448-3953-4135-b465-d63aa386c0cd"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), "LA_RIOJA-CORDOBA", 340 },
                    { new Guid("08fa1839-ab05-403e-91fa-d43b1a079649"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), "CORDOBA-CABA", 646 },
                    { new Guid("eb2d94fc-3e68-499f-b0a3-098c7885f494"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), "CABA-CORRIENTES", 792 },
                    { new Guid("570afa63-7343-4994-8624-9a7f07310360"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), "CORDOBA-CORRIENTES", 677 },
                    { new Guid("bd5965e0-8258-48c9-941b-c3a516626f50"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), "LA_RIOJA-CORRIENTES", 814 },
                    { new Guid("1a2b3259-21c4-4a22-9c3b-ee15423b32b1"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), "CORRIENTES-CORDOBA", 677 },
                    { new Guid("f27d7dda-b72c-47d7-8161-71841f32a943"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), "CABA-FORMOSA", 933 },
                    { new Guid("6045f1fb-5559-45db-9d21-2757fdb4bbaa"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), "CORDOBA-FORMOSA", 824 },
                    { new Guid("1d728f25-5a5d-4c93-acab-557080194eb8"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), "CORRIENTES-FORMOSA", 157 },
                    { new Guid("8c47ebd4-fdc7-45ba-ad23-77a88111d46c"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), "FORMOSA-CABA", 933 },
                    { new Guid("c9e01e9b-9f69-4507-9faa-4cc805bff3f6"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), "FORMOSA-CORDOBA", 824 },
                    { new Guid("5041185a-64b9-4f9a-9983-f7ca6c42968e"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), "FORMOSA-CORRIENTES", 157 },
                    { new Guid("b3223a2a-dcb9-453d-b7ca-416694d2a997"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), "CABA-LA_PLATA", 53 },
                    { new Guid("7d25ec31-b96b-49a2-9964-2f483d1b945e"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), "CORDOBA-LA_PLATA", 698 },
                    { new Guid("d089e938-733a-44bc-b398-7ec313369fa1"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), "CORRIENTES-CABA", 792 },
                    { new Guid("206df8c8-7482-4363-9257-05732bacae0f"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), "FORMOSA-LA_PLATA", 968 },
                    { new Guid("68d21fef-82b1-4000-8af2-f10b1c593222"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), "CORRIENTES-LA_PLATA", 830 },
                    { new Guid("eb1b6dd8-6071-46ae-a568-bd33600cf674"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), "LA_RIOJA-CABA", 986 },
                    { new Guid("68c22067-8a9f-430d-bdba-04960ce95b7d"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), "FORMOSA-LA_RIOJA", 927 },
                    { new Guid("2ddd7bdd-13cf-4a53-a15b-be5fa219c96f"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), "CORRIENTES-LA_RIOJA", 814 },
                    { new Guid("0843dab0-91b5-4fe5-aac7-2d090cec0ffd"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), "CORDOBA-LA_RIOJA", 340 },
                    { new Guid("7ea7d835-2479-4f8f-9d88-089b09998289"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), "LA_PLATA-LA_RIOJA", 1038 },
                    { new Guid("bdace210-3d55-4b1e-8046-c0cefe46194c"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), "LA_PLATA-FORMOSA", 968 },
                    { new Guid("ecebf3e9-c095-4721-9c69-63b4fe1340f9"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), "LA_PLATA-CORRIENTES", 830 },
                    { new Guid("279234ff-3f9f-4f43-b4ff-37db92ef46a7"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), "LA_PLATA-CORDOBA", 698 },
                    { new Guid("a64a46fb-d9cf-40b4-87b9-23d795b174df"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), "LA_PLATA-CABA", 53 },
                    { new Guid("913d1d9c-af98-4f71-8875-62b2074e639a"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), "CABA-LA_RIOJA", 986 }
                });

            migrationBuilder.InsertData(
                table: "RouteNode",
                columns: new[] { "RouteId", "NodeId", "Order" },
                values: new object[,]
                {
                    { new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), 1 },
                    { new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), 1 },
                    { new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), 2 },
                    { new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), 3 },
                    { new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), 4 },
                    { new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), 5 },
                    { new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), 6 },
                    { new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), 7 },
                    { new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), 2 },
                    { new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), 3 },
                    { new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), 4 },
                    { new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), 5 },
                    { new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), 1 },
                    { new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), 2 },
                    { new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), 4 },
                    { new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), 5 },
                    { new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), 6 },
                    { new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), 6 },
                    { new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), 3 },
                    { new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), 5 },
                    { new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), 5 },
                    { new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), 3 },
                    { new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), 4 },
                    { new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), 1 },
                    { new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), 3 },
                    { new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), 4 },
                    { new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), 5 },
                    { new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), new Guid("244cb214-f2f7-4349-b6f5-bb4aca5952fe"), 6 },
                    { new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), 1 },
                    { new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), 2 },
                    { new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), 3 },
                    { new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), new Guid("424dbbe3-14c3-409c-9db2-0c2790a325e3"), 2 },
                    { new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), 6 },
                    { new Guid("6d96972b-60c1-4428-96f3-6647b281124e"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), 1 },
                    { new Guid("6d96972b-60c1-4428-96f3-6647b281124e"), new Guid("f9d1db7a-da61-45f5-bd9c-13e74c7d85f3"), 2 },
                    { new Guid("6d96972b-60c1-4428-96f3-6647b281124e"), new Guid("bab6add0-7481-4e1c-8014-b961f6e13a31"), 3 },
                    { new Guid("6d96972b-60c1-4428-96f3-6647b281124e"), new Guid("41c38ccb-bd46-4db1-97c8-387b67565d87"), 4 },
                    { new Guid("6d96972b-60c1-4428-96f3-6647b281124e"), new Guid("60379ffe-224c-4c26-9889-b3f79fc6c796"), 5 },
                    { new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), new Guid("bffec97d-db7f-44eb-a511-1d8c7df44926"), 1 },
                    { new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), 4 },
                    { new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), new Guid("929c149e-bd42-4910-bcff-28cab658b4b6"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "CurrentSegmentId", "DateCompleted", "DateScheduled", "RouteId", "Status", "TransportationVehicleLicensePlate" },
                values: new object[,]
                {
                    { new Guid("95d7bde5-be93-4e45-b695-3c828aa9f303"), null, new DateTime(2020, 2, 6, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3240), new DateTime(2020, 2, 3, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3240), new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), 1, "SCANIA_4" },
                    { new Guid("925c7e0f-e29d-48c3-818f-a607edd83e99"), null, new DateTime(2020, 4, 6, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3100), new DateTime(2020, 4, 3, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3100), new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), 1, "SCANIA_3" },
                    { new Guid("4100d109-bfda-41f6-9459-45e9314de5c2"), null, new DateTime(2020, 4, 2, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3110), new DateTime(2020, 3, 30, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3110), new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), 1, "SCANIA_3" },
                    { new Guid("341fe6db-80ba-4494-b823-3c6ab0834569"), null, new DateTime(2020, 3, 29, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3120), new DateTime(2020, 3, 26, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3120), new Guid("6d96972b-60c1-4428-96f3-6647b281124e"), 1, "SCANIA_3" },
                    { new Guid("bc36d626-c0c1-44da-af03-9acc6ac04b16"), null, new DateTime(2020, 3, 25, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3130), new DateTime(2020, 3, 22, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3130), new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), 1, "SCANIA_3" },
                    { new Guid("6071c01c-1d4b-400d-8d84-d6421094a0d9"), null, new DateTime(2020, 3, 21, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3140), new DateTime(2020, 3, 18, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3140), new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), 1, "SCANIA_3" },
                    { new Guid("d9706d8a-2804-4833-9a81-41738595499a"), null, new DateTime(2020, 3, 13, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3160), new DateTime(2020, 3, 10, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3160), new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), 1, "SCANIA_3" },
                    { new Guid("54b5567d-88be-4d5d-951c-d4af1d2b2aa7"), null, new DateTime(2020, 2, 22, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3210), new DateTime(2020, 2, 19, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3210), new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), 1, "SCANIA_4" },
                    { new Guid("b094fec4-4ce1-4abd-b42f-2025cbd4e47a"), null, new DateTime(2020, 3, 5, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3170), new DateTime(2020, 3, 2, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3170), new Guid("6d96972b-60c1-4428-96f3-6647b281124e"), 1, "SCANIA_4" },
                    { new Guid("2bd55405-9455-4d3b-be50-edcaf28211e5"), null, new DateTime(2020, 3, 1, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3180), new DateTime(2020, 2, 27, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3180), new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), 1, "SCANIA_4" },
                    { new Guid("5b0e3c10-e300-48cc-b264-850484b5524c"), null, new DateTime(2020, 2, 26, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3190), new DateTime(2020, 2, 23, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3190), new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), 1, "SCANIA_4" },
                    { new Guid("854a08e6-a396-4329-bd67-bf99f0232083"), null, new DateTime(2020, 2, 18, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3220), new DateTime(2020, 2, 15, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3220), new Guid("6d96972b-60c1-4428-96f3-6647b281124e"), 1, "SCANIA_4" },
                    { new Guid("b976bc40-6df7-4a14-b986-39532d622ce8"), null, new DateTime(2020, 2, 14, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3220), new DateTime(2020, 2, 11, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3220), new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), 1, "SCANIA_4" },
                    { new Guid("485e91c5-e297-4d83-b521-c0224cb46273"), null, new DateTime(2020, 2, 10, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3230), new DateTime(2020, 2, 7, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3230), new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), 1, "SCANIA_4" },
                    { new Guid("774e048a-8fab-4776-a200-9f590c38851b"), null, new DateTime(2020, 4, 10, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3090), new DateTime(2020, 4, 7, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3090), new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), 1, "SCANIA_3" },
                    { new Guid("12113eda-b968-4e1f-91b1-112b43c3bf68"), null, new DateTime(2020, 3, 9, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3160), new DateTime(2020, 3, 6, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3160), new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), 1, "SCANIA_3" },
                    { new Guid("1f832d47-6697-4d36-b043-1e7351cfb098"), null, null, new DateTime(2020, 7, 5, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3080), new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), 0, "SCANIA_3" },
                    { new Guid("fab7d620-b095-40e0-a740-7c4c95204567"), null, new DateTime(2020, 6, 1, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(340), new DateTime(2020, 5, 29, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(340), new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), 1, "SCANIA_1" },
                    { new Guid("45bb0310-f4ad-4906-95ec-aa77856472c2"), null, new DateTime(2020, 4, 26, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3000), new DateTime(2020, 4, 23, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3000), new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), 1, "SCANIA_2" },
                    { new Guid("0ba0e67d-5d65-4610-b69c-f415ba3071f2"), null, new DateTime(2020, 2, 2, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3250), new DateTime(2020, 1, 30, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3250), new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), 1, "SCANIA_4" },
                    { new Guid("d943f20b-d570-43be-9011-b1487f7a048e"), null, null, new DateTime(2020, 7, 17, 15, 48, 1, 321, DateTimeKind.Local).AddTicks(4630), new Guid("6d96972b-60c1-4428-96f3-6647b281124e"), 0, "SCANIA_1" },
                    { new Guid("b88c413f-bb08-42f4-ac18-66ca9c32d872"), null, new DateTime(2020, 6, 29, 15, 48, 1, 382, DateTimeKind.Local).AddTicks(2430), new DateTime(2020, 6, 26, 15, 48, 1, 382, DateTimeKind.Local).AddTicks(2430), new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), 1, "SCANIA_1" },
                    { new Guid("db6b85ea-a976-4b70-93d1-112cee2e27a1"), null, new DateTime(2020, 6, 25, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(180), new DateTime(2020, 6, 22, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(180), new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), 1, "SCANIA_1" },
                    { new Guid("1eb8966d-ec38-4a14-9ff8-0b01c493316a"), null, new DateTime(2020, 6, 21, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(260), new DateTime(2020, 6, 18, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(260), new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), 1, "SCANIA_1" },
                    { new Guid("55f80a09-3bad-4c2e-ae05-88b1c3858fd5"), null, new DateTime(2020, 6, 17, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(280), new DateTime(2020, 6, 14, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(280), new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), 1, "SCANIA_1" },
                    { new Guid("c3254969-5d1b-4254-9668-03393cdd7217"), null, new DateTime(2020, 6, 13, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(310), new DateTime(2020, 6, 10, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(310), new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), 1, "SCANIA_1" },
                    { new Guid("e157b320-d4f4-4121-9a92-41ff0a8cf612"), null, new DateTime(2020, 4, 18, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3070), new DateTime(2020, 4, 15, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3070), new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), 1, "SCANIA_2" },
                    { new Guid("4047753c-d566-4252-b904-deaa81cd4d57"), null, new DateTime(2020, 6, 9, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(320), new DateTime(2020, 6, 6, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(320), new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), 1, "SCANIA_1" },
                    { new Guid("4fe4a738-a3bf-4718-8117-69fdd5f13d70"), null, null, new DateTime(2020, 7, 9, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2770), new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), 0, "SCANIA_2" },
                    { new Guid("d5731384-72dd-4b50-a87d-dc6418215a4e"), null, new DateTime(2020, 5, 20, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2800), new DateTime(2020, 5, 17, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2800), new Guid("d293135a-4900-4ae4-a93a-b4a60940c64d"), 1, "SCANIA_2" },
                    { new Guid("dfc47553-b8cf-47ea-892f-a264d0362e30"), null, new DateTime(2020, 5, 16, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2810), new DateTime(2020, 5, 13, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2810), new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), 1, "SCANIA_2" },
                    { new Guid("20decf70-78bd-4ff6-a4aa-ad4178274dd0"), null, new DateTime(2020, 5, 12, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2820), new DateTime(2020, 5, 9, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2820), new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), 1, "SCANIA_2" },
                    { new Guid("b1cf150b-f07b-459b-8326-414f516b86e6"), null, new DateTime(2020, 5, 8, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2840), new DateTime(2020, 5, 5, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2840), new Guid("90e47a89-b112-4dd8-b936-e157e05f8e4e"), 1, "SCANIA_2" },
                    { new Guid("a5ccfdfe-31f5-417e-9a01-03413250d581"), null, new DateTime(2020, 5, 4, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2840), new DateTime(2020, 5, 1, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2840), new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), 1, "SCANIA_2" },
                    { new Guid("f9c3b9d4-fd30-4181-9c8a-8195d7022b13"), null, new DateTime(2020, 4, 30, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2850), new DateTime(2020, 4, 27, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(2850), new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), 1, "SCANIA_2" },
                    { new Guid("361077fc-eee3-4d0a-a4e5-163076462788"), null, new DateTime(2020, 6, 5, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(330), new DateTime(2020, 6, 2, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(330), new Guid("80c1e20f-0ec2-4f98-8c40-c881b614824e"), 1, "SCANIA_1" },
                    { new Guid("53ab01e1-60f4-4648-abd4-d2e56c0c634d"), null, new DateTime(2020, 1, 29, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3260), new DateTime(2020, 1, 26, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3260), new Guid("19af0191-53eb-4250-a4db-a6ef8679840b"), 1, "SCANIA_4" }
                });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "CurrentSegmentId", "DateCompleted", "DateScheduled", "RouteId", "Status", "TransportationVehicleLicensePlate" },
                values: new object[] { new Guid("29f207f4-afba-4596-922f-fc3fe9d47e11"), new Guid("a64a46fb-d9cf-40b4-87b9-23d795b174df"), null, new DateTime(2020, 7, 1, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3150), new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), 2, "SCANIA_3" });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "CurrentSegmentId", "DateCompleted", "DateScheduled", "RouteId", "Status", "TransportationVehicleLicensePlate" },
                values: new object[] { new Guid("36c5ccad-3507-40e4-b59b-d1e0ea9eee32"), new Guid("bdace210-3d55-4b1e-8046-c0cefe46194c"), null, new DateTime(2020, 7, 3, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(3010), new Guid("36fb10cb-a571-4104-a40b-07c2f1e39868"), 2, "SCANIA_2" });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "CurrentSegmentId", "DateCompleted", "DateScheduled", "RouteId", "Status", "TransportationVehicleLicensePlate" },
                values: new object[] { new Guid("3108808e-a9e1-4fba-97b5-7386973d5e8f"), new Guid("74a96f8e-13c8-4ab2-a43b-19171c9fcd16"), null, new DateTime(2020, 7, 3, 15, 48, 1, 384, DateTimeKind.Local).AddTicks(360), new Guid("195dfd27-b531-4b58-a20c-faaab3fa8c80"), 2, "SCANIA_1" });

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
