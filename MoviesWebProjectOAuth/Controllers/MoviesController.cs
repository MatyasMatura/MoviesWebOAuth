using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebProjectOAuth.Data;
using MoviesWebProjectOAuth.Models;

namespace MoviesWebProjectOAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(string? name, string? description, int? year, string? director, int? score, string? scoreOrder, int? limit)
        {
            IQueryable<Movie> movies = _context.Movies;
            if (!String.IsNullOrEmpty(name))
                movies = movies.Where(t => t.Name.Contains(name));
            if (!String.IsNullOrEmpty(description))
                movies = movies.Where(t => t.Description.Contains(description));
            if (year != null)
                movies = movies.Where(t => t.Year == year);
            if (!String.IsNullOrEmpty(director))
                movies = movies.Where(t => t.Director.Contains(director));
            if (score != null)
                movies = movies.Where(t => t.Score == score);
            if (!String.IsNullOrEmpty(scoreOrder))
            {
                if (scoreOrder.ToLower() == "worst")
                    movies = movies.OrderBy(t => t.Score);
                if (scoreOrder.ToLower() == "best")
                    movies = movies.OrderByDescending(t => t.Score);
            }
            if (limit != null)
            {
                movies = movies.Take((int)limit);
            }

            return await movies.ToListAsync<Movie>();
        }
        // GET: api/Movies/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetMovie(Guid id)
        {
            Movie movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound("Movie not found!");
            else
                return Ok(movie);
        }
        // PUT: api/Movies/Id
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditMovie(Guid id, Movie movie)
        {
            if (!(_context.Movies.Any(t => t.Id == id)))
                return NotFound("Movie not found!");
            else
            {
                _context.Entry(movie).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(movie);
            }
        }
        // POST: api/Movies
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(MovieForms movieF)
        {
            Movie movie = new Movie { Id = new Guid(), Description = movieF.Description, Director = movieF.Director, 
            Name = movieF.Name, Year = movieF.Year};

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }
        // DELETE: api/Movies/id
        [Authorize(Policy = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            Movie movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // GET: api/Movies/id/reviews
        [HttpGet("{id}/reviews")]
        public ActionResult<IList<Review>> GetMovieReviews(Guid id, int? limit)
        {
            Movie movie = _context.Movies.Include(t => t.Reviews).SingleOrDefault(t => t.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            if (limit != null)
            {
                return movie.Reviews.Take((int)limit).ToList();
            }

            return movie.Reviews.ToList();
        }
        // GET: api/Movies/count
        [HttpGet("count")]
        public int GetMoviesCount()
        {
            return _context.Movies.Count();
        }
    }
}
