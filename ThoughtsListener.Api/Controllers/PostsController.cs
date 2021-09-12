using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ThoughtsListener.Api.Models;

namespace ThoughtsListener.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostStore _postStore;

        public PostsController(PostStore postStore)
        {
            _postStore = postStore;
        }
        
        [HttpGet]
        public IActionResult GetAll() => Ok(_postStore.getAll);

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_postStore.getAll.FirstOrDefault(x => x.Id.Equals(id)));

        [HttpPost]
        public IActionResult Add([FromBody] Post post)
        {
            _postStore.Add(post);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Post post)
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Add(int id)
        {
            throw new NotImplementedException();
        }
    }
}