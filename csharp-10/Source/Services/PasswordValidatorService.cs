using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Services
{
    public class PasswordValidatorService : IResourceOwnerPasswordValidator
    {
        private readonly CodenationContext _dbContext;
        public PasswordValidatorService(CodenationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //_dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
            //User userFind = _dbContext.Users.FirstOrDefault(user => user.Email == context.UserName && user.Password == context.Password);

            User userFind = _dbContext.Users.Where(x => x.Email == context.UserName).FirstOrDefault();

            if (userFind != null && userFind.Password == context.Password)
                //if (userFind != null)
                context.Result = new GrantValidationResult(subject: userFind.Id.ToString(), authenticationMethod: "custom", claims: UserProfileService.GetUserClaims(userFind));
            else
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
            return Task.CompletedTask;
        }

    }
}