using AutoMapper;
using System.Threading.Tasks;
using VideoVacuum.BRL.Services.Abstractions;
using VideoVacuum.BRL.ViewModels;
using YoutubeExplode.Videos;

namespace VideoVacuum.BRL.Services.Implementations
{
	public class VideoConverter : IVideoConverter
	{
		private readonly IMapper _mapper;
		public VideoConverter(IMapper mapper)
		{
			_mapper = mapper;
		}
		public async Task<VideoViewModel> Convert(Video video)
		{
			var model = _mapper.Map<VideoViewModel>(video);
			return model;
		}
	}
}
