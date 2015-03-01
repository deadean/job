using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Implementations.Entities;
using WebApi.Data.Interfaces.Entities;
using WebApi.DataBase.Oracle.Implementations.ModelService.DataBaseQueries.Records;
using WebApi.DataBase.Oracle.Interfaces.ModelService.Repositories;

namespace WebApi.DataBase.Oracle.Implementations.ModelService.Repositories
{
	internal sealed class DocumentsRepository : RecordRepository, IDocumentsRepository
	{
		public bool SaveDocument(IDocument document)
		{
			var result = SaveRecord(document);

			if (result)
			{
				StartIndex();
			}

			return result;
		}

		protected override bool SaveRecordPrivate(IRecord record, CTransaction transaction)
		{
			return modDataBase.ExecuteAll(transaction, GetDocumentQueries(record as Document));
		}

		private async void StartIndex()
		{ 
			await Task.Run(() => modDataBase.ExecuteStoredProcedure(RecordDataBaseQueries.SQL_START_SYNC_BLOB_INDEX_PROCEDURE));
		}

		private static IEnumerable<CDBQuery> GetDocumentQueries(IDocument document)
		{
			if (document == null)
				yield break;

			yield return RecordDataBaseQueries.sqlDocumentAttributeInsert(document);
			yield return RecordDataBaseQueries.sqlDocumentAttributeUpdate(document);
			yield return RecordDataBaseQueries.sqlBitmapDocumentInsert(document);
			yield return RecordDataBaseQueries.sqlBitmapDocumentEmpty(document);
			yield return RecordDataBaseQueries.sqlBitmapDocumentUpdate(document);			
		}
	}
}
