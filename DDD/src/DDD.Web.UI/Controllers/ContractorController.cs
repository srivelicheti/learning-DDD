using DDD.Web.UI.ViewModels;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDD.Web.UI.Controllers
{
    public class ContractorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Add(AddContractorViewModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var payload = JsonConvert.SerializeObject(new {
                contractorName=model.ContractorName,
                dba=model.DBA
            });
            var contnt = new StringContent(payload);
            await client.PostAsync(@"api/contractor", contnt);
            return View("ContractorAdded");
        }
    }
}
