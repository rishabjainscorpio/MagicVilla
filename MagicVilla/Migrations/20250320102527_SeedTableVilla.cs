using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla.Migrations
{
    /// <inheritdoc />
    public partial class SeedTableVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Swimming pool, Adventure activities, 2 rooms, 1 Kitchen, Luxury Beds, Luxury furniture", new DateTime(2025, 3, 20, 15, 55, 26, 606, DateTimeKind.Local).AddTicks(2295), "", "Royal Villa", 5, 200.0, 400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Swimming pool, Adventure activities, 2 rooms, 1 Kitchen, Luxury Beds, Luxury furniture", new DateTime(2025, 3, 20, 15, 55, 26, 606, DateTimeKind.Local).AddTicks(2311), "", "Serene Villa", 5, 300.0, 600, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Swimming pool, Adventure activities, 2 rooms, 1 Kitchen, Luxury Beds, Luxury furniture", new DateTime(2025, 3, 20, 15, 55, 26, 606, DateTimeKind.Local).AddTicks(2314), "", "Heavenly Abode", 3, 150.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Swimming pool, Adventure activities, 2 rooms, 1 Kitchen, Luxury Beds, Luxury furniture", new DateTime(2025, 3, 20, 15, 55, 26, 606, DateTimeKind.Local).AddTicks(2315), "", "Peaceful Oasis", 8, 300.0, 800, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Swimming pool, Adventure activities, 2 rooms, 1 Kitchen, Luxury Beds, Luxury furniture", new DateTime(2025, 3, 20, 15, 55, 26, 606, DateTimeKind.Local).AddTicks(2317), "", "Rustic Hideaway", 9, 300.0, 1000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
