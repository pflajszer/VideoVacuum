using VideoVacuum.BRL.Services.Abstractions;
using VideoVacuum.BRL.Services.Implementations;
using Xunit;

namespace VideoVacuum.BRL.Tests.Services
{
	public class VideoDownloaderTests
	{
		private IVideoDownloader _sut;
		public VideoDownloaderTests()
		{
			_sut = new VideoDownloader();
		}

		[Fact]
		public void CanDownloadVideo()
		{
			// Arrange:

			// Act:

			// Assert:

		}
	}
}
