using WebApi.Data.Interfaces.Entities;

namespace WebApi.DataBase.Oracle.Interfaces.ModelService.Repositories
{
    internal interface IRecordRepository
    {
        bool SaveRecord(IRecord record);
    }
}
