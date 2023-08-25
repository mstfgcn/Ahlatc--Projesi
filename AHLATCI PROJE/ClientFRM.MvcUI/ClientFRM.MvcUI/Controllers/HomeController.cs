using ClientFRM.MvcUI.Models;
using ClientFRM.MvcUI.Models.ApiTypes;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ClientFRM.MvcUI.Controllers
{
    public class HomeController : Controller
    {
      

        
        public async Task<IActionResult> IndexAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5150/api");

                var respMsgCategories =
                  await client.GetAsync($"{client.BaseAddress}/category");

                var responseBodyCategories = await respMsgCategories.Content.ReadAsStringAsync();

                var responseBodyCategoriesObject =
                  JsonSerializer.Deserialize<ResponseBody<List<CategoryItem>>>(responseBodyCategories, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


                return View(responseBodyCategoriesObject.Data);

            }

            
        }

       
    }
}