using DDD.Domain.Common;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Provider.DataModel;

namespace DDD.Provider.Domain.Entities
{
    public class Contractor : Entity, IAggregateRoot
    {
        public Contractor(string einNumber, string contractorName, string doingBusinessAs, ContractorStatus status, ContractorType type, DateTimeRange contractDuration, PhoneNumber primaryPhoneNumber, Contact contactDetails, Address address, string email)
            : this(GuidHelper.NewSequentialGuid(), einNumber, contractorName, doingBusinessAs, status, type, contractDuration, primaryPhoneNumber, contactDetails, address, email)
        {
        }

        public Contractor(Guid id, string einNumber, string contractorName, string doingBusinessAs, ContractorStatus status, ContractorType type, DateTimeRange contractDuration, PhoneNumber primaryPhoneNumber, Contact contactDetails, Address address, string email) : base(id)
        {
            //TODO: Implement guard conditions
            Id = id;
            EinNumber = einNumber;
            ContractorName = contractorName;
            DoingBusinessAs = doingBusinessAs;
            Status = status;
            ContractorType = type;
            ContractDuration = contractDuration;
            PhoneNumber = primaryPhoneNumber;
            Contact = contactDetails;
            Address = address;
            Email = email;
            InitializeState();
        }

        internal Contractor(ContractorState contDbState) : base(contDbState.Id)
        {
            DbState = contDbState;

            Contact = new Contact(new Name(contDbState.ContactFirstName, contDbState.ContactLastName), contDbState.ContactPhoneNumber, contDbState.ContactAlternatePhoneNumber, contDbState.ContactEmail);
            Address = new Address(contDbState.AddressLine1, contDbState.AddressLine2, contDbState.City, contDbState.StateCode, contDbState.ZipCode);
            EinNumber = contDbState.EinNumber;
            ContractorName = contDbState.ContractorName;
            DoingBusinessAs =  contDbState.DoingBusinessAs; ContractorType =  contDbState.Type;
            ContractDuration = new DateTimeRange(contDbState.ContractStartDate, contDbState.ContractEndDate);
            PhoneNumber =   contDbState.PhoneNumber;
            Email = contDbState.Email;
            ContractorAlternatePhoneNumber = contDbState.AlternatePhoneNumber;
            Status = contDbState.Status;
            ContractorSuffixCode = contDbState.EinNumber.Substring(9, 2);
        }

        private void InitializeState()
        {
            DbState = new ContractorState
            {
                Id = this.Id,
                EinNumber = this.EinNumber,
                ContractorName = ContractorName,
                DoingBusinessAs =  DoingBusinessAs,
                Status =  Status.Value,
                Type = ContractorType.Value,
                ContractStartDate =  ContractDuration.Start,
                ContractEndDate = ContractDuration.End,
                PhoneNumber = PhoneNumber,
                Email = Email,
                ContactFirstName = Contact.Name.FirstName,
                ContactLastName = Contact.Name.LastName,
                ContactPhoneNumber = Contact.PhoneNumber,
                ContactEmail = Contact.Email,
                ContactAlternatePhoneNumber = Contact.AlternatePhoneNumber,
                AlternatePhoneNumber = ContractorAlternatePhoneNumber,
                AddressLine1 = Address.AddressLine1,
                AddressLine2 = Address.AddressLine2,
                City = Address.City,
                StateCode = Address.State,
                ZipCode = Address.ZipCode
                //ZipExntension = Address.
            };
        }

        internal ContractorState DbState { get; private set; }

        public string EinNumber { get; private set; }
        public DateTimeRange ContractDuration { get; private set; }
        public ContractorStatus Status { get; private set; }
        public string ContractorName { get; private set; }
        public string DoingBusinessAs { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public ContractorType ContractorType { get; private set; }
        public string ContractorSuffixCode { get; private set; }
        public PhoneNumber ContractorAlternatePhoneNumber { get; private set; }
        //public string ContactAlternatePhoneNumber { get; private set; }
        public string Email { get; private set; }
        //public int AddressId { get; private set; }
        public Address Address { get; private set; }
        public Contact Contact { get; private set; }

    }
}
