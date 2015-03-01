using WebApi.Data.Interfaces.Entities;

namespace WebApi.DataBase.Oracle.Interfaces.ModelService
{
	public interface IModelService
	{
		void SaveDocument(IDocument document);
	}
}
