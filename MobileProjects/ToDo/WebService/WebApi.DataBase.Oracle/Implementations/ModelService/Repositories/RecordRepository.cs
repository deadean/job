using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Interfaces.Entities;
using WebApi.DataBase.Oracle.Bases.ModelService.Repositories;
using WebApi.DataBase.Oracle.Implementations.ModelService.DataBaseQueries.Records;
using WebApi.DataBase.Oracle.Interfaces.ModelService.Repositories;

namespace WebApi.DataBase.Oracle.Implementations.ModelService.Repositories
{
	internal abstract class RecordRepository : RepositoryBase, IRecordRepository
	{
		protected abstract bool SaveRecordPrivate(IRecord record, CTransaction transaction);

		public bool SaveRecord(IRecord record)
		{
			var result = CTransaction.Execute(t =>
								modDataBase.ExecuteAll(t, GerRecordQueries(record))
								&&
								SaveLinks(record, t)
								&&
								SaveRecordPrivate(record, t));

			if (result)
			{
				StartIndex();
			}

			return result;
		}

		private bool SaveLinks(IRecord record, CTransaction transaction)
		{
			return modDataBase.ExecuteAll(transaction, record.Links.SelectMany(GetLinkQueries));
		}

		private async void StartIndex()
		{ 
			await Task.Run(() => modDataBase.ExecuteStoredProcedure(RecordDataBaseQueries.SQL_START_SYNC_RECORD_INDEX_PROCEDURE));
		}

		private static IEnumerable<CDBQuery> GerRecordQueries(IRecord record)
		{
			if (record == null)
				yield break;

			yield return RecordDataBaseQueries.sqlRecordInsert(record);
			yield return RecordDataBaseQueries.sqlRecordUpdate(record);			
		}

		private static IEnumerable<CDBQuery> GetLinkQueries(ILink link)
		{
			if (link == null)
				yield break;

			yield return RecordDataBaseQueries.sqlRecordLinkInsert(link);
			yield return RecordDataBaseQueries.sqlRecordLinkUpdate(link);
		}
	}
}
