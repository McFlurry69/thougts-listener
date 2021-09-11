using Microsoft.AspNetCore.Mvc;

namespace ThoughtsListener.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Hello there from controller!";
        }
    }
}