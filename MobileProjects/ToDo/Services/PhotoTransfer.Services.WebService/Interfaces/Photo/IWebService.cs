using ToDo.Data.Interfaces.Entities.Photo;
using ToDo.Data.Interfaces.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Services.WebService.Interfaces
{
	public interface IWebService
	{
		Task UploadPhoto(IFileSource fileSource, IComment comment);
	}
}
