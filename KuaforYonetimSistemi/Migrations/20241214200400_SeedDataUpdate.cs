using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KuaforYonetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.InsertData(
                table: "Randevu",
                columns: new[] { "Id", "CalisanId", "Durum", "IslemId", "IslemSuresi", "Kazanc", "KullaniciId", "Tarih" },
                values: new object[,]
                {
                    { 6, 1, "Onaylandı", 1, 40, 250m, 2, new DateTime(2024, 12, 14, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 2, "Beklemede", 2, 175, 1500m, 3, new DateTime(2024, 12, 14, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 3, "Onaylandı", 3, 20, 200m, 4, new DateTime(2024, 12, 14, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 4, "Beklemede", 4, 200, 820m, 5, new DateTime(2024, 12, 15, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 5, "Reddedildi", 5, 180, 1000m, 2, new DateTime(2024, 12, 15, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 1, "Onaylandı", 6, 40, 150m, 3, new DateTime(2024, 12, 15, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 2, "Beklemede", 7, 40, 150m, 4, new DateTime(2024, 12, 16, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 3, "Onaylandı", 8, 20, 50m, 5, new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 4, "Reddedildi", 9, 40, 250m, 2, new DateTime(2024, 12, 16, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 5, "Onaylandı", 1, 40, 250m, 3, new DateTime(2024, 12, 17, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, 1, "Beklemede", 2, 175, 1500m, 4, new DateTime(2024, 12, 17, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, 2, "Onaylandı", 3, 20, 200m, 5, new DateTime(2024, 12, 17, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, 3, "Beklemede", 4, 200, 820m, 2, new DateTime(2024, 12, 18, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, 4, "Reddedildi", 5, 180, 1000m, 3, new DateTime(2024, 12, 18, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, 5, "Onaylandı", 6, 40, 150m, 4, new DateTime(2024, 12, 18, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 21, 1, "Beklemede", 7, 40, 150m, 5, new DateTime(2024, 12, 19, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 22, 2, "Onaylandı", 8, 20, 50m, 2, new DateTime(2024, 12, 19, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 23, 3, "Reddedildi", 9, 40, 250m, 3, new DateTime(2024, 12, 19, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 24, 4, "Onaylandı", 1, 40, 250m, 4, new DateTime(2024, 12, 20, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, 5, "Beklemede", 2, 175, 1500m, 5, new DateTime(2024, 12, 20, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 26, 1, "Onaylandı", 3, 20, 200m, 2, new DateTime(2024, 12, 20, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 27, 2, "Beklemede", 4, 200, 820m, 3, new DateTime(2024, 12, 21, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 28, 3, "Reddedildi", 5, 180, 1000m, 4, new DateTime(2024, 12, 21, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 29, 4, "Onaylandı", 6, 40, 150m, 5, new DateTime(2024, 12, 21, 15, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.InsertData(
                table: "Randevu",
                columns: new[] { "Id", "CalisanId", "Durum", "IslemId", "IslemSuresi", "Kazanc", "KullaniciId", "Tarih" },
                values: new object[,]
                {
                    { 100, 1, "Onaylandı", 1, 40, 250m, 2, new DateTime(2024, 12, 14, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 101, 2, "Beklemede", 2, 175, 1500m, 3, new DateTime(2024, 12, 14, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 102, 3, "Onaylandı", 3, 20, 200m, 4, new DateTime(2024, 12, 14, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 103, 4, "Beklemede", 4, 200, 820m, 5, new DateTime(2024, 12, 15, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 104, 5, "Reddedildi", 5, 180, 1000m, 2, new DateTime(2024, 12, 15, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 105, 1, "Onaylandı", 6, 40, 150m, 3, new DateTime(2024, 12, 15, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 106, 2, "Beklemede", 7, 40, 150m, 4, new DateTime(2024, 12, 16, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 107, 3, "Onaylandı", 8, 20, 50m, 5, new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 108, 4, "Reddedildi", 9, 40, 250m, 2, new DateTime(2024, 12, 16, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 109, 5, "Onaylandı", 1, 40, 250m, 3, new DateTime(2024, 12, 17, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 110, 1, "Beklemede", 2, 175, 1500m, 4, new DateTime(2024, 12, 17, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 111, 2, "Onaylandı", 3, 20, 200m, 5, new DateTime(2024, 12, 17, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { 112, 3, "Beklemede", 4, 200, 820m, 2, new DateTime(2024, 12, 18, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 113, 4, "Reddedildi", 5, 180, 1000m, 3, new DateTime(2024, 12, 18, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 114, 5, "Onaylandı", 6, 40, 150m, 4, new DateTime(2024, 12, 18, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 115, 1, "Beklemede", 7, 40, 150m, 5, new DateTime(2024, 12, 19, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 116, 2, "Onaylandı", 8, 20, 50m, 2, new DateTime(2024, 12, 19, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 117, 3, "Reddedildi", 9, 40, 250m, 3, new DateTime(2024, 12, 19, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 118, 4, "Onaylandı", 1, 40, 250m, 4, new DateTime(2024, 12, 20, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 119, 5, "Beklemede", 2, 175, 1500m, 5, new DateTime(2024, 12, 20, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 120, 1, "Onaylandı", 3, 20, 200m, 2, new DateTime(2024, 12, 20, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 121, 2, "Beklemede", 4, 200, 820m, 3, new DateTime(2024, 12, 21, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 122, 3, "Reddedildi", 5, 180, 1000m, 4, new DateTime(2024, 12, 21, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 123, 4, "Onaylandı", 6, 40, 150m, 5, new DateTime(2024, 12, 21, 15, 0, 0, 0, DateTimeKind.Utc) }
                });
        }
    }
}
