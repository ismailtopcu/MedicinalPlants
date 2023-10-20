using MedicinalPlants.DtoLayer.AilmentDto;
using MedicinalPlants.DtoLayer.PlantDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace MedicinalPlants.WebUI.Controllers
{
    public class PlantsController : Controller
    {   
        private readonly IHttpClientFactory _httpClientFactory;

        public PlantsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> PlantsList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7240/api/plants");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListPlantDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreatePlant()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlant(CreatePlantDto createPlantDto,IFormFile plantImage)
        {
			if (plantImage != null)
			{
				var imageFileName = $"{createPlantDto.PlantName}_{Guid.NewGuid()}.jpg";
				var imagePath = Path.Combine("wwwroot/photos", imageFileName);
				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					await plantImage.CopyToAsync(stream);
				}

                var imageUrl = "/photos/" + imageFileName;
				createPlantDto.PlantImage = imageUrl;
			}

			var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPlantDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7240/api/plants", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("PlantsList");
            }
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdatePlant(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7240/api/plants/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdatePlantDto>(jsonData);
                var responseAilments = await client.GetAsync("https://localhost:7240/api/ailments");
                var jsonAilments = await responseAilments.Content.ReadAsStringAsync();
                var valueAilments = JsonConvert.DeserializeObject<List<ResultAilmentDto>>(jsonAilments);
                ViewBag.Ailments = valueAilments;
                return View(value);
            }
            return RedirectToAction("PlantsList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePlant(UpdatePlantDto updatePlantDto, IFormFile plantFile)
        {
			if (plantFile != null)
			{
				var imageFileName = $"{updatePlantDto.PlantName}_{Guid.NewGuid()}.jpg";
				var imagePath = Path.Combine("wwwroot/photos", imageFileName);
				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					await plantFile.CopyToAsync(stream);
				}

				var imageUrl = "/photos/" + imageFileName;
				updatePlantDto.PlantImage = imageUrl;
			}            
            

			var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePlantDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7240/api/plants", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("PlantsList");
            }
            return View();
        }
    }
}
