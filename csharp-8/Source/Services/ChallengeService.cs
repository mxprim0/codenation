using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        public ChallengeService(CodenationContext context)
        {
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            throw new System.NotImplementedException();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            throw new System.NotImplementedException();
        }
    }
}