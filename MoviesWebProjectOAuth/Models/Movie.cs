using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesWebProjectOAuth.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        public int? Score { get; set; }
        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; }
    }
}
