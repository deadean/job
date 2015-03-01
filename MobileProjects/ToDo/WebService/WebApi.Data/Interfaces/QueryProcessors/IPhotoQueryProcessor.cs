using System.Threading.Tasks;
using WebApi.Data.Interfaces.Entities;

namespace WebApi.Data.Interfaces.QueryProcessors
{
	public interface IPhotoQueryProcessor
	{
		Task UploadDocument(IDocument document);
	}
}
