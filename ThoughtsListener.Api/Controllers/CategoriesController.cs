using Microsoft.AspNetCore.Mvc;
using ThoughtsListener.Data;
using ThoughtsListener.Models;

namespace ThoughtsListener.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController: ControllerBase
    {
        private readonly AppDbContext _ctx;
        
        public CategoriesController(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var t = new string[] { "cooking", "traveling" };
            return Ok(t);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            _ctx.Categories.Add(category);
            return Ok();
        }
    }
}