using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileIO = System.IO.File;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PhotoTransfer.Data.Interfaces.File;
using PhotoTransfer.Common.Implementations.Special;
using System.IO;
using System.Threading.Tasks;
using PhotoTransfer.Common.Interfaces.Special;
using PhotoTransfer.WP.Data.Implementations.File;

namespace PhotoTransfer.Driod.Data.Implementations.File
{
	public class FileSource : Container<FileInfo>, IFileSource
	{
		#region Fields
		
		bool isNew;		

		#endregion

		#region Constructors

		public FileSource(FileInfo fInfo) : base(fInfo) { }

		public FileSource(string pathToFile, bool isNew = false) : base(new FileInfo(pathToFile))
		{
			this.isNew = isNew;
		}

		#endregion

		#region Properties

		#endregion

		#region IFileSource Properties

		public object File
		{
			get 
			{
				return ContainerObject;
			}
		}

		public string Name
		{
			get 
			{
				return Path.GetFileNameWithoutExtension(ContainerObject.FullName);
			}
		}

		public string FullName
		{
			get 
			{
				return Path.GetFileName(ContainerObject.FullName);
			}
		}

		public bool IsNew
		{
			get 
			{
				return isNew;
			}
		}

		public string FilePath 
		{
			get
			{
				return ContainerObject.FullName;
			}
		}

		public Stream FileStream
		{
			get 
			{
				return new FileStream(ContainerObject.FullName, FileMode.Open);
			}
		}

		#endregion

		#region Methods
		
		public Task<string> GetFileContentAsync()
		{
			using (var streamReader = new StreamReader(new FileStream(ContainerObject.FullName, FileMode.Open)))
			{
				return streamReader.ReadToEndAsync();
			}
		}

		#endregion
	}
}