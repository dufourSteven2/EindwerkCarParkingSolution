using EindwerkCarParking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EindwerkCarParking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";

            //return View();

            string uri = "http://" + Request.Url.Host + ':' + Request.Url.Port + "/api/parkings";
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return View(
                             Task.Factory.StartNew
                             (
                               () => JsonConvert.DeserializeObject<List<ParkingsDTO>>(response.Result)
                             )
                             .Result
                           );
            }

        }

      
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }
        [HttpPost()]
        public ActionResult Contact(object model)
        {
            return View();
        }

        public ActionResult IndexMijnTest()
        {
            //ViewBag.Title = "Home Page";

            //return View();

            string uri = "http://" + Request.Url.Host + ':' + Request.Url.Port + "/api/parkings";
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return View(
                             Task.Factory.StartNew
                             (
                               () => JsonConvert.DeserializeObject<List<ParkingsDTO>>(response.Result)
                             )
                             .Result
                           );
            }

        }
    }
}
