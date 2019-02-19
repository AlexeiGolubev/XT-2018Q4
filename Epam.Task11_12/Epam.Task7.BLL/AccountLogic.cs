using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.BLL
{
    public class AccountLogic : IAccountLogic
    {
        private const string AllAccountsCacheKey = "GetAllAccounts";
        private readonly IAccountDao accountDao;
        private readonly ICacheLogic cacheLogic;

        public AccountLogic(IAccountDao accountDao, ICacheLogic cacheLogic)
        {
            this.accountDao = accountDao ?? throw new ArgumentNullException(nameof(accountDao));
            this.cacheLogic = cacheLogic ?? throw new ArgumentNullException(nameof(cacheLogic));
        }

        public Account GetAccount(string login)
        {
            return accountDao.GetAccount(login);
        }

        public IEnumerable<Account> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<Account>>(AllAccountsCacheKey);

            if (cacheResult == null)
            {
                var result = this.accountDao.GetAll();
                this.cacheLogic.Add(AllAccountsCacheKey, result);
                return result;
            }

            return cacheResult;
        }

        public string[] GetRoles(string login)
        {
            return accountDao.GetRoles(login);
        }

        public bool ChangeRole(string login, string role)
        {
            this.cacheLogic.Delete(AllAccountsCacheKey);
            return this.accountDao.ChangeRole(login, role);
        }

        public bool Login(string login, string password)
        {
            return this.accountDao.Login(login, password);
        }

        public bool Register(string email, string login, string password)
        {
            if (this.IsValidRegistration(email, login, password))
            {
                this.cacheLogic.Delete(AllAccountsCacheKey);
                return this.accountDao.Register(email, login, password);
            }

            return false;
        }

        private bool IsValidRegistration(string email, string login, string password)
        {
            return this.CheckEmailFormat(email)
                && this.CheckLoginFormat(login)
                && this.CheckPasswordFormat(password);
        }

        private bool CheckEmailFormat(string email)
        {
            string emailTemplate = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            if (this.GetAll().All(acc => acc.Email != email))
            {
                return Regex.IsMatch(email, emailTemplate, RegexOptions.IgnoreCase);
            }

            return false;
        }

        private bool CheckLoginFormat(string login)
        {
            string loginTemplate = "^[a-zA-Z]{3,30}$";

            if (this.GetAll().All(acc => acc.Login != login))
            {
                return Regex.IsMatch(login, loginTemplate, RegexOptions.IgnoreCase);
            }

            return false;
        }

        private bool CheckPasswordFormat(string password)
        {
            string passwordTemplate = "^[a-zA-Z0-9]{5,30}$";

            return Regex.IsMatch(password, passwordTemplate, RegexOptions.IgnoreCase);
        }
    }
}
