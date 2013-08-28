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
    public class PropertyService : IPropertyService
    {
        private DataContext _dataContext;

        public PropertyService(DataContext dataContext)
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

        public IQueryable<Property> GetAll()
        {
            return _dataContext.Properties;
        }

        public IQueryable<Property> GetAll(string tenant)
        {
            return _dataContext.Properties;
        }

        public Property GetByID(int id)
        {
            return _dataContext.Properties.Find(id);
        }


        public Property CreateProperty(Property property)
        {
            _dataContext.Properties.Add(property);
            _dataContext.SaveChanges();
            return property;
        }
    }
}
