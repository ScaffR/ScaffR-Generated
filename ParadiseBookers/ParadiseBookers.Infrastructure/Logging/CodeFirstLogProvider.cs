using System.Web.Management;
using System.Web.Mvc;
using ParadiseBookers.Core.Common.Membership;
using ParadiseBookers.Core.Interfaces.Service;
using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Infrastructure.Logging
{
    public class CodeFirstLogProvider : WebEventProvider
    {
        public override void ProcessEvent(WebBaseEvent raisedEvent)
        {
            var repo = DependencyResolver.Current.GetService<IService<Log>>();

            var applicationInformation = WebBaseEvent.ApplicationInformation;

            var log = new Log
                {
                    EventCode = raisedEvent.EventCode,
                    EventType = raisedEvent.GetType().ToString(),
                    EventSequence = raisedEvent.EventSequence,
                    EventOccurrence = raisedEvent.EventOccurrence,
                    Message = raisedEvent.Message,
                    EventDetailCode = raisedEvent.EventDetailCode,
                    ApplicationPath = applicationInformation.ApplicationPath,
                    ApplicationVirtualPath = applicationInformation.ApplicationVirtualPath,
                    MachineName = applicationInformation.MachineName
                };

            if (raisedEvent is IUserInfoEvent)
            {
                log.Username = (raisedEvent as IUserInfoEvent).Username;
                log.Tenant = (raisedEvent as IUserInfoEvent).Tenant;
            }

            repo.SaveOrUpdate(log);                        
        }

        public override void Shutdown()
        {
            
        }

        public override void Flush()
        {
            
        }
    }
}
