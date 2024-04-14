using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;

namespace SignalRWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7281/api/Contact/GetContact/1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateContactDto p)
        {
            var client = _httpClientFactory.CreateClient();

            var data = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7281/api/Contact", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View();
            }

            return View();
        }

    }
}
