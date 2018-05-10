﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace 调用webapi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //var format = GlobalConfiguration.Configuration.Formatters;
            /////清除 默认的xml格式,一般不用
            //format.XmlFormatter.SupportedMediaTypes.Clear();

            ////通过参数设置返回格式
            //format.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("t", "json", "application/json"));
            //format.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("t", "xml", "application/xml"));
        }
    }
}
