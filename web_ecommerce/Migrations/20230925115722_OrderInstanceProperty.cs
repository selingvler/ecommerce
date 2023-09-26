using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class OrderInstanceProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "OrderInstances",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "OrderInstances");
        }
    }
}
