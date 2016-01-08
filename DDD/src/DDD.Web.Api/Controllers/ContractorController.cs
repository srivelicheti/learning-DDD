using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DDD.Common.DTOs.Provider;
using DDD.Domain.Common.Command;
using DDD.Provider.Domain.Commands;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Enums;
using DDD.Domain.Common.Query;
using DDD.Provider.QueryStack.Contractor.Queries;

namespace DDD.Web.Api.Controllers
{
    public class TempCont
    {
        public string name { get; set; }
        public string dba { get; set; }
    }
    [Route("api/contractor")]
    public class ContractorController : Controller
    {
        private ICommandBus _commandBus;
        private IQueryProcessor _queryProcessor;

        public ContractorController(ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ContractorDto Get(Guid id)
        {
            return _queryProcessor.Process<ContractorDto>(new FindContractorByIDQuery() { ID = id });
        }

        // GET api/values/5
        [HttpGet("Ein/{ein}")]
        public ContractorDto GetByEin(string ein)
        {
            return _queryProcessor.Process<ContractorDto>(new FindContractorByEinQuery() {ContractorEin = ein });
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TempCont tcont)
        {
            var rnd = new Random();
            var ein = rnd.Next(100000000, 999999999).ToString() + "AA";
            var cont = new ContractorDto
            {
                ID = GuidHelper.NewSequentialGuid(),
                ContractorName =  tcont?.name ?? "Some Contractor",
                DoingBusinessAs = tcont?.dba ?? "DBA",
                EinNumber = ein,
                SuffixCode = "AA",
                ContactEmail = "Contact@xyz.com",
                ContactFirstName = "ContactFirst",
                ContactLastName = "ContactLast",
                ContactPhoneNumber = "7894561234",
                ContractStartDate = DateTime.Now,
                ContractEndDate = DateTime.Now.AddYears(1),
                Email = "SomeContractor@xyz.com",
                PhoneNumber = "7458961325",
                Status = ContractorStatus.Open,
                Type = ContractorType.Contracted,
                StateCode = "PA",
                ZipCode = "17050",
                AddressLine1 = "Address Line 1",
                City = "Mechanicsburg",
            };
            var result = _commandBus.Submit<AddNewContractorCommand>(new AddNewContractorCommand(cont));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
