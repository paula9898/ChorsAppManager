using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChorsAppManager.Backend.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserNameCharacters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b2e51003-e6af-4335-b778-ccea346578f9");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "95679dce-e70e-4ec4-8c96-cd4245bd6e01");
        }
    }
}
