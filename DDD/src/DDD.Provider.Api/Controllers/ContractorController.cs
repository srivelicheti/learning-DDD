using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DDD.Domain.Common.Command;
//using DDD.Provider.Domain.Commands;
//using DDD.Provider.Domain.Repositories;
//using DDD.Provider.Domain.Enums;
using DDD.Domain.Common.Query;
using DDD.Provider.Common.DTOs;
using DDD.Provider.Common.Models;
using DDD.Provider.QueryStack.Contractor.Queries;
using DDD.Web.Api.Infrastructure.ActionFilters;
using DDD.Web.Api.Models.Provider;
using NServiceBus;
using DDD.Provider.Messages.Commands;
using DDD.Provider.Domain.Contracts.Models;
using DDD.Provider.Domain.Enums;

namespace DDD.Web.Api.Controllers
{

    [Route("api/contractor")]
    public class ContractorController : Controller
    {
        private IEndpointInstance _bus;
        private IQueryProcessor _queryProcessor;

        public ContractorController(IEndpointInstance commandBus, IQueryProcessor queryProcessor)
        {
            _bus = commandBus;
            _queryProcessor = queryProcessor;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //_bus.Send(new TestCommand("Some contra"));
            return new[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ContractorDto Get(Guid id)
        {
            return _queryProcessor.Process<ContractorDto>(new FindContractorByIdQuery() { Id = id });
        }

        // GET api/values/5
        [HttpGet("Ein/{ein}")]
        public ContractorDto GetByEin(string ein)
        {
            var type = typeof(ContractorType);
            return _queryProcessor.Process<ContractorDto>(new FindContractorByEinQuery() { ContractorEin = ein });
        }

        // POST api/values
        [HttpPost]
        [ValidateModel]
        public JsonResult Post([FromBody]AddNewContractorModel contractorModel)
        {
            var cont = Mapper.Map<ContractorDto>(contractorModel);
            var addNewContractorCommand = new AddNewContractorCommand(cont);
            var result = _bus.Send(addNewContractorCommand);
            return new JsonResult(new {CommmandId = addNewContractorCommand.Id});
        }

        [HttpPut("{ein}")]
        [ValidateModel]
        public void Put([FromBody]UpdateContractorModel updateContractorModel)
        {
            _bus.Send(new UpdateContractorCommand(updateContractorModel));
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
        
        [HttpGet("{ein}/Exists")]
        public IActionResult Exists(string ein)
        {
            var exists =
                _queryProcessor.Process<bool>(new CheckIfContractorExistsQuery {EinNumber = ein});

            if (exists)
                return Ok();
            else
                return NotFound();
        }

    }
}
