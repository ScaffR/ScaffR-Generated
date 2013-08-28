using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Core.Interfaces.Service
{
    public interface IBeachService
    {
        void Dispose();
        void SaveChanges();
        IQueryable<Beach> GetAll();
        IQueryable<Beach> GetAll(string tenant);
        Beach GetByID(int id);
        Beach CreateBeach(Beach beach);
    }
}
