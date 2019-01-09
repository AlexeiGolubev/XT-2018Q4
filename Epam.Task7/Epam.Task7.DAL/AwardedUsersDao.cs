using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL
{
    public class AwardedUsersDao : IAwardedUsersDao
    {
        private readonly List<AwardedUser> awardedUsers = new List<AwardedUser>();

        public AwardedUsersDao()
        {
            this.awardedUsers = FileHelper.ReadAwardedUsersData();
        }

        public void Add(int userId, int awardId)
        {
            AwardedUser awardedUser = new AwardedUser(userId, awardId);
            if (this.awardedUsers.Contains(awardedUser))
            {
                 throw new ArgumentException("User already has this award");
            }

            this.awardedUsers.Add(awardedUser);
            FileHelper.WriteAwardedUsersData(this.awardedUsers);
        }

        public IEnumerable<AwardedUser> GetAll()
        {
            return this.awardedUsers;
        }

        public IEnumerable<AwardedUser> GetByAwardId(int id)
        {
            return this.awardedUsers.Where(x => x.IdAward == id);
        }

        public IEnumerable<AwardedUser> GetByUserId(int id)
        {
            return this.awardedUsers.Where(x => x.IdUser == id);
        }
    }
}
