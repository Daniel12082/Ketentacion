using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_address_IdAddress",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "IdAddress",
                table: "user",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_user_IdAddress",
                table: "user",
                newName: "IX_user_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_address_AddressId",
                table: "user",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_address_AddressId",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "user",
                newName: "IdAddress");

            migrationBuilder.RenameIndex(
                name: "IX_user_AddressId",
                table: "user",
                newName: "IX_user_IdAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_user_address_IdAddress",
                table: "user",
                column: "IdAddress",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
