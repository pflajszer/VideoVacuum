using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVacuum.BRL.Services.Abstractions;
using YoutubeExplode.Videos;

namespace VideoVacuum.BRL.Services.Implementations
{
	public class VideoDownloader : IVideoDownloader
	{
		public async Task<Video> Download(string address)
		{
			throw new NotImplementedException();
		}
	}
}
