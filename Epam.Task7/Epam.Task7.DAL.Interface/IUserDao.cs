using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL.Interface
{
    public interface IUserDao
    {
        void Add(User user);

        void Delete(int id);

        void Update(User user);

        User GetById(int id);

        IEnumerable<User> GetAll();
    }
}
