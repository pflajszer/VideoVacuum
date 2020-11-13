using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoVacuum.BRL.ViewModels
{
    public class VideoViewModel
    {
		public string VideoId { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public string Author { get; set; }
		public string ChannelId { get; set; }
		public DateTimeOffset UploadDate { get; set; }
		public string Description { get; set; }
		public TimeSpan Duration { get; set; }
		public string ThumbnailUrl { get; set; }
		public IEnumerable<string> Keywords { get; set; }

		//engagement:
		public long ViewCount { get; set; }
		public long LikeCount { get; set; }
		public long DislikeCount { get; set; }
		public long AverageRating { get; set; }

		public string OriginalFileName { get; set; }
		public string MP3FileName { get; set; }
	}
}