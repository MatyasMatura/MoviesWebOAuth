namespace MoviesWebProjectOAuth.Models
{
    public class ReviewForms
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public string Author { get; set; }
        public bool Liked { get; set; }
        public string MovieId { get; set; }
    }
}
