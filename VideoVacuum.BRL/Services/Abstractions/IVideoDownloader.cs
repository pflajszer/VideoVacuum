using System.Threading.Tasks;
using VideoVacuum.BRL.ViewModels;
using YoutubeExplode.Videos;

namespace VideoVacuum.BRL.Services.Abstractions
{
	public interface IVideoDownloader
	{
		Task<Video> DownloadMetadata(string address);
		Task<VideoViewModel> DownloadMp3(VideoViewModel model, string basePath);
	}
}