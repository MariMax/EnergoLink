using CloudAskueApi.App_Start;
using System;
using System.Web.Http;


namespace CloudAskueApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var resolver = new Unity.WebApi.UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}