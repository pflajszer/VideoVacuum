using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using VideoVacuum.BRL.Services.Abstractions;
using VideoVacuum.BRL.ViewModels;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace VideoVacuum.BRL.Services.Implementations
{
	public class VideoDownloader : IVideoDownloader
	{
		private readonly YoutubeClient _youtubeDownloader;
		//private readonly IYoutubeConverter _youtubeConverter;
		public VideoDownloader(YoutubeClient youtubeDownloader)
		{
			_youtubeDownloader = youtubeDownloader;
		}
		public async Task<Video> DownloadMetadata(string videoAddress)
		{
			try
			{
				//var youtube = new YoutubeClient();
				var video = await _youtubeDownloader.Videos.GetAsync(videoAddress);
				return video;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<VideoViewModel> DownloadMp3(VideoViewModel model, string basePath)
		{
			try
			{
				//var converter = new YoutubeConverter(_youtubeDownloader, Path.Combine(basePath, "ffmpeg.exe"));
				//await converter.DownloadVideoAsync("4Bs2wOqFFck", $"video_{Guid.NewGuid()}.mp4");
				var streamManifest = await _youtubeDownloader.Videos.Streams.GetManifestAsync(model.VideoId);
				var streamInfo = streamManifest.GetAudioOnly().WithHighestBitrate();
				// Combine them into a collection
				var streamInfos = new IStreamInfo[] { streamInfo };
				var fileName = $"{model.Author} - {model.Title}_{Guid.NewGuid()}.mp3";
				model.FileName = ReplaceInvalidChars(fileName);
				var filepath = Path.Combine(basePath, model.FileName);
				//await converter.DownloadAndProcessMediaStreamsAsync(streamInfos, filepath, "mp3");
				await _youtubeDownloader.Videos.Streams.DownloadAsync(streamInfo, filepath);
				return model;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private static string GetVideoIdFromQueryString(string videoAddress)
		{
			var qs = videoAddress.Split('?');
			var parsed = HttpUtility.ParseQueryString(qs[1]);
			var videoId = parsed["v"];
			return videoId;
		}

		public string ReplaceInvalidChars(string filename)
		{
			return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
		}
	}
}
