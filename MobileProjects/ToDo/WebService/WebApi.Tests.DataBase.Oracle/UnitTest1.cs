using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.DataBase.Oracle;
using System.Data.Common;
using WebApi.Web.Common.Implementations.Logging;
using WebApi.Common.Implementations.Logging;
using WebApi.DataBase.Oracle.Interfaces.ModelService;
using WebApi.DataBase.Oracle.Implementations.Unity;
using WebApi.DataBase.Oracle.Enumeration.Unity;

namespace WebApi.Tests.DataBase.Oracle
{
	[TestClass]
	public class UnitTest1
	{
		private IDataBaseService modDataBase;
		[TestMethod]
		public void TestOracleConnection()
		{
			Container.RegisterType(typeof(IDataBaseService), typeof(CDataBase), enTypeLifeTime.Singleton);
			modDataBase = Container.Resolve<IDataBaseService>();
			modDataBase.close();
			modDataBase.SetDataSource("RONI");
			modDataBase.SetUserId("VUDATA");
			modDataBase.SetPassword("guru");

			modDataBase.Connect();

			var classType = Load(null);

			modDataBase.close();

			Assert.IsTrue(classType == "PROJECT");
		}

		public CDBQuery sqlRecordObjectRead(string recordID)
		{
			CDBQuery parameters = new CDBQuery("AD_REC.record_hist_select");
			parameters.Add("p_rec_id", recordID);
			return parameters;
		}
		public string Load(CTransaction transaction)
		{
			var result = string.Empty;
			try
			{
				CDBQuery dbQuery = sqlRecordObjectRead("ROOT_PROJECT_000000000");
				using (DbDataReader reader = modDataBase.getReader(dbQuery, transaction))
				{
					if (reader != null && reader.HasRows(dbQuery))
					{
						while (reader.Read())
						{
							result = reader.GetValue(1).ToString();
						}
					}
				}
			}
			catch (Exception exc)
			{
				result = string.Empty;
				CLog.Log("Load()", exc);
			}

			return result;
		}
	}
}
