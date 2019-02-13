using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL.Interface
{
    public interface IAwardDao
    {
        void Add(Award award);

        void Delete(int id);

        void Update(Award award);

        Award GetById(int id);

        IEnumerable<Award> GetAll();
    }
}
