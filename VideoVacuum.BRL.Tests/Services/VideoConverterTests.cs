using VideoVacuum.BRL.Services.Abstractions;
using VideoVacuum.BRL.Services.Implementations;
using Xunit;

namespace VideoVacuum.BRL.Tests.Services
{
	public class VideoConverterTests
	{
		private IVideoConverter _sut;
		public VideoConverterTests()
		{
			_sut = new VideoConverter();
		}

		[Fact]
		public void CanConvertVideo()
		{
			// Arrange:

			// Act:

			// Assert:

		}
	}
}
