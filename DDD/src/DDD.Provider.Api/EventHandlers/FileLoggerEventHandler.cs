﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Event;
using log4net;
using Newtonsoft.Json;
using NServiceBus;

namespace DDD.Web.Api.EventHandlers
{
    public class FileLoggerEventHandler : IHandleMessages<BaseEvent>
    {
        private static ILog Logger = LogManager.GetLogger(typeof (FileLoggerEventHandler));
        public Task Handle(BaseEvent e,IMessageHandlerContext messageContext)
        {
            var jsonString = JsonConvert.SerializeObject(e);
            Debug.Write(jsonString);
            Logger.Info(jsonString);
            return Task.FromResult(0);
            //throw new NotImplementedException();
        }
    }
}
