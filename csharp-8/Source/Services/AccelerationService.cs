using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext CodenationContext;
        public AccelerationService(CodenationContext context)
        {
            CodenationContext = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            List<int> accelerationIds = CodenationContext.Candidates.Where(c => c.CompanyId == companyId).Select(c => c.AccelerationId).ToList();
            return CodenationContext.Accelerations.Where(a => accelerationIds.Contains(a.Id)).ToList();
        }

        public Acceleration FindById(int id)
        {
            return CodenationContext.Accelerations.Find(id);
        }

        public Acceleration Save(Acceleration acceleration)
        {
            if (acceleration.Id == 0)
                CodenationContext.Accelerations.Add(acceleration);
            else
                CodenationContext.Accelerations.Update(acceleration);
            return acceleration;
        }
    }
}
