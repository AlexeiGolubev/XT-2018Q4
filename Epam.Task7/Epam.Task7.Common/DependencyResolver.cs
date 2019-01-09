using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.BLL;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL;
using Epam.Task7.DAL.Interface;

namespace Epam.Task7.Common
{
    public class DependencyResolver
    {
        private static ICacheLogic cacheLogic;
        private static IUserLogic userLogic;
        private static IUserDao userDao;

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao, CacheLogic));

        public static IUserDao UserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoDataKey"];

                if (userDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "file":
                            {
                                userDao = new UserDao();
                                break;
                            }

                        default:
                            throw new Exception("Invalid app data source configuration");
                    }
                }

                return userDao;
            }
        }
    }
}
