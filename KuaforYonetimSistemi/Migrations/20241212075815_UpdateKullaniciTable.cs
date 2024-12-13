using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforYonetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKullaniciTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tarih",
                value: new DateTime(2024, 12, 13, 7, 58, 14, 579, DateTimeKind.Utc).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tarih",
                value: new DateTime(2024, 12, 14, 7, 58, 14, 579, DateTimeKind.Utc).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tarih",
                value: new DateTime(2024, 12, 15, 7, 58, 14, 579, DateTimeKind.Utc).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Tarih",
                value: new DateTime(2024, 12, 16, 7, 58, 14, 579, DateTimeKind.Utc).AddTicks(8393));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tarih",
                value: new DateTime(2024, 12, 11, 11, 17, 46, 452, DateTimeKind.Utc).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tarih",
                value: new DateTime(2024, 12, 12, 11, 17, 46, 452, DateTimeKind.Utc).AddTicks(8839));

            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tarih",
                value: new DateTime(2024, 12, 13, 11, 17, 46, 452, DateTimeKind.Utc).AddTicks(8843));

            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 4,
                column: "Tarih",
                value: new DateTime(2024, 12, 14, 11, 17, 46, 452, DateTimeKind.Utc).AddTicks(8845));
        }
    }
}
