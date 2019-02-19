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
    public class AwardLogic : IAwardLogic
    {
        private const string AllAwardsCacheKey = "GetAllAwards";
        private readonly IAwardDao awardDao;
        private readonly ICacheLogic cacheLogic;

        public AwardLogic(IAwardDao awardsDao, ICacheLogic cacheLogic)
        {
            this.awardDao = awardsDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(Award award)
        {
            try
            {
                if (award == null)
                {
                    throw new NullReferenceException("Award is null");
                }

                this.awardDao.Add(award);
                this.cacheLogic.Delete(AllAwardsCacheKey);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            this.awardDao.Delete(id);
            this.cacheLogic.Delete(AllAwardsCacheKey);
        }

        public void Update(Award award)
        {
            this.awardDao.Update(award);
            this.cacheLogic.Delete(AllAwardsCacheKey);
        }

        public Award GetById(int id)
        {
            return this.awardDao.GetById(id);
        }

        public IEnumerable<Award> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<Award>>(AllAwardsCacheKey);

            if (cacheResult == null)
            {
                var result = this.awardDao.GetAll();
                this.cacheLogic.Add(AllAwardsCacheKey, result);
                return result;
            }

            return cacheResult;
        }

        public void AddImage(int id, byte[] image)
        {
            this.cacheLogic.Delete(AllAwardsCacheKey);
            this.awardDao.AddImage(id, image);
        }

        public void RemoveImage(int id)
        {
            this.cacheLogic.Delete(AllAwardsCacheKey);
            this.awardDao.RemoveImage(id);
        }
    }
}
