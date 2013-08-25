using ParadiseBookers.Core.Interfaces.Data;
using ParadiseBookers.Core.Model;
using ParadiseBookers.Infrastructure.Data;

namespace ParadiseBookers.Infrastructure.Logging
{
    public class LoggingRepository : BaseRepository<Log>
    {
        public LoggingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
