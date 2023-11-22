using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransactionOnDeleteNoAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_AspNetUsers_UserId",
                table: "TransactionDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_AspNetUsers_UserId",
                table: "TransactionDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetails_AspNetUsers_UserId",
                table: "TransactionDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetails_AspNetUsers_UserId",
                table: "TransactionDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
