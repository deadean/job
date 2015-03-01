using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FileIO = System.IO.File;
using PathIO = System.IO.Path;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;

using CommonConstants = ToDo.UI.Common.Constants.Constants;
using ToDo.UI.Common.Enums.File;
using ToDo.UI.Common.Interfaces.File;
using ToDo.Data.Interfaces.File;
using ToDo.Data.Interfaces.Folder;
using ToDo.Driod.Data.Implementations.Folder;
using ToDo.Droid.Services.Implementations.File;

using ExceptionMessages = ToDo.Driod.Data.Constants.Constants.ExceptionMessages;
using ToDo.Droid.Services.Constants;
using ToDo.WP.Data.Implementations.File;

[assembly: Dependency(typeof(FileWorkerService))]

namespace ToDo.Droid.Services.Implementations.File
{
	public class FileWorkerService : IFileWorkerService
	{
		public Task<IFileSource> PickFileAsync(enFileWorkerLocation startupLocation = enFileWorkerLocation.Default, params string[] typeFilters)
		{
			return FilePickerDialog.PickFileAsync(Constants.Constants.PICK_FILE_TITLE, startupLocation, typeFilters);
		}

		public async Task<enFileOperationResult> MoveFileAsync(IFileSource fileSource, enFileWorkerLocation locationToSave, string newName)
		{			
			IFolderSource dirSource = null;

			if (locationToSave == enFileWorkerLocation.None)
			{
				dirSource = await GetParentFolderAsync(fileSource);
			}
			else
			{
				dirSource = new DirectoryContainer(locationToSave);
			}

			var dirInfo = dirSource.Folder as DirectoryInfo;
			var destFileName = PathIO.Combine(dirInfo.FullName, newName);

			if (await CheckFileExistsInFolderAsync(dirSource, newName))
			{
				return enFileOperationResult.FileAlreadyExists;
			}

			try
			{
				await Task.Run(() => FileIO.Move(fileSource.FilePath, destFileName));
			}
			catch (Exception ex)
			{
				throw new Exception(ExceptionMessages.MOVE_FILE_EXCEPTION, ex);				
			}
			
			return enFileOperationResult.Succeed;
		}

		public Task<enFileOperationResult> RenameFileAsync(IFileSource fileSource, string newName)
		{
			return MoveFileAsync(fileSource, enFileWorkerLocation.None, newName);
		}

		public Task<bool> CheckFileExistsInFolderAsync(IFolderSource folderSource, string fileName)
		{
			var dirInfo = folderSource.Folder as DirectoryInfo;
			return Task.Run(() => FileIO.Exists(PathIO.Combine(dirInfo.FullName, fileName)));
		}

		public Task<bool> CheckFileExistsInSameFolderAsync(IFileSource fileSource, string fileName)
		{
			return CheckFileExistsInFolderAsync(new DirectoryContainer(Directory.GetParent(fileSource.FilePath)), fileName);
		}

		public Task<IFolderSource> GetParentFolderAsync(IFileSource fileSource)
		{
			return Task.Run<IFolderSource>(() => new DirectoryContainer(Directory.GetParent(fileSource.FilePath)));
		}

		public async Task<enFileOperationResult> SaveToTextFileAsync(string fileName, string data, enFileWorkerLocation locationToSave = enFileWorkerLocation.Default, bool isReplacingExisted = false)
		{
			var dir = new DirectoryContainer(locationToSave);
			var dirInfo = dir.ContainerObject as DirectoryInfo;

			if (!isReplacingExisted && await CheckFileExistsInFolderAsync(dir, fileName))
			{
				return enFileOperationResult.FileAlreadyExists;
			}

			try
			{				
				await Task.Run(() => FileIO.WriteAllText(PathIO.Combine(dirInfo.FullName, PathIO.ChangeExtension(fileName, CommonConstants.File.TXT_EXTENSION)), data));
			}
			catch (Exception ex)
			{
				throw new Exception(ExceptionMessages.SAVE_TO_TEXT_FILE_EXCEPTION, ex.InnerException);
			}

			return enFileOperationResult.Succeed;
		}

		public async Task<IFileSource> GetFileAsync(string filePath, bool isNew = false)
		{
			return await Task.Run(() => new FileSource(filePath, isNew));
		}

		public async Task<IFileSource> TryGetFileAsync(string fileName, enFileWorkerLocation location)
		{
			var folderSource = new DirectoryContainer(location);

			if (!await CheckFileExistsInFolderAsync(folderSource, fileName))
			{
				return null;
			}

			var fullFilePath = PathIO.Combine((folderSource.Folder as DirectoryInfo).FullName, fileName);
			return await GetFileAsync(fullFilePath);
		}


		public Task<byte[]> GetFileData(IFileSource fileSource)
		{
			return Task.Run(() => FileIO.ReadAllBytes(fileSource.FilePath));
		}


		public Task<IFolderSource> ResolveLocationAsync(enFileWorkerLocation location)
		{
			throw new NotImplementedException();
		}
		
		public Task<IFileSource> CacheFileAsync(Stream stream, string cacheFileName, bool fileIsNew = false)
		{
			throw new NotImplementedException();
		}
	}
}