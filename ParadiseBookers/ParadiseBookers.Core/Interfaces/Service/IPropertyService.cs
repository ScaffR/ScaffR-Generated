using System.Linq;
using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Core.Interfaces.Service
{
    public interface IPropertyService
    {
        void Dispose();
        void SaveChanges();
        IQueryable<Property> GetAll();
        IQueryable<Property> GetAll(string tenant);
        Property GetByID(int id);
        Property CreateProperty(Property property);
    }
}
