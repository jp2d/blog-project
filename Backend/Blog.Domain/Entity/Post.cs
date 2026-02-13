namespace Blog.Domain.Entity
{
    public class Post
    {
        public int Id { get; set; }
        public required string Titule { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required User User { get; set; }
    }
}
