using HelloWebAPI.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace HelloWebAPI
{
    //Web API is configured only using code based configuration using GlobalConfiguration class. 
    public class Global : System.Web.HttpApplication
    {
        //when application starts it will call Application_Start event
        protected void Application_Start(object sender, EventArgs e)
        {
            //The Configure() method requires a callback method where you have configured your Web API.
            GlobalConfiguration.Configure(HelloWebAPIConfig.Register); 
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}