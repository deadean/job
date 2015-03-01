using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebApi.Common.Implementations.Logging;
using WebApi.Web.Common.Implementations.Logging;

namespace WebApi.WebApiService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
						//AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
						//AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
        }

				void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
				{
					CLog.Log(string.Format("loading assembly : {0}, {1}", args.LoadedAssembly.FullName, args.LoadedAssembly.Location));
				}

				private System.Reflection.Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
				{
					CLog.Log(string.Format("loading assembly : {0}, {1}", args.Name, args.RequestingAssembly.Location));

					return args.RequestingAssembly;
				}
    }
}
