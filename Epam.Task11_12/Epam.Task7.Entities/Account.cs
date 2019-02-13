using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Entities
{
    public class Account
    {
        public Account(int id, string login, string password, string email, string role)
        {
            this.Id = id;
            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.Role = role;
        }

        private Account()
        {
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public override string ToString()
        {
            return $"{nameof(this.Id)}: {this.Id}, {nameof(this.Login)}: {this.Login}, {nameof(this.Email)}: {this.Email}";
        }
    }
}
