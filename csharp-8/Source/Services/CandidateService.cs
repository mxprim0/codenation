using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CodenationContext CodenationContext;
        public CandidateService(CodenationContext context)
        {
            CodenationContext = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return CodenationContext.Candidates.Where(c => c.AccelerationId == accelerationId).ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return CodenationContext.Candidates.Where(c => c.CompanyId == companyId).ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return CodenationContext.Candidates.Find(userId, accelerationId, companyId);
        }

        public Candidate Save(Candidate candidate)
        {
            if ((candidate.UserId == 0) && (candidate.AccelerationId == 0) && (candidate.CompanyId == 0))
                CodenationContext.Candidates.Add(candidate);
            else
                CodenationContext.Candidates.Update(candidate);
            return candidate;
        }
    }
}
