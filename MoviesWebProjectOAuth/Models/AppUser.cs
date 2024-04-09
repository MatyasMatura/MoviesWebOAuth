using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesWebProjectOAuth.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; }
    }
}
