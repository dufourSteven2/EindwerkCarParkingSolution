using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EindwerkCarParkingCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eigenaars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EigenaarNaam = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eigenaars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gemeentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GemeenteNaam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemeentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LandNaam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Totaals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BezetteParkings = table.Column<int>(nullable: false),
                    MaxParkings = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Totaals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locaties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GemeenteId = table.Column<int>(nullable: false),
                    LandId = table.Column<int>(nullable: false),
                    Nr = table.Column<string>(nullable: true),
                    Straat = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locaties_Gemeentes_GemeenteId",
                        column: x => x.GemeenteId,
                        principalTable: "Gemeentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locaties_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soorts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SoortNaam = table.Column<string>(nullable: false),
                    TotaalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soorts_Totaals_TotaalId",
                        column: x => x.TotaalId,
                        principalTable: "Totaals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bezet = table.Column<int>(nullable: false),
                    EigenaarId = table.Column<int>(nullable: false),
                    LocatieId = table.Column<int>(nullable: false),
                    ParkingNaam = table.Column<string>(nullable: false),
                    SoortId = table.Column<int>(nullable: false),
                    Totaal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parkings_Eigenaars_EigenaarId",
                        column: x => x.EigenaarId,
                        principalTable: "Eigenaars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parkings_Locaties_LocatieId",
                        column: x => x.LocatieId,
                        principalTable: "Locaties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parkings_Soorts_SoortId",
                        column: x => x.SoortId,
                        principalTable: "Soorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locaties_GemeenteId",
                table: "Locaties",
                column: "GemeenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Locaties_LandId",
                table: "Locaties",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_EigenaarId",
                table: "Parkings",
                column: "EigenaarId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_LocatieId",
                table: "Parkings",
                column: "LocatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_SoortId",
                table: "Parkings",
                column: "SoortId");

            migrationBuilder.CreateIndex(
                name: "IX_Soorts_TotaalId",
                table: "Soorts",
                column: "TotaalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parkings");

            migrationBuilder.DropTable(
                name: "Eigenaars");

            migrationBuilder.DropTable(
                name: "Locaties");

            migrationBuilder.DropTable(
                name: "Soorts");

            migrationBuilder.DropTable(
                name: "Gemeentes");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "Totaals");
        }
    }
}
