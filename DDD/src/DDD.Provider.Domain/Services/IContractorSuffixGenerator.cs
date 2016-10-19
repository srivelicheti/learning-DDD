using DDD.Provider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Provider.Domain.Contracts.Enums;

namespace DDD.Provider.Domain.Services
{
    public interface IContractorSuffixGenerator
    {
        string GetContractorSuffixForNewContractor(string einSsn, ContractorType type);
    }

    public class ContractorSuffixGenerator : IContractorSuffixGenerator
    {
        private ContractorRepository _contractorRepo;

        public ContractorSuffixGenerator(ContractorRepository contractorRepo)
        {
            _contractorRepo = contractorRepo;
        }
        public string GetContractorSuffixForNewContractor(string einSsn, ContractorType type)
        {
            ThrowIfInvalidEinSsn(einSsn);
            if (type == ContractorType.Contracted)
            {
                return GenerateContractorSuffixForContractedContractor(einSsn);
            }
            else
                return GenerateContractorSuffixForSelfArrangedContractor(einSsn);
        }

        private string GenerateContractorSuffixForSelfArrangedContractor(string einSsn)
        {
            return "01";

        }

        private string GenerateContractorSuffixForContractedContractor(string einSsn)
        {

            var existingContractors = _contractorRepo.GetContractorEinsStartingWith(einSsn, ContractorType.Contracted);
            if (existingContractors.Count > 0)
            {
                var highestSuffix = existingContractors.Select(x => x.Substring(9, 2)).OrderByDescending(x => x).First();
                var arr = highestSuffix.ToCharArray();
                int suffixNumber = (arr[0] - 65) * 26 + (arr[1] - 65 + 1);
                int generatingNumber = suffixNumber + 1;
                char[] arrSuffix = new char[2];
                arrSuffix[0] = (char)(generatingNumber / 26 + 65);
                arrSuffix[1] = (char)(generatingNumber % 26 + 64);
                return new string(arrSuffix);
            }
            else
                return "AA";
        }

        private void ThrowIfInvalidEinSsn(string einSsn)
        {
            //TODO: Implement
        }
    }
}
