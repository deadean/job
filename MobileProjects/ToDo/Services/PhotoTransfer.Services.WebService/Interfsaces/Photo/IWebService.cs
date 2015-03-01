using PhotoTransfer.Data.Interfaces.Entities.Photo;
using PhotoTransfer.Data.Interfaces.File;
using PhotoTransfer.Data.Interfaces.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.Services.WebService.Interfsaces.Photo
{
	public interface IWebService
	{
		Task UploadPhoto(IFileSource fileSource, IComment comment);
	}
}
