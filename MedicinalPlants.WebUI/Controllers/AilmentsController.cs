using MedicinalPlants.DtoLayer.AilmentDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MedicinalAilments.WebUI.Controllers
{
    public class AilmentsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AilmentsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AilmentsList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7240/api/ailments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAilmentDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateAilment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAilment(CreateAilmentDto createAilmentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAilmentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7240/api/ailments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AilmentsList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAilment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7240/api/ailments/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAilmentDto>(jsonData);
                return View(value);
            }
            return RedirectToAction("AilmentsList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAilment(UpdateAilmentDto updateAilmentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAilmentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7240/api/ailments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AilmentsList");
            }
            return View();
        }
    }
}
