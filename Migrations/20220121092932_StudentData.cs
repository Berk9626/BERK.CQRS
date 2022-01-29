using Microsoft.EntityFrameworkCore.Migrations;

namespace Berk.CQRS.Migrations
{
	public partial class StudentData : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Students",
				columns: new[] { "Id", "Age", "Name", "Surname" },
				values: new object[] { 1, 26, "Berk", "Berkmen" });

			migrationBuilder.InsertData(
				table: "Students",
				columns: new[] { "Id", "Age", "Name", "Surname" },
				values: new object[] { 2, 23, "Sabahattin", "Berkmen" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Students",
				keyColumn: "Id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "Students",
				keyColumn: "Id",
				keyValue: 2);
		}
	}
}
