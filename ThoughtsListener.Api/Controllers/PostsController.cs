using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThoughtsListener.Data;
using ThoughtsListener.Models;

namespace ThoughtsListener.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public PostsController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<Post> GetAll() => _ctx.Posts.ToList();

        [HttpGet("{id}")]
        public Post Get(int id) => _ctx.Posts.FirstOrDefault(x => x.Id.Equals(id));

        [HttpPost]
        public async Task<Post> Create([FromBody] Post post)
        {
            _ctx.Posts.Add(post);
            await _ctx.SaveChangesAsync();
            return post;
        }
        
        [HttpPut]
        public async Task<Post> Update([FromBody] Post post)
        {
            if (post.Id == 0)
            {
                return null;
            }

            _ctx.Posts.Add(post);
            await _ctx.SaveChangesAsync();
            return post;
        }
        
        [HttpDelete("{id}")]
        public async Task<Post> Delete(int id)
        {
            var post = _ctx.Posts.FirstOrDefault(x => x.Id.Equals(id));
            if (post != null) post.Deleted = true;
            await _ctx.SaveChangesAsync();
            return post;
        }
    }
}