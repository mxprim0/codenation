using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext CodenationContext;
        public SubmissionService(CodenationContext context)
        {
            CodenationContext = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return CodenationContext.Candidates.Where(c => c.AccelerationId == accelerationId).Select(c => c.User).SelectMany(u => u.Submissions).Where(s => s.ChallengeId == challengeId).Distinct().ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return CodenationContext.Submissions.Where(s => s.ChallengeId == challengeId).Select(s => s.Score).Max();
        }

        public Submission Save(Submission submission)
        {
            if ((submission.UserId == 0) && (submission.ChallengeId == 0))
                CodenationContext.Submissions.Add(submission);
            else
                CodenationContext.Submissions.Update(submission);
            return submission;
        }
    }
}
