namespace DemoApplication.Core.Services
{
    using Interfaces.Data;
    using Model;

    public class LoggingService : BaseService<Log>
    {
        private IRepository<Log> _repository;

        public LoggingService(IUnitOfWork unitOfWork, IRepository<Log> repository) : base(unitOfWork)
        {
            this.Repository = _repository = repository;
        }
    }
}
