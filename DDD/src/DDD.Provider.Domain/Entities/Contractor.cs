﻿using DDD.Domain.Common;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Entities
{
    public class Contractor : Entity, IAggregateRoot
    {
        public Contractor(Guid id) : base(id)
        {
        }

        public Contractor(string einNumber, string contractorName, string doingBusinessAs, ContractorStatus status, ContractorType type ,DateTimeRange contractDuration, PhoneNumber primaryPhoneNumber, Contact contactDetails, Address address, string email) : base(GuidHelper.NewSequentialGuid())
        {
            //TODO: Implement guard conditions
            EinNumber = einNumber;
            ContractorName = contractorName;
            DoingBusinessAsText = doingBusinessAs;
            Status = status;
            ContractorType = type;
            ContractDuration = contractDuration;
            PhoneNumber = primaryPhoneNumber;
            Contact = contactDetails;
            Address = address;
            Email = email;
        }

        public string EinNumber { get; private set; }
        public DateTimeRange ContractDuration { get; private set; }
        public ContractorStatus Status { get; private set; }
        public string ContractorName { get; private set; }
        public string DoingBusinessAsText { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public ContractorType ContractorType { get; private set; }
        public string ContractorSuffixCode { get; private set; }
        public PhoneNumber ContractorAlternatePhoneNumber { get; private set; }
        public string ContactAlternatePhoneNumber { get; private set; }
        public string Email { get; private set; }
        public int AddressId { get; private set; }
        public Address Address { get; private set; }
        public Contact Contact { get; private set; }

    }
}
