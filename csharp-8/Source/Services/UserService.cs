using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        public UserService(CodenationContext context)
        {
        }

        public IList<User> FindByAccelerationName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            throw new System.NotImplementedException();
        }

        public User FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User Save(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
