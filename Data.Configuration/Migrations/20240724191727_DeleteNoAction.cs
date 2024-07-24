using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Configuration.Migrations
{
    /// <inheritdoc />
    public partial class DeleteNoAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                schema: "Library",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Gender_GenderId",
                schema: "Library",
                table: "Book");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                schema: "Library",
                table: "Book",
                column: "AuthorId",
                principalSchema: "Library",
                principalTable: "Author",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Gender_GenderId",
                schema: "Library",
                table: "Book",
                column: "GenderId",
                principalSchema: "Library",
                principalTable: "Gender",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                schema: "Library",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Gender_GenderId",
                schema: "Library",
                table: "Book");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                schema: "Library",
                table: "Book",
                column: "AuthorId",
                principalSchema: "Library",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Gender_GenderId",
                schema: "Library",
                table: "Book",
                column: "GenderId",
                principalSchema: "Library",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
