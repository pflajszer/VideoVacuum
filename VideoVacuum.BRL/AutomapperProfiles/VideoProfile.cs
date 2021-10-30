using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVacuum.BRL.ViewModels;
using YoutubeExplode.Videos;

namespace VideoVacuum.BRL.AutomapperProfiles
{
    public class VideoProfile : Profile
    {
		public VideoProfile()
		{
			CreateMap<Video, VideoViewModel>()
				.ForMember(dest => dest.AverageRating, x => x.MapFrom(src => src.Engagement.AverageRating))
				.ForMember(dest => dest.DislikeCount, x => x.MapFrom(src => src.Engagement.DislikeCount))
				.ForMember(dest => dest.LikeCount, x => x.MapFrom(src => src.Engagement.LikeCount))
				.ForMember(dest => dest.ViewCount, x => x.MapFrom(src => src.Engagement.ViewCount))
				//.ForMember(dest => dest.ChannelId, x => x.MapFrom(src => src.ChannelId.Value))
				.ForMember(dest => dest.VideoId, x => x.MapFrom(src => src.Id.Value))
				.ForMember(dest => dest.Keywords, x => x.MapFrom(src => src.Keywords))
				.ForMember(dest => dest.ThumbnailUrl, x => x.MapFrom(src => src.Thumbnails.FirstOrDefault()))
				.ReverseMap();
		}
    }
}
