using Microsoft.AspNetCore.Identity;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface ITokenService
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
