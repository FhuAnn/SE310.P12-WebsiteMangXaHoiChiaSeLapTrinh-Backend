using NZWalk.API.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System;

namespace NZWalk.API.Repositories
{
    public interface IImageRepositiory
    {
        Task<Image> Upload(Image images);
    }
}
