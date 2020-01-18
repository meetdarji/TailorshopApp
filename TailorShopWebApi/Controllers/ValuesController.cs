using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TailorShopWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        TailorShopEntities db = new TailorShopEntities();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public void GetUsers(int id)
        {
            var tmp = db.tblCustomers.Where(a => a.CustomerID == id)
                     .Select(a => a.CustomerName + "-" + a.EmailId)
                     .ToList();
        }
    }
}
