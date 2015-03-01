using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DataBase.Oracle.Interfaces.ModelService
{
	public interface IDataBaseService
	{
		void SetDataSource(string dataSource);
		void SetUserId(string userId);
		void SetPassword(string password);
		void Connect();
		DbDataReader getReader(CDBQuery dbQuery);

		bool ExecuteAll(CTransaction transaction, params CDBQuery[] queries);

		bool ExecuteAll(CTransaction transaction, IEnumerable<CDBQuery> queries);

		void ExecuteStoredProcedure(string procedureName);

		bool IsTraceNeedOn { get; set; }

		bool SetDatabaseTraceAction(bool p, CTransaction cTransaction);

		void CommitTransaction(string ID);

		void RollbackTransaction(string ID);

		string OpenTransaction2();

		void close();

		DbDataReader getReader(CDBQuery dbQuery, CTransaction transaction);

		object getScalar(CDBQuery dbQuery, CTransaction transaction);
	}
}
