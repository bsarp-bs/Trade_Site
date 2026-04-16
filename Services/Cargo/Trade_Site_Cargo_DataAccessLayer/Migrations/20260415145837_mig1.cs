using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trade_Site_Cargo_DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargoCabs",
                columns: table => new
                {
                    CargoCabID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCabName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoCabs", x => x.CargoCabID);
                });

            migrationBuilder.CreateTable(
                name: "CargoOwners",
                columns: table => new
                {
                    CargoOwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerDistrinct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoOwnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoOwners", x => x.CargoOwnerID);
                });

            migrationBuilder.CreateTable(
                name: "CargoStatuses",
                columns: table => new
                {
                    CargoStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoStatuses", x => x.CargoStatusID);
                });

            migrationBuilder.CreateTable(
                name: "CargoDetails",
                columns: table => new
                {
                    CargoDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecevicerCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoDetailBarcode = table.Column<int>(type: "int", nullable: false),
                    CargoCabID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoDetails", x => x.CargoDetailID);
                    table.ForeignKey(
                        name: "FK_CargoDetails_CargoCabs_CargoCabID",
                        column: x => x.CargoCabID,
                        principalTable: "CargoCabs",
                        principalColumn: "CargoCabID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_CargoCabID",
                table: "CargoDetails",
                column: "CargoCabID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoDetails");

            migrationBuilder.DropTable(
                name: "CargoOwners");

            migrationBuilder.DropTable(
                name: "CargoStatuses");

            migrationBuilder.DropTable(
                name: "CargoCabs");
        }
    }
}
