using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    public partial class hamma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistes",
                columns: table => new
                {
                    ArtisteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nationalite = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistes", x => x.ArtisteId);
                });

            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    FestivalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.FestivalId);
                });

            migrationBuilder.CreateTable(
                name: "Chansons",
                columns: table => new
                {
                    ChansonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleMusical = table.Column<int>(type: "int", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VuesYoutube = table.Column<int>(type: "int", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    ArtisteFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chansons", x => x.ChansonId);
                    table.ForeignKey(
                        name: "FK_Chansons_Artistes_ArtisteFk",
                        column: x => x.ArtisteFk,
                        principalTable: "Artistes",
                        principalColumn: "ArtisteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    DateConcert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtisteFk = table.Column<int>(type: "int", nullable: false),
                    FestivalFk = table.Column<int>(type: "int", nullable: false),
                    Cachet = table.Column<double>(type: "float", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => new { x.DateConcert, x.ArtisteFk, x.FestivalFk });
                    table.ForeignKey(
                        name: "FK_Concerts_Artistes_ArtisteFk",
                        column: x => x.ArtisteFk,
                        principalTable: "Artistes",
                        principalColumn: "ArtisteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Concerts_Festivals_FestivalFk",
                        column: x => x.FestivalFk,
                        principalTable: "Festivals",
                        principalColumn: "FestivalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chansons_ArtisteFk",
                table: "Chansons",
                column: "ArtisteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_ArtisteFk",
                table: "Concerts",
                column: "ArtisteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_FestivalFk",
                table: "Concerts",
                column: "FestivalFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chansons");

            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropTable(
                name: "Artistes");

            migrationBuilder.DropTable(
                name: "Festivals");
        }
    }
}
