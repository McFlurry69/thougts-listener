using Microsoft.AspNetCore.Mvc;

namespace ThoughtsListener.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var t = new string[] { "cooking", "traveling" };
            return Ok(t);
        }
    }
}