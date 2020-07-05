using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace Codenation.Challenge.Services
{
    public class UserProfileService : IProfileService
    {
        public UserProfileService(CodenationContext dbContext)
        {
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var request = context.ValidatedRequest as ValidatedTokenRequest;
            if (request != null)
            {
            }

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }

        public static Claim[] GetUserClaims(User user)
        {
            return new []
            {
                new Claim(ClaimTypes.Name, ""),
                new Claim(ClaimTypes.Email, ""),
                new Claim(ClaimTypes.Role, "")
            };
        }

    }
}