using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReview.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReviewsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviewers_PokemonId",
                table: "Reviewers"
                );
            // Drop foreign key
            migrationBuilder.DropForeignKey(
                name: "FK_Reviewers_Pokemons_PokemonId",
                table: "Reviewers"
                );
            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "Reviewers"
                );
    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
