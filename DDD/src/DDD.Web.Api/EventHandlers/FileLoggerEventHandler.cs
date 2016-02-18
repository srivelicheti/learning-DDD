using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Event;
using log4net;
using Newtonsoft.Json;

namespace DDD.Web.Api.EventHandlers
{
    public class FileLoggerEventHandler : IEventHandler<DomainEvent>
    {
        private static ILog Logger = LogManager.GetLogger(typeof (FileLoggerEventHandler));
        public void Handle(DomainEvent e)
        {
            var jsonString = JsonConvert.SerializeObject(e);
            Debug.Write(jsonString);
            Logger.Info(jsonString);
            //throw new NotImplementedException();
        }
    }
}
