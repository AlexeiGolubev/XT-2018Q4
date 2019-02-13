using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.Task7.BLL.Interface;
using Epam.Task7.Common;
using Epam.Task7.Entities;

namespace Epam.Task11_12.WebPagesPL.CS
{
    public class BLLProvider
    {
        public static IUserLogic userLogic = DependencyResolver.UserLogic;

        public static IAwardLogic awardLogic = DependencyResolver.AwardLogic;

        public static IAwardedUsersLogic awardedUsersLogic = DependencyResolver.AwardedUsersLogic;

        public static IAccountLogic accountLogic = DependencyResolver.AccountLogic;
    }
}