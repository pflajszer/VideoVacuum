using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVacuum.BRL.ViewModels;

namespace VideoVacuum.BRL.Services.Abstractions
{
    public interface IVideoEditor
    {
        Task<VideoViewModel> SetVideoMetadata(VideoViewModel model);
    }
}
