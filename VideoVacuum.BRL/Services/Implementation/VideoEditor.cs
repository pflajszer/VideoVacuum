using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVacuum.BRL.Services.Abstractions;
using VideoVacuum.BRL.ViewModels;

namespace VideoVacuum.BRL.Services.Implementation
{
	public class VideoEditor : IVideoEditor
	{

		public VideoEditor()
		{

		}
		public async Task<VideoViewModel> SetVideoMetadata(VideoViewModel model)
		{
			throw new NotImplementedException();
		}
	}
}
