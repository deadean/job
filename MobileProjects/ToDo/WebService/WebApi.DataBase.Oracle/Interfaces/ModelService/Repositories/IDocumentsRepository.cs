using WebApi.Data.Interfaces.Entities;

namespace WebApi.DataBase.Oracle.Interfaces.ModelService.Repositories
{
    internal interface IDocumentsRepository : IRecordRepository
    {
        bool SaveDocument(IDocument document);
    }
}
