using Microsoft.EntityFrameworkCore.Migrations;

namespace SharesAPI.Migrations
{
    public partial class seeddataadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Share",
                columns: new[] { "Name", "Price" },
                values: new object[,]
                {
                    { "3M India Ltd", 21145.0 },
                    { "Aarti Drugs Ltd", 519.0 },
                    { "Tata Power", 277.80000000000001 },
                    { "HDFC Bank", 1516.75 },
                    { "Zee Entertainment", 284.75 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Name",
                keyValue: "3M India Ltd");

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Name",
                keyValue: "Aarti Drugs Ltd");

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Name",
                keyValue: "HDFC Bank");

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Name",
                keyValue: "Tata Power");

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Name",
                keyValue: "Zee Entertainment");
        }
    }
}
