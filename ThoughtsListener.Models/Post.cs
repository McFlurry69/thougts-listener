
using System.Collections.Generic;

namespace ThoughtsListener.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ArticleText { get; set; }
        public string HeaderImage { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<MediaContent> MediaContents { get; set; }
        public bool Deleted { get; set; }
    }
}