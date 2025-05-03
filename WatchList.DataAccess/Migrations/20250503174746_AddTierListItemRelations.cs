using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTierListItemRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieListItems_MovieLists_MovieListId",
                table: "MovieListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieListItems_Movies_MovieId",
                table: "MovieListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesListItems_SeriesLists_SeriesListId",
                table: "SeriesListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesListItems_Series_SeriesId",
                table: "SeriesListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TierListItems_TierLists_TierListId",
                table: "TierListItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "TierListItems");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "TierListItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "TierListItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TierListItems_MovieId",
                table: "TierListItems",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_TierListItems_SeriesId",
                table: "TierListItems",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieListItems_MovieLists_MovieListId",
                table: "MovieListItems",
                column: "MovieListId",
                principalTable: "MovieLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieListItems_Movies_MovieId",
                table: "MovieListItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesListItems_SeriesLists_SeriesListId",
                table: "SeriesListItems",
                column: "SeriesListId",
                principalTable: "SeriesLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesListItems_Series_SeriesId",
                table: "SeriesListItems",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TierListItems_Movies_MovieId",
                table: "TierListItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TierListItems_Series_SeriesId",
                table: "TierListItems",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TierListItems_TierLists_TierListId",
                table: "TierListItems",
                column: "TierListId",
                principalTable: "TierLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieListItems_MovieLists_MovieListId",
                table: "MovieListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieListItems_Movies_MovieId",
                table: "MovieListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesListItems_SeriesLists_SeriesListId",
                table: "SeriesListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesListItems_Series_SeriesId",
                table: "SeriesListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TierListItems_Movies_MovieId",
                table: "TierListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TierListItems_Series_SeriesId",
                table: "TierListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TierListItems_TierLists_TierListId",
                table: "TierListItems");

            migrationBuilder.DropIndex(
                name: "IX_TierListItems_MovieId",
                table: "TierListItems");

            migrationBuilder.DropIndex(
                name: "IX_TierListItems_SeriesId",
                table: "TierListItems");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "TierListItems");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "TierListItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "TierListItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieListItems_MovieLists_MovieListId",
                table: "MovieListItems",
                column: "MovieListId",
                principalTable: "MovieLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieListItems_Movies_MovieId",
                table: "MovieListItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesListItems_SeriesLists_SeriesListId",
                table: "SeriesListItems",
                column: "SeriesListId",
                principalTable: "SeriesLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesListItems_Series_SeriesId",
                table: "SeriesListItems",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TierListItems_TierLists_TierListId",
                table: "TierListItems",
                column: "TierListId",
                principalTable: "TierLists",
                principalColumn: "Id");
        }
    }
}
