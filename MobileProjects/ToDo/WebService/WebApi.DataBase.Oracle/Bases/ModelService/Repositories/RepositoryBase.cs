using System;
using WebApi.Common.Implementations.Factories;
using WebApi.Common.Implementations.Logging;
using WebApi.Common.Interfaces.Factories;
using WebApi.Common.Interfaces.Logging;
using WebApi.DataBase.Oracle.Implementations.Unity;
using WebApi.DataBase.Oracle.Interfaces.Factories;
using WebApi.DataBase.Oracle.Interfaces.ModelService;

namespace WebApi.DataBase.Oracle.Bases.ModelService.Repositories
{
	internal class RepositoryBase
	{
		#region Fields

		protected ILogService modLog;
		protected readonly IDataObjectsFactory modDataObjectsFactory = Container.Resolve<IDataObjectsFactory>();
		protected static readonly IObjectsByTypeFactory modObjectsByTypeFactory = ObjectsByTypeFactory.GetFactory();
		protected static readonly IDataBaseService modDataBase = Container.Resolve<IDataBaseService>();

		#endregion

		static RepositoryBase()
		{
			modDataBase.SetDataSource("RONI");
			//modDataBase.SetDataSource("RONI_DE");
			modDataBase.SetUserId("VUDATA");
			//modDataBase.SetUserId("SWEDEN");
			modDataBase.SetPassword("guru");
			
			modDataBase.Connect();
		}

		public RepositoryBase()
		{
			try
			{
				InitLog();
			}
			catch (Exception ex)
			{
				modLog.Debug(ex.Message);
			}
		}

		public virtual void InitLog()
		{
			modLog = LogService.GetLogService<RepositoryBase>();
		}

		protected ILogService GetLog<T>() where T : class
		{
			return LogService.GetLogService<T>();
		}
	}
}
