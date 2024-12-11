using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KuaforYonetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class ilk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calisan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UygunSaatler = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Islem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ucret = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Sure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalisanIslem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanId = table.Column<int>(type: "int", nullable: false),
                    IslemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisanIslem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalisanIslem_Calisan_CalisanId",
                        column: x => x.CalisanId,
                        principalTable: "Calisan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalisanIslem_Islem_IslemId",
                        column: x => x.IslemId,
                        principalTable: "Islem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalisanId = table.Column<int>(type: "int", nullable: false),
                    IslemId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    Kazanc = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IslemSuresi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Randevu_Calisan_CalisanId",
                        column: x => x.CalisanId,
                        principalTable: "Calisan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevu_Islem_IslemId",
                        column: x => x.IslemId,
                        principalTable: "Islem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevu_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Calisan",
                columns: new[] { "Id", "AdSoyad", "UygunSaatler" },
                values: new object[,]
                {
                    { 1, "Ayşe Yılmaz", "09:00-18:00" },
                    { 2, "Fatma Kaya", "10:00-17:00" },
                    { 3, "Elif Demir", "08:00-16:00" },
                    { 4, "Zehra Çelik", "12:00-20:00" },
                    { 5, "Gizem Arslan", "11:00-19:00" }
                });

            migrationBuilder.InsertData(
                table: "Islem",
                columns: new[] { "Id", "Ad", "Sure", "Ucret" },
                values: new object[,]
                {
                    { 1, "Saç Kesimi", 0, 50m },
                    { 2, "Saç Boyama", 0, 150m },
                    { 3, "Fön Çekme", 0, 30m },
                    { 4, "Saç Bakımı", 0, 120m },
                    { 5, "Perma", 0, 200m },
                    { 6, "Manikür", 0, 80m },
                    { 7, "Pedikür", 0, 90m },
                    { 8, "Kaş Alma", 0, 40m },
                    { 9, "Makyaj", 0, 250m }
                });

            migrationBuilder.InsertData(
                table: "Kullanici",
                columns: new[] { "Id", "Email", "KullaniciAdi", "Rol", "Sifre" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "admin", "Admin", "12345" },
                    { 2, "fatma@example.com", "fatma", "Kullanici", "12345" },
                    { 3, "ahmet@example.com", "ahmet", "Kullanici", "12345" },
                    { 4, "elif@example.com", "elif", "Kullanici", "12345" },
                    { 5, "gizem@example.com", "gizem", "Kullanici", "12345" }
                });

            migrationBuilder.InsertData(
                table: "CalisanIslem",
                columns: new[] { "Id", "CalisanId", "IslemId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 3 },
                    { 3, 1, 6 },
                    { 4, 2, 2 },
                    { 5, 2, 4 },
                    { 6, 2, 7 },
                    { 7, 3, 1 },
                    { 8, 3, 5 },
                    { 9, 3, 8 },
                    { 10, 4, 3 },
                    { 11, 4, 9 },
                    { 12, 5, 2 },
                    { 13, 5, 4 },
                    { 14, 5, 8 }
                });

            migrationBuilder.InsertData(
                table: "Randevu",
                columns: new[] { "Id", "CalisanId", "IslemId", "IslemSuresi", "Kazanc", "KullaniciId", "Tarih" },
                values: new object[,]
                {
                    { 1, 1, 1, 30, 50m, 2, new DateTime(2024, 12, 11, 11, 17, 46, 452, DateTimeKind.Utc).AddTicks(8367) },
                    { 2, 2, 4, 60, 120m, 3, new DateTime(2024, 12, 12, 11, 17, 46, 452, DateTimeKind.Utc).AddTicks(8839) },
                    { 3, 3, 5, 90, 200m, 4, new DateTime(2024, 12, 13, 11, 17, 46, 452, DateTimeKind.Utc).AddTicks(8843) },
                    { 4, 4, 9, 120, 250m, 5, new DateTime(2024, 12, 14, 11, 17, 46, 452, DateTimeKind.Utc).AddTicks(8845) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalisanIslem_CalisanId",
                table: "CalisanIslem",
                column: "CalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_CalisanIslem_IslemId",
                table: "CalisanIslem",
                column: "IslemId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_CalisanId",
                table: "Randevu",
                column: "CalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_IslemId",
                table: "Randevu",
                column: "IslemId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_KullaniciId",
                table: "Randevu",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalisanIslem");

            migrationBuilder.DropTable(
                name: "Randevu");

            migrationBuilder.DropTable(
                name: "Calisan");

            migrationBuilder.DropTable(
                name: "Islem");

            migrationBuilder.DropTable(
                name: "Kullanici");
        }
    }
}
