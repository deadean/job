using System;
using WebApi.Common.Implementations.Logging;
using WebApi.Common.Interfaces.Logging;
using WebApi.DataBase.Oracle.Enumeration.Unity;
using WebApi.DataBase.Oracle.Implementations.Factories;
using WebApi.DataBase.Oracle.Implementations.Unity;
using WebApi.DataBase.Oracle.Interfaces.Factories;
using WebApi.DataBase.Oracle.Interfaces.ModelService;
using WebApi.DataBase.Oracle.Interfaces.ModelService.Repositories;
using Model = WebApi.DataBase.Oracle.Implementations.ModelService;

namespace WebApi.DataBase.Oracle.Bases.QueryProcessors
{
	public class QueryProcessorBase
	{
		#region Fields

		protected ILogService modLog;
		protected IModelService modModelService;

		#endregion

		static QueryProcessorBase()
		{
			Container.RegisterType(typeof(IDataBaseService), typeof(CDataBase), enTypeLifeTime.Singleton);			
			Container.RegisterType(typeof(IModelService), typeof(Model.ModelService), enTypeLifeTime.Singleton);

			Container.RegisterType(typeof(IUserRepository), typeof(Model.Repositories.UserRepository), enTypeLifeTime.Singleton);
			Container.RegisterType(typeof(IDocumentsRepository), typeof(Model.Repositories.DocumentsRepository), enTypeLifeTime.Singleton);

			Container.RegisterType(typeof(IDataObjectsFactory), typeof(DataObjectsFactory), enTypeLifeTime.Singleton);
		}

		public QueryProcessorBase()
		{
			try
			{
				InitLog();

				modModelService = Container.Resolve<IModelService>();
			}
			catch (Exception ex)
			{
				modLog.Debug(ex.Message);
			}
		}

		public virtual void InitLog() 
		{
			modLog = LogService.GetLogService<QueryProcessorBase>();
		}

		protected ILogService GetLog<T>() where T : class
		{
			return LogService.GetLogService<T>();
		}
	}
}
