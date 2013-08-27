#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ParadiseBookers.Core.Interfaces.Service;
using ParadiseBookers.Core.Model;
using ParadiseBookers.Extensions.ModelStateHelpers;

namespace ParadiseBookers.Areas.Api.Controllers
{
    #region

    

    #endregion

    public abstract class ApiController<T> : ApiController where T : DomainObject
    {
        protected IService<T> Service;

        public virtual HttpResponseMessage Get(int id)
        {
            T item = Service.GetById(id);
            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return response;
        }

        public virtual IEnumerable<T> Get()
        {
            return Service.GetAll();
        }

        public virtual void Delete(int id)
        {
            T entity = Service.GetById(id);
            Service.Delete(entity);
        }

        public virtual HttpResponseMessage Post(T entity)
        {
            if (ModelState.IsValid)
            {
                var result = Service.SaveOrUpdate(entity);

                if (ModelState.Process(result))
                {
                    var response = new HttpResponseMessage(HttpStatusCode.Created);
                    string uri = Url.Link("DefaultApi", new { id = entity.Id });
                    response.Headers.Location = new Uri(uri);
                    return Get(entity.Id);    
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        public virtual HttpResponseMessage Put(T entity)
        {
            if (ModelState.IsValid)
            {
                Service.SaveOrUpdate(entity);
                var response = Request.CreateResponse(HttpStatusCode.Created, entity);
                string uri = Url.Link("DefaultApi", new { id = entity.Id });
                response.Headers.Location = new Uri(uri);
                return response;    
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpGet]
		public virtual IEnumerable<T> Page(int page, int pageSize)
        {
            var p = Service.Page(page, pageSize);
            return p.Entities.ToList();
        }
    }
}