﻿using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IVideoEditor _editor;
		
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

        public async Task<VideoViewModel> DownloadMp3(VideoViewModel model, string basePath)
		{
            var result = await _downloader.DownloadMp3(model, basePath);
            return result;
		}

		public void SetVideoMetadata(VideoViewModel model, string basePath)
		{
			var filePath = Path.Combine(basePath, model.FileName);
			var tfile = TagLib.File.Create(filePath);
			tfile.Tag.Performers = new[] { model.Author };
			tfile.Tag.Title = "asdsadsadas";
			//tfile.Tag.Title = model.Title;
			//tfile.Tag.Year = (uint)tags.Year;
			//if (tags.Artists != null)
			//	tfile.Tag.Performers = new[] { tags.Artists };
			//if (tags.Genres != null)
			//	tfile.Tag.Genres = new[] { tags.Genres };
			tfile.Save();
		}
	}
}