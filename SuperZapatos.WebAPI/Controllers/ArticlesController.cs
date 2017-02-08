using SuperZapatos.Models;
using SuperZapatos.Models.DTO;
using System;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

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
                                    TOTAL_IN_VAULT = a.TOTAL_IN_VAULT,
                                    STORE_ID = a.STORE_ID
                                }
                            ).ToList();

            return Ok(new { articles = articlesList, success = true, total_elements = articlesList.Count });
        }

        // GET: api/Articles/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticle(Guid id)
        {
            var articlesList = (from a in db.Articles.Where(a => a.ARTICLE_ID == id)
                                select new ArticleDTO
                                {
                                    ARTICLE_ID = a.ARTICLE_ID,
                                    NAME = a.NAME,
                                    DESCRIPTION = a.DESCRIPTION,
                                    PRICE = a.PRICE,
                                    TOTAL_IN_SHELF = a.TOTAL_IN_SHELF,
                                    TOTAL_IN_VAULT = a.TOTAL_IN_VAULT,
                                    STORE_ID = a.STORE_ID
                                }
                       ).ToList();

            if (articlesList == null)
            {
                return Ok(new { error_msg = "Record not found", error_code = 404, success = false });
            }
            else
            {
                return Ok(new { articles = articlesList, success = true });
            }
        }
    }
}