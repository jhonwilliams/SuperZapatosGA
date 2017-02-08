using SuperZapatos.Models;
using SuperZapatos.Models.DTO;
using System;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

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

            return Ok(new { stores = storesList, success = true, total_elements = storesList.Count });
        }

        // GET: api/Stores/5
        [ResponseType(typeof(Store))]
        public IHttpActionResult GetStore(Guid id)
        {
            var storesList = (from c in db.Stores.Where(a => a.STORE_ID == id)
                              select new StoreDTO
                              {
                                  STORE_ID = c.STORE_ID,
                                  NAME = c.NAME,
                                  ADDRESS = c.ADDRESS
                              }
                           ).ToList();


            if (storesList == null)
            {
                return Ok(new { error_msg = "Record not found", error_code = 404, success = false });

            }
            else
            {
                return Ok(new { stores = storesList, success = true });
            }


        }

    }
}