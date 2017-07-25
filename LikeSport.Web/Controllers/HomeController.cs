using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using LikeSport.Web.Models;
using Newtonsoft.Json;

namespace LikeSport.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }
      
        public ActionResult AllActivityInGroup(int id)
        {
            ViewBag.IdGroup = id;
            using (var client = new HttpClient())
            {
                string url = Common.Common.Url;
                client.BaseAddress = new Uri(Common.Common.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseservice = client.GetAsync(url + "activity/getallbygroupid?id="+ id).Result;

                if (responseservice.IsSuccessStatusCode)
                {
                    string responseService = responseservice.Content.ReadAsStringAsync().Result;

                    var listActivity = JsonConvert.DeserializeObject<List<ActivityViewModel>>(responseService).ToList();
                    return View(listActivity);
                }
            }
            return View();
        }
        public ActionResult AllActivityInfomationInActivity(int id)
        {

            return View();
        }
        
        public String ReName(string str)
        {
            return Common.Common.RemoveSign4VietnameseString(str);
        }
        public ActionResult DetailProduct()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Header()
        {
            using (var client = new HttpClient())
            {
                string url =Common.Common.Url;
                client.BaseAddress = new Uri(Common.Common.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseservice = client.GetAsync(url + "service/getall").Result;
               
                if (responseservice.IsSuccessStatusCode)
                {
                    string responseService = responseservice.Content.ReadAsStringAsync().Result;
          
                    var courseCount = JsonConvert.DeserializeObject<List<ServiceViewModel>>(responseService).ToList().Take(10);
                    return PartialView(courseCount);
                }
            }
            return PartialView();
        }
    }
}