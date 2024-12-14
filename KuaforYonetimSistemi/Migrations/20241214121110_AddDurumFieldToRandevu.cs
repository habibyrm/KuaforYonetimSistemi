using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforYonetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class AddDurumFieldToRandevu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Durum",
                table: "Randevu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Beklemede");

            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Durum", "Tarih" },
                values: new object[] { "Onaylandı", new DateTime(2024, 12, 15, 12, 11, 9, 183, DateTimeKind.Utc).AddTicks(5995) });

            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Durum", "Tarih" },
                values: new object[] { "Beklemede", new DateTime(2024, 12, 16, 12, 11, 9, 183, DateTimeKind.Utc).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Durum", "Tarih" },
                values: new object[] { "Reddedildi", new DateTime(2024, 12, 17, 12, 11, 9, 183, DateTimeKind.Utc).AddTicks(7441) });

            migrationBuilder.UpdateData(
                table: "Randevu",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Durum", "Tarih" },
                values: new object[] { "Beklemede", new DateTime(2024, 12, 18, 12, 11, 9, 183, DateTimeKind.Utc).AddTicks(7444) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Randevu");

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
    }
}
