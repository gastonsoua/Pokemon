using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateReviewer(Reviewer reviewer)
        {
            reviewer.CreatedAt = DateTime.Now;
            reviewer.UpdatedAt = DateTime.Now;
            _context.Add(reviewer);
            return Save();

        }

        public bool ReviewerExists(string firstName, string lastName)
        {
            var fullName = firstName + "_" + lastName;
            var reviewer = _context.Reviewers.Where(r => (r.FirstName + "_" + r.LastName) == fullName).FirstOrDefault();
            return reviewer != null;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
