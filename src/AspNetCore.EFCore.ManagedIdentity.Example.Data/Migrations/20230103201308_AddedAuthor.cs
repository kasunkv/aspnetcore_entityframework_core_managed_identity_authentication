using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore.CRUD.Example.Data.Migrations
{
    public partial class AddedAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 1, "DevOps", "Gean Kim" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 2, "Frontend", "Cory House" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
