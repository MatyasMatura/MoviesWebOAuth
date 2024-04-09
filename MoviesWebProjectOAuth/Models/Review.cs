using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesWebProjectOAuth.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        [JsonIgnore]
        public AppUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public bool Liked { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
    }
}
