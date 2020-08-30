using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<VideoViewModel> DownloadVideoMetadata(string videoAddress)
		{
            var model = await _yt.GetVideoMetadata(videoAddress);
            return model;
		}
    }
}
