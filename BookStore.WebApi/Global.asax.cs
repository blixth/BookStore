﻿namespace BookStore.WebApi
{
    using System.Web.Http;
    using System.Web.Mvc;


    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
