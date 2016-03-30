﻿using DDD.Provider.Messages.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.EmailService.EventHandlers
{
    public class ContractorAddedEventHandler : IHandleMessages<ContractorAddedEvent>
    {
        public void Handle(ContractorAddedEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Added new Contractor " + message.ContractorEin);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}