using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        public CandidateService(CodenationContext context)
        {
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            throw new System.NotImplementedException();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Candidate Save(Candidate candidate)
        {
            throw new System.NotImplementedException();
        }
    }
}
