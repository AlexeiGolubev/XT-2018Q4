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
        private static IAwardLogic awardLogic;
        private static IAwardedUsersLogic awardedUsersLogic;
        private static IUserDao userDao;
        private static IAwardDao awardDao;
        private static IAwardedUsersDao awardedUsersDao;

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao, CacheLogic));

        public static IAwardLogic AwardLogic => awardLogic ?? (awardLogic = new AwardLogic(AwardDao, CacheLogic));

        public static IAwardedUsersLogic AwardedUsersLogic => awardedUsersLogic ?? (awardedUsersLogic = new AwardedUsersLogic(AwardedUsersDao, CacheLogic));

        public static IUserDao UserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["UsersDaoKey"];

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

        public static IAwardDao AwardDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["AwardsDaoKey"];

                if (awardDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "file":
                            {
                                awardDao = new AwardDao();
                                break;
                            }

                        default:
                            throw new Exception("Invalid app data source configuration");
                    }
                }

                return awardDao;
            }
        }

        public static IAwardedUsersDao AwardedUsersDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["AwardedUsersDaoKey"];

                if (awardedUsersDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "file":
                            {
                                awardedUsersDao = new AwardedUsersDao();
                                break;
                            }

                        default:
                            throw new Exception("Invalid app data source configuration");
                    }
                }

                return awardedUsersDao;
            }
        }
    }
}
