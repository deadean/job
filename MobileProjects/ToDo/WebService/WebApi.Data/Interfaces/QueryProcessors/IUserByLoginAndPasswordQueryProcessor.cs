using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Interfaces.Entities;

namespace WebApi.Data.Interfaces.QueryProcessors
{
	public interface IUserByLoginAndPasswordQueryProcessor
	{
		IPersonInformation GetUserByLoginAndPassword(string userName, string userPassword);
	}
}
