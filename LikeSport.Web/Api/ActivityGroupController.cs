using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using LikeSport.Model;
using LikeSport.Service;
using LikeSport.Web.Infrastructure.Core;
using LikeSport.Web.Infrastructure.Extensions;
using LikeSport.Web.Models;

namespace LikeSport.Web.Api
{
    [RoutePrefix("api/activitygroup")]
    public class ActivityGroupController : ApiControllerBase
    {
        private readonly IActivityGroupService _activityGroupService;

        public ActivityGroupController(IActivityGroupService activityGroupService)
        {
            _activityGroupService = activityGroupService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            var listActivityGroup = _activityGroupService.GetAllActivityGroups();


            var listActivityGroupVm = Mapper.Map<List<ActivityGroupViewModel>>(listActivityGroup);

            var response = request.CreateResponse(HttpStatusCode.OK, listActivityGroupVm);

            return response;
        }
      

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, ActivityGroupViewModel mActivityGroup)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var newActivityGroup = new ActivityGroup();

                newActivityGroup.UpdateActivityGroup(mActivityGroup);

                var activity = _activityGroupService.Add(newActivityGroup);

                _activityGroupService.SaveChange();

                response = request.CreateResponse(HttpStatusCode.Created, activity);
            }
            return response;
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, ActivityGroupViewModel mActivityGroup)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var activityGroup = _activityGroupService.GetById(mActivityGroup.Id);

                activityGroup.UpdateActivityGroup(mActivityGroup);

                _activityGroupService.Update(activityGroup);
                _activityGroupService.SaveChange();

                response = request.CreateResponse(HttpStatusCode.OK);
            }
            return response;
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                _activityGroupService.Delete(id);
                _activityGroupService.SaveChange();

                response = request.CreateResponse(HttpStatusCode.OK);
            }
            return response;
        }
    }
}
