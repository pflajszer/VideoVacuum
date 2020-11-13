using System;
using System.Diagnostics;
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
				var fileName = $"{model.Author} - {model.Title}_{Guid.NewGuid()}.{streamInfo.Container}";
				model.OriginalFileName = ReplaceInvalidChars(fileName);
				var filepath = Path.Combine(basePath, model.OriginalFileName);
				//await converter.DownloadAndProcessMediaStreamsAsync(streamInfos, filepath, "mp3");
				await _youtubeDownloader.Videos.Streams.DownloadAsync(streamInfo, filepath);
				//await _youtubeDownloader.Videos.DownloadAsync((streamInfos, new ConversionRequestBuilder("audio.mp3").Build());
				//var proc = new Process();
				//proc.StartInfo.FileName = Path.Combine(basePath, "ffmpeg.exe");
				////proc.StartInfo.Arguments = $"-i {filepath} -vn -f mp3 -ab 192k {Path.Combine(basePath, "output.mp3")}";
				//proc.StartInfo.Arguments = $"-i {filepath} -vn -ar 44100 -ac 2 -ab 192k -f mp3 {Path.Combine(basePath, "output.mp3")}";
				//proc.StartInfo.RedirectStandardError = true;
				//proc.StartInfo.UseShellExecute = false;
				//if (!proc.Start())
				//{
				//	Console.WriteLine("Error starting");
				//}
				//StreamReader reader = proc.StandardError;
				//string line;
				//while ((line = reader.ReadLine()) != null)
				//{
				//	Console.WriteLine(line);
				//}
				//proc.Close();

				using (Process p = new Process())
				{
					p.StartInfo.UseShellExecute = false;
					p.StartInfo.CreateNoWindow = true;
					p.StartInfo.RedirectStandardOutput = true;
					p.StartInfo.FileName = Path.Combine(basePath, "ffmpeg.exe");
					var mp3fileName = $"{model.Author} - {model.Title}_{Guid.NewGuid()}.mp3";
					p.StartInfo.Arguments = $"-i \"{filepath}\" -vn -ar 44100 -ac 2 -ab 192k -f mp3 \"{Path.Combine(basePath, mp3fileName)}\"";
					p.Start();
					p.WaitForExit();
					model.MP3FileName = mp3fileName;
					var result = p.StandardOutput.ReadToEnd();
				} 


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
