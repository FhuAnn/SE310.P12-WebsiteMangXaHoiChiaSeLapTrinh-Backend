using Microsoft.AspNetCore.Identity;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.CustomIdentityValidator
{
    public class CustomUserValidator : UserValidator<IdentityUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user)
        {
            var result = await base.ValidateAsync(manager, user);

            var errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (!string.IsNullOrWhiteSpace(user.UserName) && user.UserName.Any(c => char.IsWhiteSpace(c)))
            {
                errors.RemoveAll(e => e.Code == "InvalidUserName");
            }

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }

}
