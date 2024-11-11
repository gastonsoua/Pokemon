using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models
{
    public class Pokemon
    {
        [Key] // Marks this property as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures auto-increment behavior
        public uint Id { get; set; }
        public required string Name { get; set; }
        public DateTime Birthday { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public ICollection<Reviewer>? Reviewers { get; set; }
        public ICollection<PokemonOwner>? PokemonOwners{ get; set; }
        public required ICollection<PokemonCategory> PokemonCategories{ get; set; }

    }
}
