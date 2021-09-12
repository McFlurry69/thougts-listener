using System.Collections.Generic;
using ThoughtsListener.Api.Models;

namespace ThoughtsListener.Api
{
    public class PostStore
    {
        private readonly List<Post> _posts;

        public PostStore()
        {
            _posts = new List<Post>();
        }

        public IEnumerable<Post> getAll => _posts;

        public void Add(Post post) => _posts.Add(new Post{Article = post.Article, BodyText = post.BodyText, Id = _posts.Count + 1});
    }
}