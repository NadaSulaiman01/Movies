using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Migrations
{
    public partial class AddActorMovieClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsActorId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MoviesMovieId",
                table: "ActorMovie");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Movies",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "MoviesMovieId",
                table: "ActorMovie",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "ActorsActorId",
                table: "ActorMovie",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MoviesMovieId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                table: "ActorMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                table: "ActorMovie");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Movies",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "ActorMovie",
                newName: "MoviesMovieId");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "ActorMovie",
                newName: "ActorsActorId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MovieId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MoviesMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsActorId",
                table: "ActorMovie",
                column: "ActorsActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MoviesMovieId",
                table: "ActorMovie",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
