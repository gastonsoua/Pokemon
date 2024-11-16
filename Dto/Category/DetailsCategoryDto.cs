using System.Text.Json.Serialization;

namespace PokemonReview.Dto.Category
{
    public class DetailsCategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
