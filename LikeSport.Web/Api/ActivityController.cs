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
    [RoutePrefix("api/activity")]
    public class ActivityController : ApiControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            var listActivity = _activityService.GetAllActivity();


            var listActivityVm = Mapper.Map<List<ActivityViewModel>>(listActivity);

            var response = request.CreateResponse(HttpStatusCode.OK, listActivityVm);

            return response;
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, ActivityViewModel mActivity)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var newActivity = new Activity();

                newActivity.UpdateActivity(mActivity);

                var activity = _activityService.Add(newActivity);

                _activityService.SaveActivity();

                response = request.CreateResponse(HttpStatusCode.Created, activity);
            }
            return response;
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, ActivityViewModel mActivity)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var activity = _activityService.GetById(mActivity.Id);

                activity.UpdateActivity(mActivity);

                _activityService.Update(activity);
                _activityService.SaveActivity();

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
                _activityService.Delete(id);
                _activityService.SaveActivity();

                response = request.CreateResponse(HttpStatusCode.OK);
            }
            return response;
        }
    }
}