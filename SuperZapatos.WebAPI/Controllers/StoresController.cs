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
    public class StoresController : ApiController
    {
        private SuperZapatos.Models.SuperZapatos db = new SuperZapatos.Models.SuperZapatos();

        // GET: api/Stores
        public IHttpActionResult GetStores()
        {

            var storesList = (from c in db.Stores
                          select new StoreDTO
                          {
                              STORE_ID = c.STORE_ID,
                              NAME = c.NAME,
                              ADDRESS = c.ADDRESS
                          }
                          ).ToList();

            return Ok( new { stores = storesList, success = true, total_elements = storesList.Count });
        }

        // GET: api/Stores/5
        [ResponseType(typeof(Store))]
        public IHttpActionResult GetStore(Guid id)
        {
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return NotFound();
            }
            else {
               
            }

            return Ok(new { stores = store, success = true });
        }

    }
}