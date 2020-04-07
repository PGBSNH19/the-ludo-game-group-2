using Microsoft.EntityFrameworkCore.Migrations;

namespace GameEngine.Library.Migrations
{
    public partial class Complete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GameName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Pawns",
                columns: table => new
                {
                    PawnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PawnNumber = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    HasStarted = table.Column<bool>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    HasReachedGoal = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pawns", x => x.PawnID);
                    table.ForeignKey(
                        name: "FK_Pawns_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pawns_UserID",
                table: "Pawns",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Pawns_PawnNumber_Color",
                table: "Pawns",
                columns: new[] { "PawnNumber", "Color" },
                unique: true,
                filter: "[Color] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pawns");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
