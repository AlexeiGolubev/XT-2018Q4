using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.BLL
{
    public class AwardedUsersLogic : IAwardedUsersLogic
    {
        private const string AllAwardedUsersCacheKey = "GetAllAwardedUsers";
        private readonly IAwardedUsersDao awardedUsersDao;
        private readonly ICacheLogic cacheLogic;

        public AwardedUsersLogic(IAwardedUsersDao awardedUsersDao, ICacheLogic cacheLogic)
        {
            this.awardedUsersDao = awardedUsersDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(int userId, int awardId)
        {
            try
            {
                this.awardedUsersDao.Add(userId, awardId);
                this.cacheLogic.Delete(AllAwardedUsersCacheKey);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<AwardedUser> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<AwardedUser>>(AllAwardedUsersCacheKey);

            if (cacheResult == null)
            {
                var result = this.awardedUsersDao.GetAll();
                this.cacheLogic.Add(AllAwardedUsersCacheKey, result);
                return result;
            }

            return cacheResult;
        }

        public IEnumerable<User> GetUsersByAwardId(int id, IEnumerable<User> allUsers)
        {
            IEnumerable<AwardedUser> awardedUsers = this.awardedUsersDao.GetByAwardId(id);
            var users = from us in allUsers
                        join awUs in awardedUsers on us.Id equals awUs.IdUser
                        where awUs.IdAward == id
                        select us;
            return users;
        }

        public IEnumerable<Award> GetAwardsByUserId(int id, IEnumerable<Award> allAwards)
        {
            IEnumerable<AwardedUser> awardedUsers = this.awardedUsersDao.GetByUserId(id);
            var awards = from aw in allAwards
                         join awUs in awardedUsers on aw.Id equals awUs.IdAward
                         where awUs.IdUser == id
                         select aw;
            return awards;
        }

        public void Delete(int userId, int awardId)
        {
            try
            {
                this.awardedUsersDao.Delete(userId, awardId);
                this.cacheLogic.Delete(AllAwardedUsersCacheKey);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }
        }

        public void DeleteAwardToAllUsers(int awardId)
        {
            try
            {
                this.awardedUsersDao.DeleteAwardToAllUsers(awardId);
                this.cacheLogic.Delete(AllAwardedUsersCacheKey);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }
        }
    }
}
