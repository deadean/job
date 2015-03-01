using WebApi.Common.Implementations.Logging;
using WebApi.Common.Interfaces.Logging;
using WebApi.Data.Interfaces.Entities;
using WebApi.DataBase.Oracle.Implementations.Unity;
using WebApi.DataBase.Oracle.Interfaces.ModelService;
using WebApi.DataBase.Oracle.Interfaces.ModelService.Repositories;

namespace WebApi.DataBase.Oracle.Implementations.ModelService
{
	public sealed class ModelService : IModelService
	{
		#region Fields

		private readonly ILogService modLog = LogService.GetLogService<ModelService>();
		private readonly IUserRepository modUserRepository = Container.Resolve<IUserRepository>();
		private readonly IDocumentsRepository modRecordRepository = Container.Resolve<IDocumentsRepository>();

		#endregion

		#region Ctor

		public ModelService()
		{

		}

		#endregion

		#region Private Methods

		#endregion

		#region Public Methods

		public void SaveDocument(IDocument document)
		{
			modRecordRepository.SaveDocument(document);
			//modRecordRepo;     

		}

		#endregion

		#region Protected Methods
		#endregion

		#region Properties
		#endregion



	}
}
