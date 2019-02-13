using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL
{
    public class AccountDao : IAccountDao
    {
        private readonly Dictionary<int, Account> repoAccounts = new Dictionary<int, Account>();

        private const string AdminRole = "admin";

        private const string UserRole = "user";

        public AccountDao()
        {
            this.repoAccounts = FileHelper.ReadAccountsData();
            if (this.repoAccounts.Count == 0)
            {
                this.repoAccounts.Add(0, new Account(0, "admin", HashStringWithSha512("admin"), "admin@email.com", AdminRole));
                FileHelper.WriteAccountsData(this.repoAccounts);
            }
        }

        public Account GetAccount(string login)
        {
            return this.repoAccounts.FirstOrDefault(l => l.Value.Login == login).Value;
        }

        public IEnumerable<Account> GetAll()
        {
            return this.repoAccounts.Values;
        }

        public string[] GetRoles(string login)
        {
            var account = GetAccount(login);
            return account != null
                ? new[] { account.Role }
                : null;
        }

        public bool GiveAdminRights(string login)
        {
            throw new NotImplementedException();
        }

        public bool Login(string login, string password)
        {
            password = HashStringWithSha512(password);
            foreach (var item in this.repoAccounts)
            {
                if (item.Value.Login == login && item.Value.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Register(string email, string login, string password)
        {
            if (login.Length < 1 && email.Length < 1 && password.Length < 1)
            {
                return false;
            }

            foreach (var item in this.repoAccounts)
            {
                if (item.Value.Login == login || item.Value.Email == email)
                {
                    return false;
                }
            }

            var lastId = this.repoAccounts.Any()
                ? this.repoAccounts.Keys.Max()
                : 0;

            Account account = new Account(++lastId, login, HashStringWithSha512(password), email, UserRole);
            this.repoAccounts.Add(account.Id, account);
            FileHelper.WriteAccountsData(this.repoAccounts);

            return true;
        }

        public bool TakeAdminRights(string login)
        {
            throw new NotImplementedException();
        }

        private static string HashStringWithSha512(string inputString)
        {
            var crypt = new SHA512Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(inputString));

            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("X2"));
            }

            return hash.ToString();
        }
    }
}
