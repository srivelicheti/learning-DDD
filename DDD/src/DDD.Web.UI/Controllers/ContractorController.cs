using DDD.Web.UI.ViewModels;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            HttpRequestMessage reqMessage = new HttpRequestMessage() { Method = HttpMethod.Post };
            reqMessage.Headers.Accept.Clear();
            reqMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            reqMessage.RequestUri = new Uri(@"api/contractor", UriKind.RelativeOrAbsolute);

            var payload = JsonConvert.SerializeObject(new {
                name=model.ContractorName,
                dba=model.DBA
            });
            var content = new StringContent(payload, System.Text.Encoding.UTF32, "application/json");
            await client.PostAsync(@"api/contractor", content);
            return View("ContractorAdded",payload);
        }
    }
}
