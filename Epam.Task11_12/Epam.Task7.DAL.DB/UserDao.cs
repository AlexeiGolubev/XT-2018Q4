using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL.DB
{
    public class UserDao : IUserDao
    {
        private readonly string _connectionString;

        #region Constructor
        public UserDao(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void AddImage(int id, byte[] image)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveImage(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
