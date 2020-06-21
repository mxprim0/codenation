using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using System.Threading.Tasks;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext CodenationContext;
        public CompanyService(CodenationContext context)
        {
            CodenationContext = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return CodenationContext.Accelerations.Where(a => a.Id == accelerationId).SelectMany(a => a.Candidates).Select(a => a.Company).Distinct().ToList();
        }

        public Company FindById(int id)
        {
            return CodenationContext.Companies.Find(id);
        }

        public IList<Company> FindByUserId(int userId)
        {
            return CodenationContext.Candidates.Where(c => c.UserId == userId).Select(c => c.Company).Distinct().ToList();
        }

        public Company Save(Company company)
        {
            if (company.Id == 0)
                CodenationContext.Companies.Add(company);
            else
                CodenationContext.Companies.Update(company);
            CodenationContext.SaveChanges();
            return company;
        }
    }
}