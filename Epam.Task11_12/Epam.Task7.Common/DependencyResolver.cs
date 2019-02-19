using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.BLL;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL;
using Epam.Task7.DAL.DB;
using Epam.Task7.DAL.Interface;

namespace Epam.Task7.Common
{
    public class DependencyResolver
    {
        private static string key = ConfigurationManager.AppSettings["UserAwardDaoKey"];
        private static readonly string connectonString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private static ICacheLogic cacheLogic;
        private static IUserLogic userLogic;
        private static IAwardLogic awardLogic;
        private static IAwardedUsersLogic awardedUsersLogic;
        private static IAccountLogic accountLogic;

        private static IUserDao userDao;
        private static IAwardDao awardDao;
        private static IAwardedUsersDao awardedUsersDao;
        private static IAccountDao accountDao;

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao, CacheLogic));

        public static IAwardLogic AwardLogic => awardLogic ?? (awardLogic = new AwardLogic(AwardDao, CacheLogic));

        public static IAwardedUsersLogic AwardedUsersLogic => awardedUsersLogic ?? (awardedUsersLogic = new AwardedUsersLogic(AwardedUsersDao, CacheLogic));

        public static IAccountLogic AccountLogic => accountLogic ?? (accountLogic = new AccountLogic(AccountDao, CacheLogic));

        public static IUserDao UserDao
        {
            get
            {
                if (userDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "file":
                            {
                                userDao = new DAL.UserDao();
                                break;
                            }
                        case "db":
                            {
                                userDao = new DAL.DB.UserDao(connectonString);
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
                if (awardDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "file":
                            {
                                awardDao = new AwardDao();
                                break;
                            }
                        case "db":
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
                if (awardedUsersDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "file":
                            {
                                awardedUsersDao = new AwardedUsersDao();
                                break;
                            }
                        case "db":
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

        public static IAccountDao AccountDao
        {
            get
            {
                if (accountDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "file":
                            {
                                accountDao = new AccountDao();
                                break;
                            }
                        case "db":
                            {
                                accountDao = new AccountDao();
                                break;
                            }

                        default:
                            throw new Exception("Invalid app data source configuration");
                    }
                }

                return accountDao;
            }
        }
    }
}
