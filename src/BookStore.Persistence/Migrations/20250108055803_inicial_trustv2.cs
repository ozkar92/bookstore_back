using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class inicial_trustv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "BookOrder");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookId",
                table: "Order",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Book_BookId",
                table: "Order",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Book_BookId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BookId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "BookOrder",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookOrder", x => new { x.BooksId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_BookOrder_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookOrder_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookOrder_OrdersId",
                table: "BookOrder",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
