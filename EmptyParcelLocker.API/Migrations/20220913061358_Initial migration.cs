using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmptyParcelLocker.API.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lockers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEmpty = table.Column<bool>(type: "bit", nullable: false),
                    LockerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParcelLockerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lockers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LockerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHeight = table.Column<int>(type: "int", nullable: false),
                    MaxWidth = table.Column<int>(type: "int", nullable: false),
                    MaxLength = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParcelLockers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelLockers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ApartmentNumber", "BuildingNumber", "CityName", "Street", "ZipCode" },
                values: new object[] { new Guid("dd39b1e1-e3f8-436e-9956-1d1ee8de3aa3"), "", "61", "Cieszyn", "Frysztacka", "43-400" });

            migrationBuilder.InsertData(
                table: "LockerTypes",
                columns: new[] { "Id", "MaxHeight", "MaxLength", "MaxWeight", "MaxWidth", "Name" },
                values: new object[,]
                {
                    { new Guid("09b9faae-6598-4e47-bce6-37cdfb46b7bf"), 190, 640, 25, 380, "medium" },
                    { new Guid("c5622830-eb07-455b-8c42-8dcbd6c8c926"), 80, 640, 25, 380, "small" },
                    { new Guid("f4dd7a2e-90e9-4cab-b7dc-38a6ad528403"), 410, 640, 25, 380, "large" }
                });

            migrationBuilder.InsertData(
                table: "Lockers",
                columns: new[] { "Id", "IsEmpty", "LockerTypeId", "ParcelLockerId" },
                values: new object[,]
                {
                    { new Guid("3058f64e-ba63-460d-9013-70244f25b036"), true, new Guid("c5622830-eb07-455b-8c42-8dcbd6c8c926"), new Guid("22e88beb-98bb-4922-adba-538e86f5834b") },
                    { new Guid("3f68494a-434a-4d7a-b047-bceec0eff40a"), true, new Guid("c5622830-eb07-455b-8c42-8dcbd6c8c926"), new Guid("22e88beb-98bb-4922-adba-538e86f5834b") },
                    { new Guid("50e9dae7-8a83-4a29-b89b-6083804893bf"), false, new Guid("c5622830-eb07-455b-8c42-8dcbd6c8c926"), new Guid("22e88beb-98bb-4922-adba-538e86f5834b") }
                });

            migrationBuilder.InsertData(
                table: "ParcelLockers",
                columns: new[] { "Id", "AddressId", "Latitude", "Longitude", "Name" },
                values: new object[] { new Guid("22e88beb-98bb-4922-adba-538e86f5834b"), new Guid("dd39b1e1-e3f8-436e-9956-1d1ee8de3aa3"), 49.757507942840931, 18.622906166106151, "CSZ08M" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Lockers");

            migrationBuilder.DropTable(
                name: "LockerTypes");

            migrationBuilder.DropTable(
                name: "ParcelLockers");
        }
    }
}
