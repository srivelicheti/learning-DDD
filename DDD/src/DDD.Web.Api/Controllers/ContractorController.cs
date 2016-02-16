using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using DDD.Common.DTOs.Provider;
using DDD.Domain.Common.Command;
using DDD.Provider.Domain.Commands;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Enums;
using DDD.Domain.Common.Query;
using DDD.Provider.QueryStack.Contractor.Queries;
using DDD.Web.Api.Infrastructure.ActionFilters;
using DDD.Web.Api.Models.Provider;

namespace DDD.Web.Api.Controllers
{
    public class TempCont
    {
        public string Name { get; set; }
        public string DBA { get; set; }

        public string ContractorType { get; set; }
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
            var type = typeof (ContractorType);
            return _queryProcessor.Process<ContractorDto>(new FindContractorByEinQuery() {ContractorEin = ein });
        }

        // POST api/values
        [HttpPost]
        [ValidateModel]
        public void Post([FromBody]AddNewContractorModel contractorModel)
        {
            var rnd = new Random();
            var ein = rnd.Next(100000000, 999999999).ToString();
            var cont = Mapper.Map<ContractorDto>(contractorModel);
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
