using System.Threading.Tasks;
using VideoVacuum.BRL.Services.Abstractions;
using VideoVacuum.BRL.ViewModels;
using YoutubeExplode.Videos;

namespace VideoVacuum.BRL.Services.Implementations
{
	public class VideoConverter : IVideoConverter
	{
		public async Task<VideoViewModel> Convert(Video video)
		{
			return new VideoViewModel();
		}
	}
}
