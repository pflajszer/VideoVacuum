using System.Threading.Tasks;
using YoutubeExplode.Videos;

namespace VideoVacuum.BRL.Services.Abstractions
{
	public interface IVideoDownloader
	{
		Task<Video> Download(string address);
	}
}