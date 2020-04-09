using Microsoft.EntityFrameworkCore.Migrations;

namespace GameEngine.Library.Migrations
{
    public partial class CompleteNot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pawns_PawnNumber_Color",
                table: "Pawns");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Pawns",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Pawns",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pawns_PawnNumber_Color",
                table: "Pawns",
                columns: new[] { "PawnNumber", "Color" },
                unique: true,
                filter: "[Color] IS NOT NULL");
        }
    }
}
