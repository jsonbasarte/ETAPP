using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseEntry_AspNetUsers_UserId",
                table: "ExpenseEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseEntry_Categories_CategoryId",
                table: "ExpenseEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseEntry_PaymentMethod_PaymentMethodId",
                table: "ExpenseEntry");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseEntry",
                table: "ExpenseEntry");

            migrationBuilder.RenameTable(
                name: "ExpenseEntry",
                newName: "ExpenseEntries");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseEntry_UserId",
                table: "ExpenseEntries",
                newName: "IX_ExpenseEntries_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseEntry_PaymentMethodId",
                table: "ExpenseEntries",
                newName: "IX_ExpenseEntries_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseEntry_CategoryId",
                table: "ExpenseEntries",
                newName: "IX_ExpenseEntries_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseEntries",
                table: "ExpenseEntries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseEntries_AspNetUsers_UserId",
                table: "ExpenseEntries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseEntries_Categories_CategoryId",
                table: "ExpenseEntries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseEntries_PaymentType_PaymentMethodId",
                table: "ExpenseEntries",
                column: "PaymentMethodId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseEntries_AspNetUsers_UserId",
                table: "ExpenseEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseEntries_Categories_CategoryId",
                table: "ExpenseEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseEntries_PaymentType_PaymentMethodId",
                table: "ExpenseEntries");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseEntries",
                table: "ExpenseEntries");

            migrationBuilder.RenameTable(
                name: "ExpenseEntries",
                newName: "ExpenseEntry");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseEntries_UserId",
                table: "ExpenseEntry",
                newName: "IX_ExpenseEntry_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseEntries_PaymentMethodId",
                table: "ExpenseEntry",
                newName: "IX_ExpenseEntry_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseEntries_CategoryId",
                table: "ExpenseEntry",
                newName: "IX_ExpenseEntry_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseEntry",
                table: "ExpenseEntry",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseEntry_AspNetUsers_UserId",
                table: "ExpenseEntry",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseEntry_Categories_CategoryId",
                table: "ExpenseEntry",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseEntry_PaymentMethod_PaymentMethodId",
                table: "ExpenseEntry",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
