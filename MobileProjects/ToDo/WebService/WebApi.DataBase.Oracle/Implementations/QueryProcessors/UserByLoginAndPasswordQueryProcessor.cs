using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Implementations.Logging;
using WebApi.Data.Implementations.Entities;
using WebApi.Data.Interfaces.Entities;
using WebApi.Data.Interfaces.QueryProcessors;
using WebApi.DataBase.Oracle.Bases.QueryProcessors;
using WebApi.DataBase.Oracle.Enumeration.Unity;
using WebApi.DataBase.Oracle.Implementations.Unity;
using WebApi.DataBase.Oracle.Interfaces.ModelService;
using Model = WebApi.DataBase.Oracle.Implementations.ModelService;

namespace WebApi.DataBase.Oracle.Implementations.QueryProcessors
{
	public class UserByLoginAndPasswordQueryProcessor : QueryProcessorBase, IUserByLoginAndPasswordQueryProcessor
	{
		#region Fields

		#endregion

		#region Ctor

		#endregion

		#region Private Methods
		#endregion

		#region Public Methods

		public IPersonInformation GetUserByLoginAndPassword(string userName, string userPassword)
		{
			//return modModelService.GetUserByLoginAndPassword(userName, userPassword);
			return null;
		}

		#endregion

		#region Protected Methods

		public override void InitLog()
		{
			modLog = LogService.GetLogService<UserByLoginAndPasswordQueryProcessor>();
		}

		#endregion

		#region Properties
		#endregion
		
	}
}
