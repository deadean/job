using ToDo.Data.Interfaces.Entities.Photo;
using ToDo.Data.Interfaces.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Services.WebService.Interfaces.Photo
{
	public interface IPhotoWebService
	{
		Task UploadPhoto(IFileSource photoSource, IComment comment);
	}
}
