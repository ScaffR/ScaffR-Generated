using System;

namespace DemoApplication.Infrastructure.Logging
{
    using System.Collections.Specialized;
    using System.Web.Management;

    public class EmailLogProvider : WebEventProvider
    {
        private string _to;
        private string _from;
        private string _subjectPrefix;

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);

            _to = config.GetAndRemove<string>("to", true);
            _from = config.GetAndRemove<string>("from", true);
            _subjectPrefix = config.GetAndRemove<string>("subjectPrefix", true);
        }

        public override void ProcessEvent(WebBaseEvent raisedEvent)
        {
            throw new NotImplementedException();
        }

        public override void Shutdown()
        {
            throw new NotImplementedException();
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }
    }


}
