using System.Text.Json.Serialization;

namespace PokemonReview.Dto.Category
{
    public class CreateCategoryDto
    {
        public required string Name { get; set; }
    }
}
