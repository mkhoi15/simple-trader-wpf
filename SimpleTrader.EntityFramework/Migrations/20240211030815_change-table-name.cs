using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleTrader.EntityFramework.Migrations
{
    public partial class changetablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetTransactionId = table.Column<int>(type: "int", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceShare = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetTransactionId);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTransactions_AssetTransactionId",
                        column: x => x.AssetTransactionId,
                        principalTable: "AssetTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    AssetTransactionId = table.Column<int>(type: "int", nullable: false),
                    PriceShare = table.Column<double>(type: "float", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.AssetTransactionId);
                    table.ForeignKey(
                        name: "FK_Stocks_AssetTransactions_AssetTransactionId",
                        column: x => x.AssetTransactionId,
                        principalTable: "AssetTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
