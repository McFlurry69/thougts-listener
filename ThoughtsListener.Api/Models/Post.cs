using Microsoft.AspNetCore.Http;

namespace ThoughtsListener.Api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ArticleText { get; set; }
        public string HeaderImage { get; set; }
        public string[] Categories { get; set; }
    }
}