using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.WebAPI.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Expenses", "Income", "Name" },
                values: new object[] { 1, "TestData@test.com", 260.0m, 560.89m, "TestUser" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Expenses", "Income", "Name" },
                values: new object[] { 2, "TestData2@test.com", 250.0m, 760.89m, "TestUser2" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
