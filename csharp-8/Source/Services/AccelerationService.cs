using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        public AccelerationService(CodenationContext context)
        {
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Acceleration FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Acceleration Save(Acceleration acceleration)
        {
            throw new System.NotImplementedException();
        }
    }
}
