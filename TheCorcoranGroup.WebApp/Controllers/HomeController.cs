using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using TheCorcoranGroup.Model;
using TheCorcoranGroup.WebApp.Models;

namespace TheCorcoranGroup.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public static List<PresidentModel> GetAllPresident()
        {
            string serverpathApi = ConfigurationManager.AppSettings.Get("serverpathApi");

            using (HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false }))
            {
                client.BaseAddress = new Uri(serverpathApi);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("X-Forwarded-For", System.Web.HttpContext.Current.Request.UserHostAddress);
                client.DefaultRequestHeaders.Add("X-User-Agent", System.Web.HttpContext.Current.Request.UserAgent);

                string relativePath = "api/content/v2/presidents";

                HttpResponseMessage response = null;

                response = client.GetAsync(relativePath).Result;

                var responseString = response.Content.ReadAsStringAsync().Result;
                var responseA = Newtonsoft.Json.JsonConvert.DeserializeObject<ContentItemApiResponse>(responseString);
                List<PresidentModel> presidents = new List<PresidentModel>();

                if (responseA.Success)
                {
                    var president = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<PresidentModel>>(responseA.Data);
                    presidents = president.ToList();
                }
                

                return presidents;
            }
        }
    }
}