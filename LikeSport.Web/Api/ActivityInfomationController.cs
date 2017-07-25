using System;
using System.Collections.Generic;
using System.Linq;
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
    [RoutePrefix("api/activityinfomation")]
    public class ActivityInfomationController : ApiControllerBase
    {
        private readonly IActivityInfomationService _service;

        public ActivityInfomationController(IActivityInfomationService service)
        {
            _service = service;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            var list = _service.GetAll();


            var listVm = Mapper.Map<List<ActivityInformationViewModel>>(list);

            var response = request.CreateResponse(HttpStatusCode.OK, listVm);

            return response;
        }

        [Route("getallbyactivityid")]
        public HttpResponseMessage GetByActivityId(HttpRequestMessage request,int id)
        {
            var list = _service.GetAllByActivityId(id);


            var listVm = Mapper.Map<List<ActivityInformationViewModel>>(list);

            var response = request.CreateResponse(HttpStatusCode.OK, listVm);

            return response;
        }
        [Route("getallbymultilactivityid")]
        public HttpResponseMessage GetByMutilActivityId(HttpRequestMessage request, string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var listId = new List<int>(Array.ConvertAll(id.Split(','), int.Parse));
                var list = _service.GetAllByMultiActivityId(listId);
                var listVm = Mapper.Map<List<ActivityInformationViewModel>>(list);

                var response = request.CreateResponse(HttpStatusCode.OK, listVm);
                return response;
            }

            else
            {
                var list = _service.GetAll();

                var listVm = Mapper.Map<List<ActivityInformationViewModel>>(list);

                var response = request.CreateResponse(HttpStatusCode.OK, listVm);
                return response;
            }
           
        }
        [Route("getallbyactivitygroupid")]
        public HttpResponseMessage GetByActivityGroupId(HttpRequestMessage request, int id)
        {
            var list = _service.GetAllByActivityGroupId(id);


            var listVm = Mapper.Map<List<ActivityInformationViewModel>>(list);

            var response = request.CreateResponse(HttpStatusCode.OK, listVm);

            return response;
        }
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, ActivityInformationViewModel mModel)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var newModel = new ActivityInformation();

                newModel.UpdateActivityInformation(mModel);

                var activity = _service.Add(newModel);

                _service.SaveChange();

                response = request.CreateResponse(HttpStatusCode.Created, activity);
            }
            return response;
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, ActivityInformationViewModel mModel)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var model = _service.GetById(mModel.Id);

                model.UpdateActivityInformation(mModel);

                _service.Update(model);
                _service.SaveChange();

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
                _service.Delete(id);
                _service.SaveChange();

                response = request.CreateResponse(HttpStatusCode.OK);
            }
            return response;
        }
    }
}
