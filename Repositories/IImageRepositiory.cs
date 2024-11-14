using NZWalk.API.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace NZWalk.API.Repositories
{
    public interface IImageRepositiory
    {
        Task<Image>Upload(Image image);
    }
}
