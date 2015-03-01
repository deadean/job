﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using System.Web.Http.Tracing;
using WebApi.Web.Common.Implementations.Controllers;
using WebApi.Web.Common.Implementations.Logging;
using WebApi.Web.Common.Ninject;
using WebApi.Web.Common.Routing;
using WebApi.Web.Interfaces.Logging;

namespace WebApi.WebApiService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            config.Services.Replace(typeof(ITraceWriter),
                new SimpleTraceWriter(WebContainerManager.Get<ILogManager>()));

            config.Services.Add(typeof(IExceptionLogger),
                new SimpleExceptionLogger(WebContainerManager.Get<ILogManager>()));

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            // Web API routes
						//config.MapHttpAttributeRoutes();

						//config.Routes.MapHttpRoute(
						//		name: "DefaultApi",
						//		routeTemplate: "api/{controller}/{id}",
						//		defaults: new { id = RouteParameter.Optional }
						//);

						var constraintsResolver = new DefaultInlineConstraintResolver();
						constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
						config.MapHttpAttributeRoutes(constraintsResolver);

						config.Services.Replace(typeof(IHttpControllerSelector),
								new NamespaceHttpControllerSelector(config));
        }
    }
}
