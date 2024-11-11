using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models
{
    public class PokemonCategory
    {
        [Key] // Marks this property as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures auto-increment behavior
        public uint Id { get; set; }
        public uint PokemonId { get; set; }
        public uint CategoryId { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
