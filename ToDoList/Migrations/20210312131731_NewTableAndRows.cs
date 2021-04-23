using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
    public partial class NewTableAndRows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "ToDoList");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ToDoList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDoList",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "ToDoList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoList_CategoryId",
                table: "ToDoList",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoList_Categories_CategoryId",
                table: "ToDoList",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoList_Categories_CategoryId",
                table: "ToDoList");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_ToDoList_CategoryId",
                table: "ToDoList");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ToDoList");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDoList");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "ToDoList");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "ToDoList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
