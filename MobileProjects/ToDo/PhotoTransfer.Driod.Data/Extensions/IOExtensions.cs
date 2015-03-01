using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SystemEnv = System.Environment;
using AndroidEnv = Android.OS.Environment;
using ToDo.UI.Common.Enums.File;
using System.IO;

namespace ToDo.Driod.Data.Extensions
{
	public static class IOExtensions
	{
		public static string ToPath(this enFileWorkerLocation location)
		{			
			switch (location)
			{
				case enFileWorkerLocation.Default:
					return SystemEnv.GetFolderPath(SystemEnv.SpecialFolder.Personal);
				//case enFileWorkerLocation.Downloads:					
				//	return AndroidEnv.DirectoryDownloads;
				case enFileWorkerLocation.Documents:
					return SystemEnv.GetFolderPath(SystemEnv.SpecialFolder.MyDocuments);
				case enFileWorkerLocation.Pictures:
					return SystemEnv.GetFolderPath(SystemEnv.SpecialFolder.MyPictures);
				case enFileWorkerLocation.Videos:
					return SystemEnv.GetFolderPath(SystemEnv.SpecialFolder.MyVideos);
				case enFileWorkerLocation.Music:
					return SystemEnv.GetFolderPath(SystemEnv.SpecialFolder.MyMusic);
				default:
					return AndroidEnv.RootDirectory.AbsolutePath;
			}
		}

		public static string ToRelativePath(this enFileWorkerLocation location)
		{
			switch (location)
			{
				case enFileWorkerLocation.Downloads:
					return AndroidEnv.DirectoryDownloads;
				case enFileWorkerLocation.Documents:
					return AndroidEnv.DirectoryDocuments;
				case enFileWorkerLocation.Pictures:
					return AndroidEnv.DirectoryPictures;
				case enFileWorkerLocation.Videos:
					return AndroidEnv.DirectoryMovies;
				case enFileWorkerLocation.Music:
					return AndroidEnv.DirectoryMusic;
				default:
					return AndroidEnv.RootDirectory.AbsolutePath;
			}
		}
	}
}