using WebApi.Data.Interfaces.Entities;

namespace WebApi.DataBase.Oracle.Interfaces.ModelService.Repositories
{
	internal interface IUserRepository
	{
		IPersonInformation GetUserByLoginAndPassword(string login, string password);
	}
}
