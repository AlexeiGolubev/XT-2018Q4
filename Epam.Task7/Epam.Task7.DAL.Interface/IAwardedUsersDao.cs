using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL.Interface
{
    public interface IAwardedUsersDao
    {
        void Add(int user, int award);

        IEnumerable<AwardedUser> GetByUserId(int id);

        IEnumerable<AwardedUser> GetByAwardId(int id);

        IEnumerable<AwardedUser> GetAll();
    }
}
