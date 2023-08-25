using ClientFRM.MvcUI.Models.ApiTypes;
using ClientFRM.MvcUI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ClientFRM.MvcUI.Controllers
{
    public class ArticleController : Controller
    {
        public async Task<IActionResult> ArticlePage(int categoryId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5150/api");

                var respMsgCategories =
                  await client.GetAsync($"{client.BaseAddress}/Article/byCategoryId?id={categoryId}");

                var responseBodyArticles = await respMsgCategories.Content.ReadAsStringAsync();

                var responseBodyArticlesObject =
                  JsonSerializer.Deserialize<ResponseBody<List<CategoryItem>>>(responseBodyArticles, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });



                return View(responseBodyArticlesObject.Data);
            }
        }

        // BU METHODDA KAYIT EKLENECEK FORMU AÇIYORUZ
        [HttpGet]
        public async Task<IActionResult> NewArticle()
        {
            var categoryList = await GetCategoryList();
            return View(categoryList); 
        }

        //BU METHODDA İNSERYİ GERÇEKLEŞTİRİP BAŞKA BİR VİEW İLE SONUC EKRANI DÖNUYORUZ
        [HttpPost]
        public async Task<IActionResult> NewArticle(NewArticleDto dto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5150/api");

                //newArticledto tipindeki nesneyi jsona çevirip onuda stringcontente yolluyoruz.
                //servise gönderecegimiz verinin tipini söylememiz gerekiyor.
                //utf-8 karakterler barındıran json göndericem diyoruz.
                var stringContent = new StringContent(JsonSerializer.Serialize(dto), System.Text.Encoding.UTF8,"application/json");

               
                //servisdeki post edecegimiz methodun adı
                var responseMsg = await  client.PostAsync($"{client.BaseAddress}/Article", stringContent);

                var responseBodyArticle = await responseMsg.Content.ReadAsStringAsync();

                //var responseBodyArticleObject = JsonSerializer.Deserialize<ResponseBody<ArticleItem>>>(responseBodyArticle, new JsonSerializerOptions()
                //{ PropertyNameCaseInsensitive = true });
                if (responseMsg.IsSuccessStatusCode)
                { // başarılı bir durum kodu dönuyormu
                    //ufak tesek verileri viewbagle yolluyoruz.
                    //.Message kısmını sallayabiliriz bir degişken adı  gibi ne istersek yazabiliriz
                    ViewBag.Messeage = "Kayıt Başarılı";
                }
                else
                {   
                    ViewBag.Messeage = "Kayıt Başarısız";
                }
                var categoryList = await GetCategoryList();
                return View(categoryList);
            }






            return View();
        }


        //kayıt butonuna basıldıktan sonra sayfa tekrar yüklenirken hata vericek categortItemları tekrar çekebilmek için sadece burda çalışıcak bir method yazıyorz.
        private async Task<List<CategoryItem>> GetCategoryList()
        {
            //kategorileri getirmek için kullandıgımız kısım
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5150/api");

                var respMsgCategories =
                  await client.GetAsync($"{client.BaseAddress}/category");

                var responseBodyCategories = await respMsgCategories.Content.ReadAsStringAsync();

                var responseBodyCategoriesObject =
                  JsonSerializer.Deserialize<ResponseBody<List<CategoryItem>>>(responseBodyCategories, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


                return responseBodyCategoriesObject.Data;

            }
        }

        // silinmek istenen ürünün ıd sine göre servistek çektik
        //delete viewvene gönderdik
        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5150/api");

                var respMsgCategories =
                  await client.GetAsync($"{client.BaseAddress}/category");

                var responseBody = await respMsgCategories.Content.ReadAsStringAsync();

                var responseBodyObject =
                  JsonSerializer.Deserialize<ResponseBody<List<ArticleItem>>>(responseBody, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


                return View(responseBodyObject.Data);

            }
        }
    }
}
