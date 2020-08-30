using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVacuum.BRL.Services.Abstractions;
using VideoVacuum.BRL.ViewModels;

namespace VideoVacuum.BRL.Services.Implementation
{
    public class YouTubeService : IYouTubeService
    {
        private readonly IVideoDownloader _downloader;
        private readonly IVideoConverter _converter;
		
        public YouTubeService(IVideoDownloader downloader, IVideoConverter converter)
		{
            _downloader = downloader;
            _converter = converter;
        }

        public async Task<VideoViewModel> GetVideoMetadata(string videoAddress)
		{
            var video = await _downloader.DownloadMetadata(videoAddress);
            var model = await _converter.Convert(video);
            return model;
        }
    }
}
