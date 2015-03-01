using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Env = Android.OS.Environment;

using ToDo.Driod.Data.Extensions;
using ToDo.Data.Interfaces.Folder;
using ToDo.Common.Implementations.Special;
using ToDo.UI.Common.Enums.File;

namespace ToDo.Driod.Data.Implementations.Folder
{
	public class DirectoryContainer : Container<DirectoryInfo>, IFolderSource
	{
		public DirectoryContainer(DirectoryInfo dirInfo, bool isInternalStore = false) : base(dirInfo)
		{
			if (!dirInfo.Exists)
			{
				dirInfo.Create();
			}
		}

		public DirectoryContainer(string directoryPath, bool isInternalStore = false) : this(new DirectoryInfo(directoryPath), isInternalStore)
		{}

		public DirectoryContainer(enFileWorkerLocation location, bool isInternalStore = false) : this(new DirectoryInfo(location.ToPath()))
		{}

		public object Folder
		{
			get 
			{
				return ContainerObject;
			}
		}


		public string Path
		{
			get { throw new NotImplementedException(); }
		}
	}
}