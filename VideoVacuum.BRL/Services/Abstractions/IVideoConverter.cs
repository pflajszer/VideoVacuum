using System.Threading.Tasks;
using VideoVacuum.BRL.ViewModels;
using YoutubeExplode.Videos;

namespace VideoVacuum.BRL.Services.Abstractions
{
	public interface IVideoConverter
	{
		Task<VideoViewModel> Convert(Video video);
	}
}