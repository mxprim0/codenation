using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext CodenationContext;
        public UserService(CodenationContext context)
        {
            CodenationContext = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return CodenationContext.Accelerations.Where(a => a.Name == name).SelectMany(a => a.Candidates).Select(c => c.User).Distinct().ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            List<int> userIds = CodenationContext.Candidates.Where(c => c.CompanyId == companyId).Select(c2 => c2.UserId).ToList();
            return CodenationContext.Users.Where(u => userIds.Contains(u.Id)).ToList();
        }

        public User FindById(int id)
        {
            return CodenationContext.Users.Find(id);
        }

        public User Save(User user)
        {
            if (user.Id == 0)
                CodenationContext.Users.Add(user);
            else
                CodenationContext.Users.Update(user);
            CodenationContext.SaveChanges();

            return user;
        }
    }
}
