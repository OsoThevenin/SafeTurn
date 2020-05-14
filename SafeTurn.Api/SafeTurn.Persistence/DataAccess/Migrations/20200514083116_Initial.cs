using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SafeTurn.Persistence.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SimultaneousTurns = table.Column<int>(nullable: false),
                    MinutesForTurn = table.Column<int>(nullable: false),
                    MondayStart = table.Column<TimeSpan>(nullable: false),
                    MondayEnd = table.Column<TimeSpan>(nullable: false),
                    TuesdayStart = table.Column<TimeSpan>(nullable: false),
                    TuesdayEnd = table.Column<TimeSpan>(nullable: false),
                    WednesdayStart = table.Column<TimeSpan>(nullable: false),
                    WednesdayEnd = table.Column<TimeSpan>(nullable: false),
                    ThursdayStart = table.Column<TimeSpan>(nullable: false),
                    ThursdayEnd = table.Column<TimeSpan>(nullable: false),
                    FridayStart = table.Column<TimeSpan>(nullable: false),
                    FridayEnd = table.Column<TimeSpan>(nullable: false),
                    SaturdayStart = table.Column<TimeSpan>(nullable: false),
                    SaturdayEnd = table.Column<TimeSpan>(nullable: false),
                    SundayStart = table.Column<TimeSpan>(nullable: false),
                    SundayEnd = table.Column<TimeSpan>(nullable: false),
                    Published = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    IdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: false),
                    ShopCode = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    Confirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turns_Shops_ShopCode",
                        column: x => x.ShopCode,
                        principalTable: "Shops",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RemoteIpAddress = table.Column<string>(nullable: true),
                    UserId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId1",
                table: "RefreshToken",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_ShopCode",
                table: "Turns",
                column: "ShopCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
