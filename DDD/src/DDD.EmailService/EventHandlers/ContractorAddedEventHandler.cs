﻿using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Provider.Domain.Contracts.Events;

namespace DDD.EmailService.EventHandlers
{
    public class ContractorAddedEventHandler : IHandleMessages<ContractorAdded>
    {
        public Task Handle(ContractorAdded message, IMessageHandlerContext messageContext)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Added new Contractor " + message.ContractorEin);
            Console.ForegroundColor = ConsoleColor.Gray;
            return Task.FromResult(0);
        }
    }
}
