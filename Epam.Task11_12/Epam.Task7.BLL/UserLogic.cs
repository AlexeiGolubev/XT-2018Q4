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
    public class UserLogic : IUserLogic
    {
        private const string AllUsersCacheKey = "GetAllUsers";
        private readonly IUserDao userDao;
        private readonly ICacheLogic cacheLogic;

        public UserLogic(IUserDao userDao, ICacheLogic cacheLogic)
        {
            this.userDao = userDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new NullReferenceException("User is null");
                }

                this.userDao.Add(user);
                this.cacheLogic.Delete(AllUsersCacheKey);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            this.userDao.Delete(id);
            this.cacheLogic.Delete(AllUsersCacheKey);
        }

        public void Update(User user)
        {
            this.userDao.Update(user);
            this.cacheLogic.Delete(AllUsersCacheKey);
        }

        public User GetById(int id)
        {
            return this.userDao.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<User>>(AllUsersCacheKey);

            if (cacheResult == null)
            {
                var result = this.userDao.GetAll();
                this.cacheLogic.Add(AllUsersCacheKey, result);
                return result;
            }

            return cacheResult;
        }

        public void AddImage(int id, byte[] image)
        {
            this.cacheLogic.Delete(AllUsersCacheKey);
            this.userDao.AddImage(id, image);
        }

        public void RemoveImage(int id)
        {
            this.cacheLogic.Delete(AllUsersCacheKey);
            this.userDao.RemoveImage(id);
        }
    }
}
