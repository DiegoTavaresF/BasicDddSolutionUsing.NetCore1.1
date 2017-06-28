using Infra.BaseIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infra.BaseIdentity
{
    public class AppSignInManager : SignInManager<ApplicationUser>
    {
        public AppSignInManager(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor,
                IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor,
                ILogger<SignInManager<ApplicationUser>> logger)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
        }
    }
}