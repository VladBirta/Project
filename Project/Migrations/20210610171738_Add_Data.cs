using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Add_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Education",
                columns: new[] { "ID", "EducationContent", "EducationTitle", "PublicationDate" },
                values: new object[] { new Guid("57ea92ff-5ac7-4f49-b327-08aa85ac132c"), "Multe-s", "Nvidia GTX1650", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Education",
                keyColumn: "ID",
                keyValue: new Guid("57ea92ff-5ac7-4f49-b327-08aa85ac132c"));
        }
    }
}
