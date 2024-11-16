using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface IReviewerRepository
    {
        bool ReviewerExists(string firstName, string lastName);
        bool CreateReviewer(Reviewer reviewer);
        bool Save();
    }
}
