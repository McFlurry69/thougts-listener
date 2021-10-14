namespace ThoughtsListener.Models
{
    public class PostCategory
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}