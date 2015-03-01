using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Web.Data.Implementations.Requests
{
	public sealed class MultiFileRequest
	{

		private readonly IEnumerable<FileRequest> mvFiles;
		public MultiFileRequest(IEnumerable<FileRequest> files)
		{
			mvFiles = files;
		}

		public IEnumerable<FileRequest> Files
		{
			get { return mvFiles; }
		}
	}
}
