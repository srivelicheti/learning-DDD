using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DDD.Common.DTOs.Provider;
using DDD.Domain.Common.Command;
using DDD.Provider.Domain.Commands;

namespace DDD.Web.Api.Controllers
{
    [Route("api/contractor")]
    public class ContractorController : Controller
    {
        private ICommandBus _commandBus;
        public ContractorController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var commandResult = _commandBus.Submit<AddNewContractorCommand>(new AddNewContractorCommand(null));
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ContractorDto contractor)
        {
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
