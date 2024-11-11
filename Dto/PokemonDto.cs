
namespace PokemonReview.Dto
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
