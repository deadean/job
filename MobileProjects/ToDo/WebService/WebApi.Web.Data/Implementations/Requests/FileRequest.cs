using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Web.Data.Implementations.Requests
{
	public sealed class FileRequest
	{
		public string FileName { get; private set; }
		public byte[] FileData { get; private set; }
		public string UploadedFolder { get; private set; }
		public string Comment { get; private set; }

		public FileRequest(string fileName, byte[] fileData, string uploadedFolder, string comment)
		{
			this.FileName = fileName;
			this.FileData = fileData;
			this.UploadedFolder = uploadedFolder;
			this.Comment = comment;
		}
	}
}
