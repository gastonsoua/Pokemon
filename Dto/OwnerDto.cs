using PokemonReview.Models;

namespace PokemonReview.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Gym { get; set; }
    }
}
