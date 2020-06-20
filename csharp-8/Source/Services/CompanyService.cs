using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        public CompanyService(CodenationContext context)
        {
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            throw new System.NotImplementedException();
        }

        public Company FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Company> FindByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Company Save(Company company)
        {
            throw new System.NotImplementedException();
        }
    }
}