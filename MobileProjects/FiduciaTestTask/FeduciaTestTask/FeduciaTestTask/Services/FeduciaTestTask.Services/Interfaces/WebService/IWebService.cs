using FeduciaTestTask.FeduciaTestTask.Data.Interfaces.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.Services.Interfaces.WebService
{
	public interface IWebService
	{
		Task<IModifications> GetModificationsByCustomerCode(string customerCode);
	}
}
