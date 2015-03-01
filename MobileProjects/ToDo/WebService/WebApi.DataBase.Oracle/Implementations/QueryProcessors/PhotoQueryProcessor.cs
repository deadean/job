using System.Threading.Tasks;
using WebApi.Common.Implementations.Logging;
using WebApi.Data.Interfaces.Entities;
using WebApi.Data.Interfaces.QueryProcessors;
using WebApi.DataBase.Oracle.Bases.QueryProcessors;

namespace WebApi.DataBase.Oracle.Implementations.QueryProcessors
{
	public sealed class PhotoQueryProcessor : QueryProcessorBase, IPhotoQueryProcessor
	{
		#region Fields

		#endregion

		#region Ctor

		#endregion

		#region Private Methods
		#endregion

		#region Public Methods

		public async Task UploadDocument(IDocument document)
		{
			modModelService.SaveDocument(document);
		}

		#endregion

		#region Protected Methods

		public override void InitLog()
		{
			modLog = LogService.GetLogService<PhotoQueryProcessor>();
		}

		#endregion

		#region Properties
		#endregion


	}
}
