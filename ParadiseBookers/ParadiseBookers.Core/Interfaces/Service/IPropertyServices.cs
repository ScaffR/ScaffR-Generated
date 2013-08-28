using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Core.Interfaces.Service
{
    public interface IPropertyServices
    {
        IQueryable<Property> GetAll();
    }
}
