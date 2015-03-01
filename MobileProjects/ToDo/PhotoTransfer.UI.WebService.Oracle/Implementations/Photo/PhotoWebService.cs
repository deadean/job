using ToDo.Data.Interfaces.Entities.Photo;
using ToDo.Data.Interfaces.File;
using ToDo.Services.WebService.Interfaces;
using ToDo.Services.WebService.Interfaces.Photo;
using ToDo.UI.Common.Enums.File;
using ToDo.UI.Common.Interfaces.File;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using commonConstants = ToDo.Common.Constants;

namespace ToDo.UI.WebService.Oracle.Implementations.Photo
{
	public sealed class PhotoWebService : IPhotoWebService
	{
		private readonly IWebService modWebService;

		public PhotoWebService(IWebService webService)
		{
			modWebService = webService;
		}

		public Task UploadPhoto(IFileSource photoSource, IComment comment)
		{
			return modWebService.UploadPhoto(photoSource, comment);
		}
	}
}
