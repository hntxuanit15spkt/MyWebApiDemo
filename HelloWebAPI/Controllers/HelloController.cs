using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWebAPI.Controllers
{
    public class HelloController : ApiController
    {
        //Khi gõ GET api/Hello thì nó sẽ gọi đến phương thức Get trong controller này
        public string Get()
        {
            return "Hello World";
        }
    }
}
