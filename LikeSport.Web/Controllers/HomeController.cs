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
          
            using (var client = new HttpClient())
            {
                string url = Common.Common.Url;
                client.BaseAddress = new Uri(Common.Common.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseservice = client.GetAsync(url + "activitygroup/getnameall").Result;
                if (responseservice.IsSuccessStatusCode)
                {
                    string responseService = responseservice.Content.ReadAsStringAsync().Result;

                    var listActivityGroup = JsonConvert.DeserializeObject<List<ActivityGroupViewModel>>(responseService).ToList();
                  
                    return View(listActivityGroup);
                }
            }
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
                //HttpResponseMessage responsseActivityinfomation = client.GetAsync(url + "activityinfomation/getallbyactivitygroupid?id=" + id).Result;
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
        public ActionResult DetailProduct(int id)
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

                    //var tuple = new Tuple<IEnumerable<ServiceViewModel>, LoginRegisterViewModel>(courseCount, new LoginRegisterViewModel());
                    //return View(tuple);
                    return PartialView(courseCount);
                }
            }
            return PartialView();
        }
    }
}