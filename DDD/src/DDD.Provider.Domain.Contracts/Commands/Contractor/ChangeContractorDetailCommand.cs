﻿using DDD.Domain.Common.Command;
using DDD.Provider.Domain.Contracts.Models;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Contracts.Commands.Contractor
{
    public class ChangeContractorDetailCommand : BaseCommand, ICommand
    {
        public ChangeContractorDetailCommand(ChangeContractorDetailModel contractorDetail) :base(GuidHelper.NewSequentialGuid(),"TODO")
        {
            ContractorDetail = contractorDetail;
        }

        public ChangeContractorDetailModel ContractorDetail { get; private set; }
    }
}
