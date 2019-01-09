using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.Entities;

namespace Epam.Task7.BLL.Interface
{
    public interface IAwardedUsersLogic
    {
        void Add(int userId, int awardId);

        IEnumerable<Award> GetAwardsByUserId(int id, IEnumerable<Award> awards);

        IEnumerable<User> GetUsersByAwardId(int id, IEnumerable<User> users);

        IEnumerable<AwardedUser> GetAll();
    }
}
