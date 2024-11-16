using System.Text.Json.Serialization;

namespace PokemonReview.Dto.Category
{
    public class Create
    {
        public required string Name { get; set; }
    }
}
