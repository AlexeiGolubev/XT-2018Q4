using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Entities
{
    public class AwardedUser
    {
        private int idUser;
        private int idAward;

        public AwardedUser()
        {
        }

        public AwardedUser(int idUser, int idAward)
        {
            this.idUser = idUser;
            this.idAward = idAward;
        }

        public int IdAward { get => this.idAward; set => this.idAward = value; }

        public int IdUser { get => this.idUser; set => this.idUser = value; }

        public override bool Equals(object obj)
        {
            return obj is AwardedUser user &&
                   this.idUser == user.idUser &&
                   this.idAward == user.idAward;
        }

        public override int GetHashCode()
        {
            var hashCode = 549194664;
            hashCode = (hashCode * -1521134295) + this.idUser.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.idAward.GetHashCode();
            return hashCode;
        }
    }
}
