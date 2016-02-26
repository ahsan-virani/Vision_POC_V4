using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_Approach.Controllers
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

        public ActionResult GetUsers()
        {
            ViewBag.Message = "Users List";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://localhost:54138/api/UserEF/").Result;

                // This works:
                var jsonResponse = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                //// This may not work:
                //return response.Content.ReadAsAsync().Result;

                //// This may not work:
                //return response.Content.ReadAsOrDefaultAsync().Result;
                ViewBag.Response = jsonResponse;
            }

            return View();
        }

        public object GetUsersList()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://localhost:54138/api/UserEF/").Result;

                // This works:
                return JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                //// This may not work:
                //return response.Content.ReadAsAsync().Result;

                //// This may not work:
                //return response.Content.ReadAsOrDefaultAsync().Result;
            }
        }
    }
}