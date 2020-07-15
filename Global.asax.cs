using LoginAPI.Config;
using System;
using System.Web.Http;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(LoginAPIConfig.Register);
        }
    }
}