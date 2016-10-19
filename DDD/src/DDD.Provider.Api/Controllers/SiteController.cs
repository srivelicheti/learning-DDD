using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DDD.Domain.Common.Query;
using DDD.Provider.Api.Contracts.DTOs;
using DDD.Provider.Api.Contracts.Models.Site;
using DDD.Provider.Messages.Commands;
using DDD.Web.Api.Infrastructure.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DDD.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class SiteController : Controller
    {
        private IEndpointInstance _bus;
        private IQueryProcessor _queryProcessor;

        public SiteController(IEndpointInstance commandBus, IQueryProcessor queryProcessor)
        {
            _bus = commandBus;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ValidateModel]
        public JsonResult Post([FromBody]AddNewSiteModel value)
        {
            var siteDto = Mapper.Map<SiteDto>(value);
            var command = new AddNewSiteCommand(siteDto);
            _bus.Send(command);
            return new JsonResult(new {CommandId = command.Id});
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
