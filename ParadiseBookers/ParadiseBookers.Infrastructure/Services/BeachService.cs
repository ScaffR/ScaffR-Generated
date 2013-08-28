using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParadiseBookers.Core.Interfaces.Service;
using ParadiseBookers.Core.Model;
using ParadiseBookers.Infrastructure.Data;

namespace ParadiseBookers.Infrastructure.Services
{
    public class BeachService : IBeachService
    {
        private readonly DataContext _dataContext;

        public BeachService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public IQueryable<Beach> GetAll()
        {
            return _dataContext.Beaches;
        }

        public IQueryable<Beach> GetAll(string tenant)
        {
            return _dataContext.Beaches;
        }

        public Beach GetByID(int id)
        {
            return _dataContext.Beaches.Find(id);
        }

        public Beach CreateBeach(Beach beach)
        {
            _dataContext.Beaches.Add(beach);
            SaveChanges();
            return beach;
        }
    }
}
