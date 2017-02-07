using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SuperZapatos.Models;
using SuperZapatos.Models.DTO;

namespace SuperZapatos.WebAPI.Controllers
{
    public class ArticlesController : ApiController
    {
      private SuperZapatos.Models.SuperZapatos db = new SuperZapatos.Models.SuperZapatos();

        // GET: api/Articles
        public IHttpActionResult GetArticles()
        {
            var articlesList = (from a in db.Articles
                            select new ArticleDTO
                            {
                                ARTICLE_ID = a.ARTICLE_ID,
                                NAME = a.NAME,
                                DESCRIPTION = a.DESCRIPTION,
                                PRICE = a.PRICE,
                                TOTAL_IN_SHELF = a.TOTAL_IN_SHELF,
                                TOTAL_IN_VAULT =  a.TOTAL_IN_VAULT,
                                STORE_ID = a.STORE_ID
                            }
                            ).ToList();

            return Ok(new {articles= articlesList, success=true, total_elements = articlesList.Count });
        }

        // GET: api/Articles/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticle(Guid id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(new { articles = article, success = true });
        }
    }
}