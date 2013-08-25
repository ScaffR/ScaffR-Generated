using ParadiseBookers.Core.Interfaces.Data;
using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Core.Services
{
    public class LoggingService : BaseService<Log>
    {
        private IRepository<Log> _repository;

        public LoggingService(IUnitOfWork unitOfWork, IRepository<Log> repository) : base(unitOfWork)
        {
            this.Repository = _repository = repository;
        }
    }
}
