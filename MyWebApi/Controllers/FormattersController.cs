using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MyWebApi.Controllers
{
    public class FormattersController : ApiController
    {
        // GET: Formatters
        public IEnumerable<string> Index()
        {
            IList<string> formatters = new List<string>();
            //GlobalConfiguration.Configuration.Formatters returns MediaTypeFormatterCollection that includes all formatter class
            foreach(var item in GlobalConfiguration.Configuration.Formatters)
            {
                formatters.Add(item.ToString());
            }
            return formatters.AsEnumerable<string>();
        }
    }
}