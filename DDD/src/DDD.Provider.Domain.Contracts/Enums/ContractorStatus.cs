﻿using System;
using DDD.Common;

//TODO: NSB update rename namespaces
namespace DDD.Provider.Domain.Contracts.Enums
{
    public class ContractorStatus : Enumeration<ContractorStatus,string>
    {
        public static readonly ContractorStatus Open = new ContractorStatus("O", "Open");

        public static readonly ContractorStatus Closed = new ContractorStatus("C", "Closed");

        private ContractorStatus(string value, string displayName) : base(value, displayName) { }

        public static implicit operator string(ContractorStatus status)
        {
            return status.Value;
        }

        public static implicit operator ContractorStatus(string code)
        {
            if (code == ContractorStatus.Open.Value)
                return ContractorStatus.Open;
            else if (code == ContractorStatus.Closed.Value)
                return ContractorStatus.Closed;
            else
                throw new InvalidCastException( $"{code} is not a valid value for ContractroStatus enumeration");
        }
    }
}
