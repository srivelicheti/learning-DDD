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
            var model = new AddNewContractorViewModel
            {
                ContactFirstName = "ContFirst",
                ContactLastName = "ContLast",
                AddressLine1 = "3600 Vartan Way",
                City = "Harrisburg",
                ZipCode = "17050",
                ContractStartDate = DateTime.Now.Date,
                PhoneNumber = "7172157096",
                Email="Test@test.com",
                ContactPhoneNumber = "7171245712",
                ContactEmail = "test@tes.com",
                 ContractorName = "Boys N Girls",
                 DoingBusinessAs = "BNG",
                 EinNumber = "123456",
                 
            };
            return View(model);
        }

        public async Task<ActionResult> Add(AddNewContractorViewModel model)
        {
            var modelState = this.ActionContext.ModelState;
            if (modelState.IsValid)
            {
                var client = new HttpClient();
                model.Id = Guid.NewGuid();
                model.StateCode = "DE";
                client.BaseAddress = new Uri("http://uscmpsrveliche2:54441/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage reqMessage = new HttpRequestMessage() {Method = HttpMethod.Post};
                reqMessage.Headers.Accept.Clear();
                reqMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                reqMessage.RequestUri = new Uri(@"api/contractor", UriKind.RelativeOrAbsolute);

                var payload = JsonConvert.SerializeObject(model);
                var content = new StringContent(payload, System.Text.Encoding.UTF32, "application/json");
                var resp = await client.PostAsync(@"api/contractor", content);
                if (resp.IsSuccessStatusCode)
                    return View("ContractorAdded", payload);
                else
                {
                    var error = resp.Content.ReadAsStringAsync();
                    ViewData["Error"] = error;
                    return View("Index", model);
                }
            }
            else
            {
                var errors = string.Join(Environment.NewLine,
                    modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

                ViewData["Error"] = errors;
                return View("Index", model);
            }
        }
    }
}
