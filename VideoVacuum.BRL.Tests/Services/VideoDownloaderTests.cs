using System.Threading.Tasks;
using VideoVacuum.BRL.Services.Abstractions;
using VideoVacuum.BRL.Services.Implementations;
using Xunit;
using YoutubeExplode;

namespace VideoVacuum.BRL.Tests.Services
{
	public class VideoDownloaderTests
	{
		private IVideoDownloader _sut;
		private YoutubeClient _yt;
		public VideoDownloaderTests()
		{
			_yt = new YoutubeClient();
			_sut = new VideoDownloader(_yt) ;
		}

		[Fact]
		public async Task CanDownloadVideo()
		{
			// Arrange:

			// Act:
			var result = await _sut.DownloadMetadata("https://www.youtube.com/watch?v=SoXFpP3-9gA");

			// Assert:
			Assert.NotNull(result);
		}
	}
}
