using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThoughtsListener.Api.Controllers
{
    [Route("api/images")]
    public class ImagesController: ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public ImagesController(IWebHostEnvironment env)
        {
            _env = env;
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            var mime = image.FileName.Split('.').Last();
            var fileName = string.Concat(Path.GetRandomFileName(), $".{mime}");
            var savePath = Path.Combine(_env.WebRootPath, fileName);

            using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);
            }
            
            return Ok();
        }
    }
}