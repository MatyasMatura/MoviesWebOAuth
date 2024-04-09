using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebProjectOAuth.Data;
using MoviesWebProjectOAuth.Models;
using System.Security.Claims;
using System.Text.Json;

namespace MoviesWebProjectOAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "Administrator")]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [Authorize]
        [HttpGet]
        public UserIdentificator Get()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            return new UserIdentificator { Id = userId };
        }
        [HttpPost]
        public async Task<ActionResult<AppUser>> Create([FromBody] JsonElement body)
        {
            string json = JsonSerializer.Serialize(body);
            var parsedJson = JsonDocument.Parse(json).RootElement;
            var userId = parsedJson.GetProperty("userId").ToString();
            var name = parsedJson.GetProperty("name").ToString();
            var email = parsedJson.GetProperty("email").ToString();
            if (!UserExists(userId))
            {
                AppUser user = new AppUser
                {
                    Id = userId,
                    Name = name,
                    Email = email
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            else
            {
                return Forbid();
            }
        }
        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
