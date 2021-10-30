using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVacuum.BRL.Services.Abstractions;
using VideoVacuum.BRL.ViewModels;

namespace VideoVacuum.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VideoController : ControllerBase
    {

        private readonly IWebHostEnvironment _env;
        private readonly IYouTubeService _yt;

		public string BasePath { get; set; }
		public VideoController(IYouTubeService yt, IWebHostEnvironment env)
		{
            _env = env;
            _yt = yt;
            BasePath = _env.WebRootPath;
		}

        [HttpGet]
        public async Task<VideoViewModel> DownloadVideoMetadata(string videoAddress)
		{
            var model = await _yt.GetVideoMetadata(videoAddress);
            model = await _yt.DownloadMp3(model, BasePath);
            return model;
		}

        [HttpPost]
        public async Task SetVideoMetadata(VideoViewModel model)
        { 
           _yt.SetVideoMetadata(model, BasePath);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile(string filename)
        {
            //var path = @"C:\Users\PawelFlajszer\source\repos\VideoVacuum\VideoVacuum.UI\wwwroot";
            var filepath = Path.Combine(BasePath, filename);
            try
            {
                //string file = @"c:\temp\test.mp3";

                var memory = new MemoryStream();
                using (var stream = new FileStream(filepath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }

                memory.Position = 0;
                return File(memory, GetMimeType(filepath), filename);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
