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
using ToDo.UI.Common.Enums.File;
using System.IO;
using ToDo.Driod.Data.Implementations.Folder;
using System.Threading.Tasks;
using ToDo.Data.Interfaces.File;
using ToDo.Droid.Services.Dialogs.Interfaces;
using ToDo.Droid.Services.Dialogs;
using System.Security.AccessControl;
using ToDo.WP.Data.Implementations.File;

namespace ToDo.Droid.Services.Implementations.File
{
	public class FilePickerDialog
	{
		#region PickerItem class
		
		private class PickerItem : IHeaderedItem
		{
			public PickerItem(FileSystemInfo fsi)
			{
				FileInfo = fsi;
			}

			public string Header
			{
				get 
				{
					return FileInfo.Name;
				}
			}

			public FileSystemInfo FileInfo { get; set; }
		}

		#endregion

		#region Fields
		
		IEnumerable<FileSystemInfo> infos;

		#endregion

		#region Contsructor

		FilePickerDialog(enFileWorkerLocation pickerLocation, params string[] typeFilters)
		{
			var dirInfo = new DirectoryContainer(pickerLocation).ContainerObject;						

			if (typeFilters.Any())
				infos = dirInfo.GetFileSystemInfos().Where(fsi => typeFilters.Contains(fsi.Extension));
			else
				infos = dirInfo.GetFileSystemInfos();
		}

		#endregion

		#region Methods
		
		public static async Task<IFileSource> PickFileAsync(string title, enFileWorkerLocation pickerLocation, params string[] typeFilters)
		{
			var pickerDialogInfos = new FilePickerDialog(pickerLocation, typeFilters).infos;

			if (!pickerDialogInfos.Any())
				return null;

			var dialog = new ChoiseDialog<PickerItem>(pickerDialogInfos.Select(x => new PickerItem(x)));
			var res = await dialog.ShowAndSelectOneAsync(title);
			return new FileSource(res.FileInfo.FullName);
		}

		#endregion
	}
}