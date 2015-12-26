using DDD.Provider.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Repositories
{
    public class ContractorRepository
    {
        public void AddContractor(DDD.Provider.Domain.Entities.Contractor contractor)
        {
            using (var ctx = new POC_DDDContext())
            {
                ctx.Add(new Contractor {
                    ID=contractor.ID,
                     ContractorName = contractor.ContractorName,
                      DoingBusinessAs = contractor.DoingBusinessAsText,
                       PhoneNumber = contractor.PhoneNumber,
                       AlternatePhoneNumber = contractor.ContractorAlternatePhoneNumber,
                        Email = contractor.ContractorAlternatePhoneNumber
                         
                });
            }
        }
    }
}
