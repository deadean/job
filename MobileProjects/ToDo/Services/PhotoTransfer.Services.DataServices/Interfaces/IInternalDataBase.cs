using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Services.DataServices.Interfaces
{
	public interface IInternalDataBase
	{
		Task SaveCommentToPhoto(string photoFileName, string comment);
	}
}
