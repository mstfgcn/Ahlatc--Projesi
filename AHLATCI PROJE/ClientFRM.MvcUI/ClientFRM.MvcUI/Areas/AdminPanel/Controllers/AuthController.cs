using ClientFRM.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using ClientFRM.MvcUI.Areas.AdminPanel.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ClientFRM.MvcUI.Areas.AdminPanel.Controllers
{
    public class AuthController : Controller
    {
        [Area ("AdminPanel")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto dto)
        {
            // servisle habeleşecek ilgili endpointten böyle bir kullanıcı var mı diye kontrol ettirecek
            // SERVİSDEN GELEN YANITA BAKACAK 
            // client tarayıcısına, oradaki ajax çağrılan yere bir yanıt dönecek

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5150/api");

                var responseMessage = await client.GetAsync($"{client.BaseAddress}/auth/login?userName={dto.UserName}&password={dto.Password}");

                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<ResponseBody<AdminPanelUserItem>>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                if (responseMessage.IsSuccessStatusCode)
                {

                    HttpContext.Session.SetString("ActiveAdminPanelUser", JsonSerializer.Serialize(response.Data));

                    return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
                }
            }


        }
    }
}
