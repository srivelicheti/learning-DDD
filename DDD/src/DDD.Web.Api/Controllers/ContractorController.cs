﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DDD.Common.DTOs.Provider;
using DDD.Domain.Common.Command;
using DDD.Provider.Domain.Commands;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Enums;

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
        public void Post([FromBody]string name, [FromBody]string dba)
        {
            var rnd = new Random();
            var ein = rnd.Next(100000000, 999999999).ToString() + "AA";
            var cont = new ContractorDto
            {
                ID = GuidHelper.NewSequentialGuid(),
                ContractorName = string.IsNullOrEmpty(name)? "Some Contractor" : name,
                DoingBusinessAs = string.IsNullOrEmpty(dba)? "DBA":dba,
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
