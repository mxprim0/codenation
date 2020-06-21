using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext CodenationContext;
        public ChallengeService(CodenationContext context)
        {
            CodenationContext = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            List<int> accelerationIds = CodenationContext.Candidates.Where(c => (c.AccelerationId == accelerationId) && (c.UserId == userId)).Select(a => a.AccelerationId).ToList();
            List<Acceleration> accelerations = CodenationContext.Accelerations.Where(a => accelerationIds.Contains(a.Id)).ToList();
            List<int> challengesIds = accelerations.Select(a => a.ChallengeId).ToList();
            return CodenationContext.Challenges.Where(c => challengesIds.Contains(c.Id)).ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id == 0)
                CodenationContext.Challenges.Add(challenge);
            else
                CodenationContext.Challenges.Update(challenge);
            CodenationContext.SaveChanges();
            return challenge;
        }
    }
}