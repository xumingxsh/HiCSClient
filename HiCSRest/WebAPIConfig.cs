﻿using System;
using System.Web.Http;
namespace HiCSRest
{
    public class WebAPIConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional});
        }
    }
}