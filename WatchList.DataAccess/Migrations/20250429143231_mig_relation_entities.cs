using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_relation_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "TierLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "SeriesLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "MovieLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TierLists_AppUserId",
                table: "TierLists",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesLists_AppUserId",
                table: "SeriesLists",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_AppUserId",
                table: "Series",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_AppUserId",
                table: "Movies",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLists_AppUserId",
                table: "MovieLists",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLists_AspNetUsers_AppUserId",
                table: "MovieLists",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_AspNetUsers_AppUserId",
                table: "Movies",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_AspNetUsers_AppUserId",
                table: "Series",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesLists_AspNetUsers_AppUserId",
                table: "SeriesLists",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TierLists_AspNetUsers_AppUserId",
                table: "TierLists",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieLists_AspNetUsers_AppUserId",
                table: "MovieLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_AspNetUsers_AppUserId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_AspNetUsers_AppUserId",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesLists_AspNetUsers_AppUserId",
                table: "SeriesLists");

            migrationBuilder.DropForeignKey(
                name: "FK_TierLists_AspNetUsers_AppUserId",
                table: "TierLists");

            migrationBuilder.DropIndex(
                name: "IX_TierLists_AppUserId",
                table: "TierLists");

            migrationBuilder.DropIndex(
                name: "IX_SeriesLists_AppUserId",
                table: "SeriesLists");

            migrationBuilder.DropIndex(
                name: "IX_Series_AppUserId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Movies_AppUserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_MovieLists_AppUserId",
                table: "MovieLists");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TierLists");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "SeriesLists");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "MovieLists");
        }
    }
}
