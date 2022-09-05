﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmptyParcelLocker.API.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelLockers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lockers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEmpty = table.Column<bool>(type: "bit", nullable: false),
                    ParcelLocerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LockerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParcelLockerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lockers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lockers_LockerTypes_LockerTypeId",
                        column: x => x.LockerTypeId,
                        principalTable: "LockerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lockers_ParcelLockers_ParcelLockerId",
                        column: x => x.ParcelLockerId,
                        principalTable: "ParcelLockers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lockers_LockerTypeId",
                table: "Lockers",
                column: "LockerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lockers_ParcelLockerId",
                table: "Lockers",
                column: "ParcelLockerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lockers");

            migrationBuilder.DropTable(
                name: "LockerTypes");

            migrationBuilder.DropTable(
                name: "ParcelLockers");
        }
    }
}
