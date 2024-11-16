using System.Text.Json.Serialization;

namespace PokemonReview.Dto.Category
{
    public class Details
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
