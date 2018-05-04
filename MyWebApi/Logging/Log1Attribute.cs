using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MyWebApi.Logging
{
    //Deriving from Attribute class makes it an attribute and implementing IActionFilter makes class as action filter
    //Now, you can apply []
    public class Log1Attribute : Attribute, IActionFilter
    {
        public Log1Attribute()
        {

        }

        //public bool AllowMultiple => throw new NotImplementedException();
        public bool AllowMultiple
        {
            get { return true; }
        }

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            Trace.WriteLine(string.Format("Action method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
            var result = continuation();
            result.Wait();
            Trace.WriteLine(string.Format("Action method {0} executed at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
            return result;
        }
    }
}