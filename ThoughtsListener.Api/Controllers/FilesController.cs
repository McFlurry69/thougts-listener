using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ThoughtsListener.Models;

namespace ThoughtsListener.Api.Controllers
{
    [Route("api/files")]
    public class FilesController: ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FilesController(IWebHostEnvironment env) => _env = env;

        [HttpGet("{file}")]
        public IActionResult GetFile(string file, string fileType)
        {
            var type = Enum.Parse<FileType>(fileType ?? "image", true);
            if (string.IsNullOrEmpty(type.ToString())) return BadRequest();
            var savePath = Path.Combine(_env.WebRootPath, string.Concat(type.ToString(), "s"), file);
            return new FileStreamResult(new FileStream(savePath, FileMode.Open, FileAccess.Read), $"{type.ToString().ToLowerInvariant()}/*");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile mediaFile, string fileType)
        {
            var type = Enum.Parse<FileType>(fileType, true);
            if (string.IsNullOrEmpty(type.ToString())) return BadRequest();
            var mime = mediaFile.FileName.Split('.').Last();
            var fileName = string.Concat(Path.GetRandomFileName(), $".{mime}");
            var savePath = Path.Combine(_env.WebRootPath, string.Concat(fileType, "s"), fileName);

            using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                await mediaFile.CopyToAsync(fileStream);
            }

            return Ok(fileName);
        }
    }
}