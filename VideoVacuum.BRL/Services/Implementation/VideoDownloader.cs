using System;
using System.Threading.Tasks;
using System.Web;
using VideoVacuum.BRL.Services.Abstractions;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace VideoVacuum.BRL.Services.Implementations
{
	public class VideoDownloader : IVideoDownloader
	{
		private readonly YoutubeClient _youtube;
		public VideoDownloader(YoutubeClient youtube)
		{
			_youtube = youtube;
		}
		public async Task<Video> DownloadMetadata(string videoAddress)
		{
			try
			{
				//var youtube = new YoutubeClient();
				var video = await _youtube.Videos.GetAsync(videoAddress);
				return video;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task<Video> DownloadMp3(string basePath, string videoId)
		{
			throw new NotImplementedException();
		}

		private static string GetVideoIdFromQueryString(string videoAddress)
		{
			var qs = videoAddress.Split('?');
			var parsed = HttpUtility.ParseQueryString(qs[1]);
			var videoId = parsed["v"];
			return videoId;
		}
	}
}
