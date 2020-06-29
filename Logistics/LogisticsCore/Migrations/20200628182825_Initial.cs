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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Node", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Path",
                columns: table => new
                {
                    OriginId = table.Column<Guid>(nullable: false),
                    DestinationId = table.Column<Guid>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
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

            migrationBuilder.InsertData(
                table: "Node",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), "CABA" },
                    { new Guid("2272753e-7939-4c53-92b8-40182d578338"), "Córdoba" },
                    { new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), "Corrientes" },
                    { new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), "Formosa" },
                    { new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), "La Plata" },
                    { new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), "La Rioja" },
                    { new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), "Mendoza" },
                    { new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), "Neuquén" }
                });

            migrationBuilder.InsertData(
                table: "Path",
                columns: new[] { "OriginId", "DestinationId", "Weight" },
                values: new object[,]
                {
                    { new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), new Guid("2272753e-7939-4c53-92b8-40182d578338"), 646 },
                    { new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), 985 },
                    { new Guid("2272753e-7939-4c53-92b8-40182d578338"), new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), 466 },
                    { new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), 1131 },
                    { new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), 1269 },
                    { new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), 1029 },
                    { new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), 427 },
                    { new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), 985 },
                    { new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), new Guid("2272753e-7939-4c53-92b8-40182d578338"), 466 },
                    { new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), 1131 },
                    { new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), 1269 },
                    { new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), 1029 },
                    { new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), 1038 },
                    { new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), 427 },
                    { new Guid("2272753e-7939-4c53-92b8-40182d578338"), new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), 907 },
                    { new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), 1534 },
                    { new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), 1690 },
                    { new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), 1005 },
                    { new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), 1063 },
                    { new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), 676 },
                    { new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), 989 },
                    { new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), new Guid("2272753e-7939-4c53-92b8-40182d578338"), 907 },
                    { new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), 1534 },
                    { new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), 1690 },
                    { new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), 1005 },
                    { new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), 989 },
                    { new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), 927 },
                    { new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), 814 },
                    { new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), new Guid("2272753e-7939-4c53-92b8-40182d578338"), 340 },
                    { new Guid("2272753e-7939-4c53-92b8-40182d578338"), new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), 646 },
                    { new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), 792 },
                    { new Guid("2272753e-7939-4c53-92b8-40182d578338"), new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), 677 },
                    { new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), 792 },
                    { new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), new Guid("2272753e-7939-4c53-92b8-40182d578338"), 677 },
                    { new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), 933 },
                    { new Guid("2272753e-7939-4c53-92b8-40182d578338"), new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), 824 },
                    { new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), 157 },
                    { new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), 933 },
                    { new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), new Guid("2272753e-7939-4c53-92b8-40182d578338"), 824 },
                    { new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), 157 },
                    { new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), 53 },
                    { new Guid("2272753e-7939-4c53-92b8-40182d578338"), new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), 698 },
                    { new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), 830 },
                    { new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), 968 },
                    { new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), 53 },
                    { new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), new Guid("2272753e-7939-4c53-92b8-40182d578338"), 698 },
                    { new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), 830 },
                    { new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), 968 },
                    { new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), 986 },
                    { new Guid("2272753e-7939-4c53-92b8-40182d578338"), new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), 340 },
                    { new Guid("e5af2896-4670-4d7d-aa06-d78ca1fbbf54"), new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), 814 },
                    { new Guid("10de5c0a-0fb9-462d-83ba-6b5ac7c48095"), new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), 927 },
                    { new Guid("ca6bd0cf-a01d-4d3a-aeb9-1dac90901bc7"), new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), 1038 },
                    { new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), new Guid("98f457c9-aa02-4d6b-8013-ecb3f4fb1785"), 986 },
                    { new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), new Guid("7eb35662-4380-4a6a-a978-446b342cd39f"), 1063 },
                    { new Guid("9adc8373-3399-406d-ac49-e894229e6d05"), new Guid("f0b8952a-9613-4ae8-936d-c4a6742a47a6"), 676 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Path_DestinationId",
                table: "Path",
                column: "DestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Path");

            migrationBuilder.DropTable(
                name: "Node");
        }
    }
}
