using Assignment.EF;
using Assignment.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage All()
        {
            var db = new UMSContext();
            var data = db.Categories.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var db = new UMSContext();
            var data = db.Categories.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage Create(Category obj)
        {
            var db = new UMSContext();
            try
            {
                db.Categories.Add(obj);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "created" });
                ;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/category/update")]
        public HttpResponseMessage Update(Category obj)
        {
            var db = new UMSContext();
            try
            {
                var catagory = db.Categories.Find(obj.Id);
                obj.Name = catagory.Name;
                db.SaveChanges();
                db.Entry(catagory).CurrentValues.SetValues(obj);

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated" });
                ;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [Route("api/category/delete")]
        public HttpResponseMessage Delete(Category dlt)
        {
            var db = new UMSContext();
            var excatagory = db.Categories.Find(dlt.Id);
            dlt.Name = excatagory.Name;
            db.Entry(excatagory).CurrentValues.SetValues(dlt);
            db.Categories.Remove(excatagory);
            try
            {

                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" })
                ;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
