using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;

namespace SignalRWebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7281/api/About/GetAbout/1");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);

                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ResultAboutDto p)
        {
            var client = _httpClientFactory.CreateClient();
            var value = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(value,Encoding.UTF8,"application/json");

            var responseMessage = await client.PutAsync("https://localhost:7281/api/About", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
