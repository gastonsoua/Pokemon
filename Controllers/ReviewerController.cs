using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Dto.Reviewer;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Controllers
{
    [Route("reviewers")]
    public class ReviewerController : BaseController
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;
        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] CreateReviewerDto reviewerRequest)
        {
            var reviewer = _reviewerRepository.ReviewerExists(reviewerRequest.FirstName, reviewerRequest.LastName);
            if (reviewer)
            {
                ModelState.AddModelError("unique", "Reviewer already exixt");
                return StatusCode(422, ModelState);
            }
            var mappedReviewer = _mapper.Map<Reviewer>(reviewerRequest);
            _reviewerRepository.CreateReviewer(mappedReviewer);
            return Ok("succes");
        }
    }
}