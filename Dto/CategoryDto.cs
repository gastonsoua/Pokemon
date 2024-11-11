using System.Text.Json.Serialization;

namespace PokemonReview.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
