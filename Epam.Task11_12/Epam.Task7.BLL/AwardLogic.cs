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
        private readonly IAwardDao awardsDao;
        private readonly ICacheLogic cacheLogic;

        public AwardLogic(IAwardDao awardsDao, ICacheLogic cacheLogic)
        {
            this.awardsDao = awardsDao;
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

                this.awardsDao.Add(award);
                this.cacheLogic.Delete(AllAwardsCacheKey);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            this.awardsDao.Delete(id);
            this.cacheLogic.Delete(AllAwardsCacheKey);
        }

        public void Update(Award award)
        {
            this.awardsDao.Update(award);
            this.cacheLogic.Delete(AllAwardsCacheKey);
        }

        public Award GetById(int id)
        {
            return this.awardsDao.GetById(id);
        }

        public IEnumerable<Award> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<Award>>(AllAwardsCacheKey);

            if (cacheResult == null)
            {
                var result = this.awardsDao.GetAll();
                this.cacheLogic.Add(AllAwardsCacheKey, result);
                return result;
            }

            return cacheResult;
        }
    }
}
