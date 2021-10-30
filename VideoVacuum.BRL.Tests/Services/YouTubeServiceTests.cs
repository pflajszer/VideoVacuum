using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVacuum.BRL.AutomapperProfiles;
using VideoVacuum.BRL.Services.Abstractions;
using VideoVacuum.BRL.Services.Implementation;
using VideoVacuum.BRL.Services.Implementations;
using Xunit;
using YoutubeExplode;

namespace VideoVacuum.BRL.Tests.Services
{
    public class YouTubeServiceTests
    {
        private readonly IYouTubeService _sut;
        private readonly IVideoDownloader _downloader;
        private readonly IVideoConverter _converter;
        private readonly IMapper _mapper;
        private readonly YoutubeClient _youtube;

        public YouTubeServiceTests()
		{
            var vidProfile = new VideoProfile();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(vidProfile);
            });

            _mapper = new Mapper(configuration);
            _youtube = new YoutubeClient();
            _downloader = new VideoDownloader(_youtube);
            _converter = new VideoConverter(_mapper);
            _sut = new YouTubeService(_downloader, _converter);
		}

        [Fact]
        public async Task CanGetVideoMetadata()
		{
            // Arrange:

            // Act:
            var result = await _sut.GetVideoMetadata("https://www.youtube.com/watch?v=SoXFpP3-9gA");

            // Assert:
            Assert.NotNull(result);
		}

    }
}
