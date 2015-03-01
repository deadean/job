using log4net.Config;
using Ninject;
using Ninject.Activation;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Common.Implementations.Formatting.Json;
using WebApi.Common.Implementations.Logging;
using WebApi.Common.Interfaces.Formatting.Json;
using WebApi.Data.Interfaces.QueryProcessors;
using WebApi.DataBase.Oracle.Implementations.QueryProcessors;
using WebApi.Web.Common.Implementations.Logging;
using WebApi.Web.Interfaces.Logging;
using WebApi.WebApiService.Implementations.DependencyBlock;
using WebApi.WebApiService.Implementations.Processing;
using WebApi.WebApiService.Interfaces.DependencyBlock;
using WebApi.WebApiService.Interfaces.Processing.Inquiry;

namespace WebApi.WebApiService.App_Start
{
	public class NinjectConfigurator
	{
		/// <summary>
		///     Entry method used by caller to configure the given
		///     container with all of this application's
		///     dependencies.
		/// </summary>
		public void Configure(IKernel container)
		{
			AddBindings(container);
		}

		private void AddBindings(IKernel container)
		{
			ConfigureLog4net(container);

			container.Bind<IPhotoDependencyBlock>().To<PhotoDependencyBlock>().InRequestScope();

			container.Bind<IPhotoInquiryProcessor>().To<PhotoInquiryProcessor>().InRequestScope();

			/***Initialize Oracle Processors implementations***/
			container.Bind<IUserByLoginAndPasswordQueryProcessor>().To<UserByLoginAndPasswordQueryProcessor>().InRequestScope();
			container.Bind<IPhotoQueryProcessor>().To<PhotoQueryProcessor>().InRequestScope();
		}

		private void ConfigureLog4net(IKernel container)
		{
			XmlConfigurator.Configure();

			var logManager = new LogManagerAdapter();
			container.Bind<ILogManager>().ToConstant(logManager);
		}
	}
}