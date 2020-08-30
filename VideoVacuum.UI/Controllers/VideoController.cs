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
        private readonly IVideoDownloader _downloader;
        private readonly IVideoConverter _converter;
		public VideoController(IVideoDownloader downloader, IVideoConverter converter)
		{
            _downloader = downloader;
            _converter = converter;
		}
        public async Task<VideoViewModel> DownloadVideo(string address)
		{
            var video = await _downloader.Download(address);
            var model = await _converter.Convert(video);
            return model;
		}
    }
}
