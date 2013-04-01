namespace DemoApplication.Infrastructure.Logging
{
    using Core.Interfaces.Data;
    using Core.Model;
    using Data;

    public class LoggingRepository : BaseRepository<Log>
    {
        public LoggingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
