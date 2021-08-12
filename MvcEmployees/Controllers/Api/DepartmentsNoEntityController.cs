using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcEmployees.Controllers.Api
{
    public class DepartmentsNoEntityController : ApiController
    {
        // GET: api/DepartmentsNoEntity
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DepartmentsNoEntity/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DepartmentsNoEntity
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DepartmentsNoEntity/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DepartmentsNoEntity/5
        public void Delete(int id)
        {
        }
    }
}
