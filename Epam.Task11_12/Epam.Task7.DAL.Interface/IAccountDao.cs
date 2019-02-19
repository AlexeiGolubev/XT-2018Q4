using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL.Interface
{
    public interface IAccountDao
    {
        Account GetAccount(string login);

        IEnumerable<Account> GetAll();

        string[] GetRoles(string login);

        bool ChangeRole(string login, string role);

        bool Login(string login, string password);

        bool Register(string email, string login, string password);
    }
}
