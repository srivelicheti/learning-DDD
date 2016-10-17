using System;
using DDD.Domain.Common;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.DataModel;
using DDD.Provider.Domain.Enums;
using DDD.Provider.Domain.Events;
using DDD.Provider.Messages.Events;
using NServiceBus;
using VO = DDD.Domain.Common.ValueObjects;

namespace DDD.Provider.Domain.Entities
{
    public class Contractor : Entity, IAggregateRoot
    {
        public Contractor(string einNumber, string contractorName, string doingBusinessAs, ContractorStatus status, ContractorType type, DateTimeRange contractDuration, 
                          PhoneNumber primaryPhoneNumber, Contact contactDetails, VO.Address address, string email)
            : this(GuidHelper.NewSequentialGuid(), einNumber, contractorName, doingBusinessAs, status, type, contractDuration, primaryPhoneNumber, contactDetails, address, email)
        {
        }

        public Contractor(Guid id, string einNumber, string contractorName, string doingBusinessAs, ContractorStatus status, ContractorType type, DateTimeRange contractDuration,
                          PhoneNumber primaryPhoneNumber, Contact contactDetails,VO.Address address, string email) : base(id)
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

        internal Contractor(ContractorState contDbState/*, IBus bus*/) : base(contDbState.Id/*, bus*/)
        {
            DbState = contDbState;

            Contact = new Contact(new Name(contDbState.ContactFirstName, contDbState.ContactLastName), contDbState.ContactPhoneNumber, contDbState.ContactAlternatePhoneNumber, contDbState.ContactEmail);
            Address = new VO.Address(contDbState.AddressLine1, contDbState.AddressLine2, contDbState.City, contDbState.StateCode, contDbState.ZipCode);
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
                Id = Id,
                EinNumber = EinNumber,
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
                StateCode = Address.StateCode,
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
        public VO.Address Address { get; private set; }
        public Contact Contact { get; private set; }

        public void UpdateName(string name)
        {
            if(string.Compare(ContractorName,name,StringComparison.OrdinalIgnoreCase) == 0)
                return;

            //TODO: NSB Update
            //Bus.Publish(new ContractorNameChanged(EinNumber,ContractorName,name));
            ContractorName = name;
            DbState.ContractorName = name;
        }

        public void UpdateDointBusinessAsName(string dba)
        {
            if (string.Compare(DoingBusinessAs, dba, StringComparison.OrdinalIgnoreCase) == 0)
                return;
            //TODO: NSB Update
            //Bus.Publish(new ContractorBusinessNameChanged(EinNumber, DoingBusinessAs, dba));
            DoingBusinessAs = dba;
            DbState.DoingBusinessAs = dba;
        }

        public void UpdateAddress(string addressLine1, string addressLine2, string city,string stateCode,string zipCode)
        {
            var newAddress = new VO.Address(addressLine1,addressLine2,city,stateCode,zipCode);
            if (Address != newAddress)
            {
                //TODO: NSB Update
                //Bus.Publish(new ContractorAddressChanged(EinNumber,Address,newAddress));
                Address = newAddress;
                DbState.AddressLine1 = addressLine1;
                DbState.AddressLine2 = addressLine2;
                DbState.City = city;
                DbState.StateCode = stateCode;
                DbState.ZipCode = zipCode;
            }
        }

        public void UpdateContactDetails(string firstName, string lastName, string email, string phoneNumber,
            string alternatePhone)
        {
             var newContact = new Contact(new Name(firstName,lastName),phoneNumber,alternatePhone,email);
            if (newContact != Contact)
            {
                //TODO: Publish contact updated event if required
                Contact = newContact;
                DbState.ContactFirstName = firstName;
                DbState.ContactLastName = lastName;
                DbState.ContactPhoneNumber = phoneNumber;
                DbState.ContactAlternatePhoneNumber = alternatePhone;
                DbState.Email = email;
            }
        }

        public void UpdatePhoneDetails(string phone, string alternatePhone)
        {
            PhoneNumber = phone;
            ContractorAlternatePhoneNumber = alternatePhone;

            DbState.PhoneNumber = phone;
            DbState.AlternatePhoneNumber = alternatePhone;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
            DbState.Email = email;
        }

        public void RenewContract(DateTime startDate, DateTime? endDate)
        {
            var newContractDuration = new DateTimeRange(startDate,endDate);
            if (ContractDuration != newContractDuration)
            {
                //TODO: NSB Update
                //Bus.Publish(new ContractorContractRenewed(EinNumber, ContractDuration, newContractDuration));
                ContractDuration = newContractDuration;
                DbState.ContractStartDate = startDate;
                DbState.ContractEndDate = endDate;
            }
        }
    }
}
