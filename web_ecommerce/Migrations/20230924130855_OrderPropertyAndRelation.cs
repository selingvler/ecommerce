using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class OrderPropertyAndRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderInstances_OrderId",
                schema: "dbo",
                table: "OrderInstances");

            migrationBuilder.DropIndex(
                name: "IX_OrderInstances_UserProductId",
                schema: "dbo",
                table: "OrderInstances");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                schema: "dbo",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInstances_OrderId",
                schema: "dbo",
                table: "OrderInstances",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInstances_UserProductId",
                schema: "dbo",
                table: "OrderInstances",
                column: "UserProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderInstances_OrderId",
                schema: "dbo",
                table: "OrderInstances");

            migrationBuilder.DropIndex(
                name: "IX_OrderInstances_UserProductId",
                schema: "dbo",
                table: "OrderInstances");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInstances_OrderId",
                schema: "dbo",
                table: "OrderInstances",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderInstances_UserProductId",
                schema: "dbo",
                table: "OrderInstances",
                column: "UserProductId",
                unique: true);
        }
    }
}
