using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebProjectOAuth.Data;
using MoviesWebProjectOAuth.Models;

namespace MoviesWebProjectOAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews(string? content, string? userId, bool? liked)
        {
            IQueryable<Review> reviews = _context.Reviews.Include(x => x.User);
            if (!String.IsNullOrEmpty(userId))
                reviews = reviews.Where(t => t.UserId.Contains(userId));
            if (!String.IsNullOrEmpty(content))
                reviews = reviews.Where(t => t.Content.Contains(content));
            if (liked != null)
                reviews = reviews.Where(t => t.Liked == liked);

            return await reviews.ToListAsync<Review>();
        }
        // GET: api/Reviews/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(Guid id)
        {
            Review review = await _context.Reviews.Include(x => x.User).SingleAsync(x => x.Id == id);
            if (review == null)
                return NotFound("Review not found!");
            else
                return Ok(review);
        }
        // PUT: api/Reviews/Id
        [HttpPut("{id}")]
        public async Task<IActionResult> EditReview(Guid id, Review review)
        {
            if (!(_context.Reviews.Any(t => t.Id == id)))
                return NotFound("Review not found!");
            else
            {
                _context.Entry(review).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(review);
            }
        }
        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview(ReviewForms reviewF)
        {
            Review review = new Review { Id = new Guid(), Content = reviewF.Content,
            UserId = reviewF.UserId, Liked = reviewF.Liked, MovieId = Guid.Parse(reviewF.MovieId), Author = reviewF.Author};

            if (!(_context.Movies.Any(t => t.Id == review.MovieId)))
                return BadRequest("This movie doesnt exist!");

            Movie movie = await _context.Movies.Include(x => x.Reviews).SingleAsync(t => t.Id == review.MovieId);
            if (movie.Reviews.Any(x => x.UserId == review.UserId))
                return BadRequest("Only one review per movie allowed!");

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            movie.Score = (100 * movie.Reviews.Where(x => x.Liked == true).Count() / movie.Reviews.Count());
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }
        // DELETE: api/Reviews/id
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            Review review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return NotFound();

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // GET: api/Reviews/count
        [HttpGet("count")]
        public int GetReviewsCount()
        {
            return _context.Reviews.Count();
        }
    }    
}
