using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //Cách 2 để viết method trong Web API
        [HttpGet]
        [Route("api/values/getvalue1")] //This is attribute routing
        public IEnumerable<string> GetValue1()
        {
            return new string[] { "value 1" };
        }

        // GET api/values/5
        //Web API will try to extract the value of id from the query string of requested URL, 
        //convert it into int and asign it to id parameter of Get action method
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

        //PATCH
        public void Patch(int id)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public HttpResponseMessage Get(int? id)
        {
            if(id == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, id);
        }

        public IHttpActionResult Get(string strId)
        {
            if(strId == null)
            {
                return NotFound();
            }
            return Ok(strId);
        }
    }
}
