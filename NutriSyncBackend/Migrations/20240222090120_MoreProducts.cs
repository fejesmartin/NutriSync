using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutriSyncBackend.Migrations
{
    /// <inheritdoc />
    public partial class MoreProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Price", "ProductName", "UserId" },
                values: new object[,]
                {
                    { 3, "Adjustable jump rope for cardio workouts", 9.99m, "Jump Rope", null },
                    { 4, "Set of resistance bands for various strength exercises", 14.99m, "Resistance Bands", null },
                    { 5, "Cast iron kettlebell for full-body workouts", 29.99m, "Kettlebell", null },
                    { 6, "High-density foam roller for muscle recovery", 12.99m, "Foam Roller", null },
                    { 7, "Set of yoga blocks for support and balance", 8.99m, "Yoga Blocks", null },
                    { 8, "Doorway pull-up bar for upper body workouts", 24.99m, "Pull-Up Bar", null },
                    { 9, "Pair of boxing gloves for boxing and kickboxing", 34.99m, "Boxing Gloves", null },
                    { 10, "Medicine ball for strength and coordination exercises", 39.99m, "Medicine Ball", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);
        }
    }
}
