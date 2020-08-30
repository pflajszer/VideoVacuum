using System.Threading.Tasks;
using YoutubeExplode.Videos;

namespace VideoVacuum.BRL.Services.Abstractions
{
	public interface IVideoDownloader
	{
		Task<Video> DownloadMetadata(string address);
		Task<Video> DownloadMp3(string basePath, string videoId);
	}
}