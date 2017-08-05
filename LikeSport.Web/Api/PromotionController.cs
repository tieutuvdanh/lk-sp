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
    [RoutePrefix("api/promotion")]
    public class PromotionController : ApiControllerBase
    {
        private readonly IPromotionService _service;

        public PromotionController(IPromotionService service)
        {
            _service = service;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            var list = _service.GetAll();


            var listVm = Mapper.Map<List<PromotionViewModel>>(list);

            var response = request.CreateResponse(HttpStatusCode.OK, listVm);

            return response;
        }

        [Route("getallbyid")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            var list = _service.GetById(id);


            var listVm = Mapper.Map<List<PromotionViewModel>>(list);

            var response = request.CreateResponse(HttpStatusCode.OK, listVm);

            return response;
        }
        
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PromotionViewModel mModel)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var newModel = new Promotion();

                newModel.UpdatePromotion(mModel);

                var activity = _service.Add(newModel);

                _service.SaveChange();

                response = request.CreateResponse(HttpStatusCode.Created, activity);
            }
            return response;
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PromotionViewModel mModel)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var model = _service.GetById(mModel.Id);

                model.UpdatePromotion(mModel);

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
