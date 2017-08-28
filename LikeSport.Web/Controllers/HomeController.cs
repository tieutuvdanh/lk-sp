using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LikeSport.Service;
using LikeSport.Web.Models;
using Newtonsoft.Json;
using PagedList;

namespace LikeSport.Web.Controllers
{
    public class HomeController : Controller
    {
        private IActivityInfomationService _activityInfomationService;
        private IServiceService _service;
        private IActivityGroupService _activityGroupService;
        public HomeController(IActivityInfomationService activityInfomationService, IServiceService service, IActivityGroupService activityGroupService)
        {
            this._activityInfomationService = activityInfomationService;
            this._service = service;
            this._activityGroupService = activityGroupService;
        }
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
        public ActionResult Search(string sortOrder, string currentFilter, string searchText, string service, int? page,int?minPrice,int?maxPrice,string activities)
        {
            var listService = _service.GetAllService();
            var listAct = _activityGroupService.GetAllActivityGroups();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.minPrice = minPrice;
            ViewBag.maxPrice = maxPrice;
            ViewBag.listService = Mapper.Map<List<ServiceViewModel>>(listService); ;
            ViewBag.listActGroup = Mapper.Map<List<ActivityGroupViewModel>>(listAct); ;

            if (searchText != null)
            {
                page = 1;
            }
            else
            {
                searchText = currentFilter;
            }

            ViewBag.CurrentFilter = searchText;
            ViewBag.service = service;
            ViewBag.activities = activities;
            if (!string.IsNullOrEmpty(activities))
            {
                
            }
           
            List<int> arr = new List<int>();

         
            if (!string.IsNullOrEmpty(service) && service!= "SERVICES")
            {

                arr = service.Split(',').Select(Int32.Parse).ToList();

            }
            if (arr.Count > 0)
            {
                var listActivity =
                    _activityInfomationService.GetAllBySearch(searchText)
                        .Where(m => arr.Contains(m.Service_Id))
                        .ToList()
                    ;
                var list = Mapper.Map<List<ActivityInformationViewModel>>(listActivity);

                if (minPrice != null && maxPrice != null)
                {
                    list =list.Where(m =>
                    {
                        var promotionViewModel = m.Promotions.FirstOrDefault();
                        return promotionViewModel != null && (promotionViewModel.Percent >= minPrice &&
                                                                         promotionViewModel.Percent <= maxPrice);
                    }).ToList();

                }


                int pageSize = int.Parse(Common.Common.GetByKey("PageSize"));
                int pageNumber = (page ?? 1);

                return View(list.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var listActivity = _activityInfomationService.GetAllBySearch(searchText);
                var list = Mapper.Map<List<ActivityInformationViewModel>>(listActivity);
                list =
                    list.Where(
                        m =>
                        {
                            var promotionViewModel = m.Promotions.LastOrDefault();
                            return promotionViewModel != null && (promotionViewModel.Percent >= minPrice &&
                                                                  promotionViewModel.Percent <= maxPrice);
                        }).ToList();


                int pageSize = int.Parse(Common.Common.GetByKey("PageSize"));
                int pageNumber = (page ?? 1);

                return View(list.ToPagedList(pageNumber, pageSize));
            }


        }
        [ChildActionOnly]
        public ActionResult Header()
        {
            var listService = _service.GetAllService();

          
            ViewBag.listService = Mapper.Map<List<ServiceViewModel>>(listService); ;
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