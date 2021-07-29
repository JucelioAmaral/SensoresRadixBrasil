using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sensores.Radix.Infra.Data.Migrations
{
    public partial class MigracaoInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblSensorEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<long>(nullable: false),
                    Valor = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    SensorName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Region = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSensorEvents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblSensorEvents");
        }
    }
}
