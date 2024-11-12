using Microsoft.AspNetCore.Identity;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface ITokenService
    {
        string CreateJWTToken(User user, List<string> roles);
    }
}
