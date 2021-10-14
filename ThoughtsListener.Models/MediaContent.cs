namespace ThoughtsListener.Models
{
    public class MediaContent
    {
        public int Id { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public string FileName { get; set; }
        public FileType Type { get; set; }
    }
}