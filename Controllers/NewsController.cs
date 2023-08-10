using Assignment.EF.Models;
using Assignment.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class NewsController : ApiController
    {

        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage All()
        {
            var db = new UMSContext();
            var data = db.News.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/news/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var db = new UMSContext();
            var data = db.News.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Create(News obj)
        {
            var db = new UMSContext();
            try
            {
                db.News.Add(obj);
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
        [Route("api/News/Update")]
        public HttpResponseMessage UpdateNews(News news)
        {
            var db = new UMSContext();
            var preNews = db.News.Find(news.Id);
            db.Entry(preNews).CurrentValues.SetValues(news);
            try
            {



                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "News Updated " });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }



        }
        [HttpDelete]
        [Route("api/news/delete")]

        public HttpResponseMessage DeleteNews(News news)
        {
            var db = new UMSContext();
            var preNews = db.News.Find(news.Id);
            db.News.Remove(preNews);
            try
            {
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "News Deleted " });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/News/Category/{cname}")]
        public HttpResponseMessage getNewsByCategory(string cname)
        {
            var db = new UMSContext();
            try
            {
                var result = (from c in db.Categories
                                     where c.Name.Equals(cname)
                                     select c.News).SingleOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, convert(result));
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }

        }

        NewsDTO convert(News news)
        {
            return new NewsDTO()
            {
                Id = news.Id,
                Title = news.Title,
                date = news.date,
                Description = news.Description,
                C_Id = news.C_Id
            };
        }
        List<NewsDTO> convert(ICollection<News> news)
        {
            return (from n in news select convert(n)).ToList();
        }


    }
}

