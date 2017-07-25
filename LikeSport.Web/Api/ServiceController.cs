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
    [RoutePrefix("api/service")]
    public class ServiceController : ApiControllerBase
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService serviceService)
        {
            _service = serviceService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            var list = _service.GetAllService();


            var listVm = Mapper.Map<List<ServiceViewModel>>(list);

            var response = request.CreateResponse(HttpStatusCode.OK, listVm);

            return response;
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, ServiceViewModel mModel)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var newModel = new Model.Service();

                newModel.UpdateService(mModel);

                var activity = _service.Add(newModel);

                _service.SaveService();

                response = request.CreateResponse(HttpStatusCode.Created, activity);
            }
            return response;
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, ServiceViewModel mModel)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var model = _service.GetById(mModel.Id);

                model.UpdateService(mModel);

                _service.Update(model);
                _service.SaveService();

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
                _service.SaveService();

                response = request.CreateResponse(HttpStatusCode.OK);
            }
            return response;
        }
    }
}
